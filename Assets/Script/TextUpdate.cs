using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public struct Score {
	[HideInInspector]
	public int current;
	public int max;
	public Text textField;
}

public class TextUpdate : MonoBehaviour {

	const int SIZE = 6;
	private int notificationValue = 0;
	//////////////////////////////////////////////////////////////////
	//////////////////////////////////////////////////////////////////
	//////////////////////////////////////////////////////////////////
	public GridLayoutGroup Grid;
	//////////////////////////////////////////////////////////////////
	//////////////////////////////////////////////////////////////////
	//////////////////////////////////////////////////////////////////

	private Vector3 autoLocalScale;

	[SerializeField]
	private Score[] scores = new Score[SIZE];
	private bool isFirstTime = true;
	private int totalMax;

	public AudioClip AchievementCompleated;
	public new AudioSource audio;
	private int totalScore = 0;

	void Awake()
	{
		autoLocalScale = new Vector3(1, 1, 1);
		for (int i = 0; i < scores.Length; i++)
		{
			IncreaseAchievementValue(i, 0);
			totalMax += scores[i].max;
		}
		isFirstTime = false;
	}

	//////////////////////////////////////////////////////////////////
	//////////////////////////////////////////////////////////////////
	//////////////////////////////////////////////////////////////////
	public void AddItem(GameObject item)
	{
		if (item == null)
			return;

		item.transform.SetParent(Grid.transform);
		//item.transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
		item.transform.localPosition = Vector3.zero;
	}
	//////////////////////////////////////////////////////////////////
	//////////////////////////////////////////////////////////////////
	//////////////////////////////////////////////////////////////////


	public void PlaySound(AudioClip AudioClip)
	{
		audio.PlayOneShot(AudioClip, 1f);
	}

	public void IncreaseAchievementValue(int indexScore) {
		IncreaseAchievementValue (indexScore, 1);
	}

	public void IncreaseAchievementValue(int indexScore, int amount) {
		int cur = scores [indexScore].current;
		int max = scores [indexScore].max;
		int newCur = Mathf.Min (cur + amount, max);
		if (isFirstTime)
		{
			scores[indexScore].current = newCur;
			scores[indexScore].textField.text = newCur.ToString() + "/" + scores[indexScore].max;
			totalScore = totalScore - cur + newCur;
		}
		else if (newCur != cur) {
			scores [indexScore].current = newCur;
			scores [indexScore].textField.text = newCur.ToString() + "/" + scores[indexScore].max;
			totalScore = totalScore - cur + newCur;
			PlaySound(AchievementCompleated);
		}
	}

	public void PrintTotalValue(Text TotalTierValue)
	{
		TotalTierValue.text = totalScore.ToString() + "/" + totalMax;
	}
}
