using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public struct UpgradesChevorns
{
	public Image HealthUpgrade_1;
	public Image HealthUpgrade_2;
	public Image HealthUpgrade_3;
	public Image OverheatUpgrade_1;
	public Image OverheatUpgrade_2;
	public Image OverheatUpgrade_3;
	public Image DefensiveUpgrade_1;
	public Image DefensiveUpgrade_2;
	public Image DefensiveUpgrade_3;
	public Image OffensiveUpgrade_1;
	public Image OffensiveUpgrade_2;
	public Image OffensiveUpgrade_3;
}

// divide in various little structs to avoid overlapping chevrons

public class UpgradeChevronManager : MonoBehaviour {

	const int VALUE_SIZE = 5;
	public UpgradesChevorns[] Chevrons = new UpgradesChevorns[VALUE_SIZE];

	public void IncreaseChevrons()
	{
		// increse number of chevrons
	}

	public void CheckNumberOfChevrons()
	{
		// check how many chevrons are in scene
	}

	public void InstantiateChevrons()
	{
		// instantiate the correct number of chevrons
	}
}
