using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Barrel : MonoBehaviour
{
	[SerializeField] private TankSO m_Data;
	[SerializeField] private Shell m_ShellPrefab;
    [SerializeField] private GameObject SpawnPos;
	[SerializeField] private Shell SpawnedShell;
    [SerializeField] public List<ShellSO> m_AmmoTypes;
	[SerializeField] public List<int> m_AmmoCounts;
	public int m_SelectedShell = 0;
	private float m_CurrentDispersion;
	bool m_Reloading;



	//Expand this class as you see fit, it is essentially your weapon
	//spawn the base shell and inject the data from m_AmmoTypes after spawning
	
	public void Init(TankSO inData)
	{
		m_AmmoCounts = new List<int>();
		m_Data = inData;
		for(int i = 0; i < m_AmmoTypes.Count; i++)
		{
			m_AmmoCounts.Add(m_AmmoTypes[i].maxAmmo);
		}
	}

	public void Fire()
	{
		if(Input.GetKeyDown(KeyCode.Y)) m_AmmoCounts[m_SelectedShell] = m_AmmoTypes[m_SelectedShell].maxAmmo;
		if (m_Reloading) return;
		if (m_AmmoCounts[m_SelectedShell] <= 0) return;
		SpawnedShell = GameObject.Instantiate(m_ShellPrefab, SpawnPos.transform.position, SpawnPos.transform.rotation);
		SpawnedShell.LaunchShell(m_AmmoTypes[m_SelectedShell]);
		m_AmmoCounts[m_SelectedShell]--;
		StartCoroutine(C_Reload());
	}

	IEnumerator C_Reload()
	{
		m_Reloading = true;
		yield return new WaitForSeconds(m_Data.BarrelData.AimingTime);
		m_Reloading = false;
	}

}
