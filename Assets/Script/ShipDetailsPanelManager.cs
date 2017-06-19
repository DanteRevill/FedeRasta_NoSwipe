using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public struct Ship
{
	public RectTransform ShipDetailsPanel;
	public Text Health;
	public int HealthValue;
	public Text Overheat;
	public int OverheatValue;
	public Text Offensive;
	public int OffensiveValue;
	public Text Defensive;
	public int DefensiveValue;
	public Text Level;
	public int LevelValue;
	public Image OffensiveIcon;
	public Image DefensiveIcon;
	public Image ShipFactionIcon;
	public Image ShipImage;
	public Text ShipNameText;
	public string ShipNameString;
}



[System.Serializable]
public class ShipDetailsPanelManager : MonoBehaviour
{
	const int VALUE_SIZE = 5;
	public Ship[] ShipDetails = new Ship[VALUE_SIZE];

	private void Awake()
	{
		for (int i = 0; i < ShipDetails.Length; i++)
		{
			ShipDetails[i].Health.text = ShipDetails[i].HealthValue.ToString();
			ShipDetails[i].Overheat.text = ShipDetails[i].OverheatValue.ToString();
			ShipDetails[i].Offensive.text = ShipDetails[i].OffensiveValue.ToString();
			ShipDetails[i].Defensive.text = ShipDetails[i].DefensiveValue.ToString();
			ShipDetails[i].Level.text = ShipDetails[i].LevelValue.ToString();
			ShipDetails[i].ShipNameText.text = ShipDetails[i].ShipNameString;
		}
	}
}
