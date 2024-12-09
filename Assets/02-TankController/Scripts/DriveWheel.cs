using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DriveWheel : MonoBehaviour
{
	public event Action<bool> OnGroundedChanged;

	[SerializeField] private Rigidbody m_RB;
	[SerializeField] private TankSO m_Data;
	[SerializeField] private Suspension[] m_SuspensionWheels;
	private int m_NumGroundedWheels;
	private bool m_Grounded;
	private float m_Acceleration;
	public void SetAcceleration(float amount) => m_Acceleration = amount;

	public void Init(TankSO inData, Rigidbody _RBRef)
	{
		m_Data = inData;
		m_RB ??= _RBRef;

		m_NumGroundedWheels = 0;

		foreach (Suspension wheel in m_SuspensionWheels)
		{
			wheel.Init(m_Data.SuspensionData, m_RB);
			wheel.OnGroundedChanged += Handle_WheelGroundedChanged;
		}
	}

	private void Handle_WheelGroundedChanged(bool newGrounded)
	{
		if (newGrounded)
		{
			if (m_NumGroundedWheels == 0) { m_Grounded = true;  }
			m_NumGroundedWheels++;
			
		}
		else
		{
			m_NumGroundedWheels--;
            if (m_NumGroundedWheels == 0) { m_Grounded = false;  }
        }
	}

	private void FixedUpdate()
	{
		//deal with acceleration here
		//you could retrofit this to be a coroutine based on when SetAcceleration brings in a value or a 0
		//TIP: acceleration is not as simple as plugging values in from the typeData, Unity works in metric units (metric tons, meters per second, etc)
		//No need to make a full engine simulation with gearing here that is going too deep, you have a couple of weeks at most for this
		
		if(!m_Grounded) return;
		int m_traction = m_NumGroundedWheels / m_SuspensionWheels.Length;
		Vector3 m_velocity = m_traction * 7 * transform.forward * m_Acceleration;

		float maxTurn = 2;

		if (m_RB.angularVelocity.y > maxTurn)
		{ m_RB.angularVelocity = new Vector3(m_RB.angularVelocity.x, maxTurn, m_RB.angularVelocity.z); }
		if (m_RB.angularVelocity.y < -maxTurn)
		{ m_RB.angularVelocity = new Vector3(m_RB.angularVelocity.x, -maxTurn, m_RB.angularVelocity.z); }

		m_RB.AddForceAtPosition(m_velocity, transform.position, ForceMode.Acceleration);
		foreach(Suspension wheel in m_SuspensionWheels)
		{
			wheel.Bounce();
		}
		
	}
}