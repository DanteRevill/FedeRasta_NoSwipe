using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public enum ResourceType {
	Money,
	Gems,
	Iron,
	Steel,
	Silver,
	Gold,
	HealthPoint,
	OverheatPoint,
	OffensivePoint,
	DefensivePoint
}

[System.Serializable]
public class ShopElement : System.IComparable<ShopElement> {
	public ResourceType buyType;
	public float buyAmount;
	public ResourceType payType;
	public float payAmount;
	public Text textBuyAmount;
	public Text textPayAmount;
	public string suffix;
	public string prefix;
	public string decimals = "";
	//public Text textPayGems;

	public int CompareTo (ShopElement other){
		if (buyAmount < other.buyAmount)
			return -1;
		else if (buyAmount > other.buyAmount)
			return 1;
		else
			return 0;
	}
}

public class ShopManagerScript : MonoBehaviour {

	const int VALUE_SIZE = 4;
	static Dictionary<string, ShopElement> map = new Dictionary<string, ShopElement>();

[SerializeField]
	private ShopElement[] ResourcesValue = new ShopElement[VALUE_SIZE];
	
	static public float StatusBarRubyValue;
	public Text StatusBarRubyText;
	static public float StatusBarIronValue;
	public Text StatusBarIronText;
	static public float StatusBarSteelValue;
	public Text StatusBarSteelText;
	static public float StatusBarSilverValue;
	public Text StatusBarSilverText;
	static public float StatusBarGoldValue;
	public Text StatusBarGoldText;
	static public float HealthPoint;
	public Text HealthPointText;
	static public float OverheathPoint;
	public Text OverheatPointText;
	static public float OffensivePoint;
	public Text OffensivePointText;
	static public float DefensivePoint;
	public Text DefensivePointText;

[SerializeField]
	public AudioClip RubyIncrease;
	public AudioClip RubyDecrease;
	public AudioClip Error;
	public new AudioSource audio;

	private void Awake()
	{
		StatusBarRubyText.text = "0";
		StatusBarIronText.text = "0";
		StatusBarSteelText.text = "0";
		StatusBarSilverText.text = "0";
		StatusBarGoldText.text = "0";
		HealthPoint = 0;
		OverheathPoint = 0;
		OffensivePoint = 0;
		DefensivePoint = 0;

		for (int i = 0; i < ResourcesValue.Length; i++)
		{
			ResourcesValue[i].textBuyAmount.text = "X " + ResourcesValue[i].buyAmount;
			ResourcesValue[i].textPayAmount.text = ResourcesValue[i].prefix + " " + ResourcesValue[i].payAmount.ToString(ResourcesValue[i].decimals + ResourcesValue[i].suffix);
			//ResourcesValue[i].textPayGems.text = ResourcesValue[i].payAmount.ToString();
		}
	}

	public void PlaySound(AudioClip AudioClip)
	{
		audio.PlayOneShot(AudioClip, 1f);
	}

	public void BuyRubyPack(int Index)
	{
		// Remove ca$h and mon€y
		PlaySound(RubyIncrease);
		StatusBarRubyValue += ResourcesValue[Index].buyAmount;
		StatusBarRubyText.text = StatusBarRubyValue.ToString ();
	}

	public void BuyIronPack(int Index)
	{
		Buy (ResourcesValue [Index], ref StatusBarRubyValue, StatusBarRubyText, ref StatusBarIronValue, StatusBarIronText);
	}

	public void BuySteelPack(int Index)
	{
		Buy (ResourcesValue [Index], ref StatusBarRubyValue, StatusBarRubyText, ref StatusBarSteelValue, StatusBarSteelText);
	}

	public void BuySilverPack(int Index)
	{
		Buy (ResourcesValue [Index], ref StatusBarRubyValue, StatusBarRubyText, ref StatusBarSilverValue, StatusBarSilverText);
	}

	public void BuyGoldPack(int Index)
	{
		Buy (ResourcesValue [Index], ref StatusBarRubyValue, StatusBarRubyText, ref StatusBarGoldValue, StatusBarGoldText);
	}

	public void UpgradeHealth(int Index)
	{
		Buy (ResourcesValue[Index], ref StatusBarIronValue, StatusBarIronText, ref HealthPoint, HealthPointText);
	}

	void Buy (ShopElement shopElement, ref float buyValue, Text buyText, ref float payValue, Text payText){
		if (shopElement.payAmount <= StatusBarRubyValue) { 
			buyValue -= shopElement.payAmount;
			buyText.text = buyValue.ToString ();
			payValue += shopElement.buyAmount;
			payText.text = payValue.ToString ();
			PlaySound(RubyDecrease);
		}
		else
		{
			PlaySound(Error);
		}
	}
}


// <>