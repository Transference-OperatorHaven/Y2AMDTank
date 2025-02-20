using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class TankController : MonoBehaviour
{
	private AM_02Tank m_ActionMap; //input
	[SerializeField] private TankSO m_Data; //type object link
	//Component links
	[SerializeField] private Rigidbody m_RB;
	[SerializeField] private CameraController m_CameraController;
	[SerializeField] private Turret m_TurretController;
	[SerializeField] private Barrel m_BarrelController;
	[SerializeField] private TankUI m_UIController;
	[SerializeField] public DriveWheel[] m_DriveWheels;

	private float m_InAccelerate;

	private float m_InSteer;
	private bool m_IsSteering;
	private Coroutine m_CRSteer;
	public float m_CurrentHealth;
	private bool m_IsFiring;

	private void Awake()
	{
		m_ActionMap = new AM_02Tank();

		m_CurrentHealth = m_Data.Health;

		m_RB ??= GetComponent<Rigidbody>();
		m_CameraController ??= GetComponent<CameraController>();

		m_TurretController ??= GetComponent<Turret>();
		m_TurretController.Init(m_Data);

        m_BarrelController ??= GetComponent<Barrel>();
        m_BarrelController.Init(m_Data);

		m_UIController.Init(this);

        foreach (DriveWheel wheel in m_DriveWheels)
		{
			wheel.Init(m_Data, m_RB);
		}
	}

	public TankSO getData()
	{
		return m_Data;
	}

	private void OnEnable()
	{
		m_ActionMap.Enable();

		m_ActionMap.Default.Accelerate.performed += Handle_AcceleratePerformed;
		m_ActionMap.Default.Accelerate.canceled += Handle_AccelerateCanceled;
		m_ActionMap.Default.Steer.performed += Handle_SteerPerformed;
		m_ActionMap.Default.Steer.canceled += Handle_SteerCanceled;
		m_ActionMap.Default.Fire.performed += Handle_FirePerformed;
		m_ActionMap.Default.Fire.canceled += Handle_FireCanceled;
		m_ActionMap.Default.Aim.performed += Handle_AimPerformed;
		m_ActionMap.Default.Zoom.performed += Handle_ZoomPerformed;
	}
	private void OnDisable()
	{
		m_ActionMap.Disable();

		m_ActionMap.Default.Accelerate.performed -= Handle_AcceleratePerformed;
		m_ActionMap.Default.Accelerate.canceled -= Handle_AccelerateCanceled;
		m_ActionMap.Default.Steer.performed -= Handle_SteerPerformed;
		m_ActionMap.Default.Steer.canceled -= Handle_SteerCanceled;
		m_ActionMap.Default.Fire.performed -= Handle_FirePerformed;
		m_ActionMap.Default.Fire.canceled -= Handle_FireCanceled;
		m_ActionMap.Default.Aim.performed -= Handle_AimPerformed;
		m_ActionMap.Default.Zoom.performed -= Handle_ZoomPerformed;
	}

	private void Handle_AcceleratePerformed(InputAction.CallbackContext context)
	{
		m_InAccelerate = context.ReadValue<float>();
		foreach (DriveWheel wheel in m_DriveWheels)
		{
			wheel.SetAcceleration(m_InAccelerate);
		}
		m_TurretController.SetRotationDirty();
	}
	private void Handle_AccelerateCanceled(InputAction.CallbackContext context)
	{
		m_InAccelerate = context.ReadValue<float>();
		foreach (DriveWheel wheel in m_DriveWheels)
		{
			wheel.SetAcceleration(m_InAccelerate);
		}
		m_TurretController.SetRotationDirty();
	}

	private void Handle_SteerPerformed(InputAction.CallbackContext context)
	{
		m_InSteer = context.ReadValue<float>();

		if (m_IsSteering) return;

		m_IsSteering = true;

		m_TurretController.SetRotationDirty();

		/*m_DriveWheels[0].SetAcceleration(-m_InSteer);
		m_DriveWheels[1].SetAcceleration(m_InSteer);*/

		m_CRSteer = StartCoroutine(C_SteerUpdate());


	}
	private void Handle_SteerCanceled(InputAction.CallbackContext context)
	{
		m_InSteer = context.ReadValue<float>();

		if (!m_IsSteering) return;

		m_IsSteering = false;

        m_TurretController.SetRotationDirty();

        m_DriveWheels[0].SetAcceleration(m_InSteer);
        m_DriveWheels[1].SetAcceleration(-m_InSteer);

        StopCoroutine(m_CRSteer);
    }
    private IEnumerator C_SteerUpdate()
	{
		while (m_IsSteering)
		{
			m_DriveWheels[0].SetAcceleration(m_InSteer * 1.5f);
			m_DriveWheels[1].SetAcceleration(-m_InSteer * 1.5f);
			yield return null;
		}
	}

    private void Handle_FirePerformed(InputAction.CallbackContext context)
	{
		m_IsFiring = true;
		m_BarrelController.Fire();
	}
	private void Handle_FireCanceled(InputAction.CallbackContext context)
	{
		m_IsFiring = false;
		//this is here in the case you want to expand to support magazine style auto-loaders but thats large scope
	}

	private void Handle_AimPerformed(InputAction.CallbackContext context)
	{
		m_CameraController.RotateSpringArm(context.ReadValue<Vector2>());
		m_TurretController.SetRotationDirty();
	}

	private void Handle_ZoomPerformed(InputAction.CallbackContext context)
	{
		m_CameraController.ChangeCameraDistance(context.ReadValue<float>());
		m_TurretController.SetRotationDirty();
	}

	public void DamageTank(float damage)
	{
        m_CurrentHealth -= damage;
		if (m_CurrentHealth <= 0) { Destroy(gameObject); }	
	}
}