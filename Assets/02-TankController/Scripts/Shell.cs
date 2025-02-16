using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shell : MonoBehaviour
{
    [SerializeField] private TankSO m_Data;
    [SerializeField] private Rigidbody m_RB;
    private ShellSO m_Shell;
    private void Awake()
    {
        m_RB = GetComponent<Rigidbody>();
        Destroy(gameObject, 10f);
    }

    public void LaunchShell(ShellSO shellData)
    {
        m_Shell = shellData;
        m_RB.AddForce(transform.forward * shellData.Velocity, ForceMode.Impulse);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            TankController enemyTank = collision.gameObject.GetComponent<TankController>();
            if (enemyTank) enemyTank.DamageTank(m_Shell.Damage); 
        }
        Destroy(gameObject);
    }
}
