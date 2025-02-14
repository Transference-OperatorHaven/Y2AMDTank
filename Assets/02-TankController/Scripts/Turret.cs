using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour
{
	[SerializeField] private Transform m_CameraMount;
	[SerializeField] private Transform m_Turret;
	[SerializeField] private Transform m_Barrel;

	private TankSO m_Data;
	private bool m_RotationDirty;
	private Coroutine m_CRAimingTurret;

	private void Awake()
	{
		m_RotationDirty = false;
	}

	public void Init(TankSO inData)
	{
		m_Data = inData;
	}

	public void SetRotationDirty()
	{
		//if already dirty then return
		//else set the value and start the below coroutine

		if (m_RotationDirty) return;
		m_RotationDirty = true;
		m_CRAimingTurret = StartCoroutine(C_AimTurret());
	}

	private IEnumerator C_AimTurret()
	{
		//Fix this to loop while the rotation is dirty, rotate towards the needed vector and unset dirty when facing
		//TIP: simplfy the problem into 2D with the Vector3.ProjectOnPlane function and diagram it out. The turret rotates around the local y and the barrel around the local x
		//Make use of the remap function as shown in Camera.cs to help
		//extention here could include some SUVAT formula work to adjust the aim to hit where the camera is pointing, accounting for gravity
		

		

		while (m_RotationDirty)
		{
            Vector3 turretProjVec = Vector3.ProjectOnPlane(m_CameraMount.transform.forward, transform.up);
            Vector3 barrelProjVec = Vector3.ProjectOnPlane(m_CameraMount.transform.forward, transform.forward);
			
			Quaternion TurretTargetRot = Quaternion.LookRotation(turretProjVec, m_Turret.transform.parent.up);
            Quaternion BarrelTargetRot = Quaternion.LookRotation(barrelProjVec, m_Turret.transform.parent.forward);

            Debug.DrawLine(m_Turret.transform.position, transform.position + turretProjVec * 25f, Color.blue);
            Debug.DrawLine(m_Barrel.transform.position, transform.position + barrelProjVec * 25f, Color.yellow);

			m_Turret.transform.rotation = Quaternion.RotateTowards(m_Turret.transform.rotation, TurretTargetRot, m_Data.TurretData.TurretTraverseSpeed * Time.deltaTime);

			Quaternion barrelRotateTowards = Quaternion.RotateTowards(m_Barrel.transform.rotation, BarrelTargetRot, m_Data.TurretData.BarrelTraverseSpeed * Time.deltaTime);
			Vector3 eulerBarrelRot = barrelRotateTowards.eulerAngles;
			m_Barrel.localEulerAngles = new Vector3(eulerBarrelRot.x, 0,0);

			if(m_Turret.transform.rotation == TurretTargetRot && m_Barrel.transform.rotation.y == BarrelTargetRot.y)
			{
				m_RotationDirty = true;
			}

			yield return null;
		}


		
	}
}
