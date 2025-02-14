using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private Transform m_SpringArmKnuckle;
    [SerializeField] private Transform m_CameraMount;
    [SerializeField] private Camera m_Camera;
    [SerializeField] private CameraSO m_Data;

    private float m_CameraDist = 5f;

    [SerializeField] private Vector3 m_TargetOffset;

    public void RotateSpringArm(Vector2 change)
    {
        //Break the problem down into 2; yaw and pitch
        //yaw is dealt with first and is the world y rotation
        //Then deal with pitch on the local x rotation
        //This is where you limit the pitch value but the limits arent simple
        //as you need to remap a (0 to 360) value into a (-180 to 180) value using the provided Remap function which is an extension of the float type
        //you may want to limit the amount of change rather than after rotating so tha camera doesnt jitter. Refer to the healthComponent from C4E for the idea

        float pitch = m_SpringArmKnuckle.rotation.eulerAngles.x;
        float yaw = m_SpringArmKnuckle.rotation.eulerAngles.y;

        pitch = pitch.Remap360To180PN();
        pitch = Mathf.Clamp(pitch, m_Data.MinPitch, m_Data.MaxPitch);

        yaw = yaw.Remap360To180PN();

        m_SpringArmKnuckle.rotation = Quaternion.Euler(Vector3.up * (change.x * (m_Data.YawSensitivity / 1000))) * m_SpringArmKnuckle.rotation;
        //m_SpringArmKnuckle.rotation = Quaternion.Euler((pitch + change.x * m_Data.PitchSensitivity), (yaw + change.y * m_Data.YawSensitivity), 0) * m_SpringArmKnuckle.rotation;

        m_SpringArmKnuckle.Rotate(Vector3.up, change.x, Space.World);
        m_SpringArmKnuckle.Rotate(Vector3.left, change.y, Space.World);

    }

    public void ChangeCameraDistance(float amount)
    {
        if (amount > 0)
        {
            m_CameraDist += Mathf.Clamp(m_CameraDist + amount, m_Data.MinDist, m_Data.MaxDist);
        }
        else if (amount < 0)
        {
            m_CameraDist -= Mathf.Clamp(m_CameraDist - amount, m_Data.MinDist, m_Data.MaxDist);
        }

        //probably want to constrain this value
    }

    private void LateUpdate()
    {
        //set the Knuckle to be the position of the tank plus the offset
        //REMEMBER: this script is ON THE TANK. It is pulling the camera each frame

        m_SpringArmKnuckle.position = transform.position + m_TargetOffset;

        //Vector3 finalPos = (m_SpringArmKnuckle.position) - (m_SpringArmKnuckle.forward * m_CameraDist);

        RaycastHit hit;

        if (Physics.SphereCast(m_SpringArmKnuckle.position, m_Data.CameraProbeSize, -m_SpringArmKnuckle.forward, out hit, m_CameraDist))
        {
            m_CameraDist = hit.distance;
        }

        m_CameraMount.position = m_SpringArmKnuckle.position - m_SpringArmKnuckle.forward * m_CameraDist;
        m_CameraMount.LookAt(m_SpringArmKnuckle.position);

        //Expand here by using a sphere trace from the tank backwards to see if the camera needs to move forward, out the way of geometry
    }
}