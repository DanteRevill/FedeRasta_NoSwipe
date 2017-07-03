using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

	public class SkillInfoScript : MonoBehaviour, IPointerDownHandler, IPointerUpHandler {

	public GameObject SkillDetails;

	void Update()
	{
		Debug.Log("SKILL_DETAILS");
		if (ispressed == true)
		{
			SkillDetails.SetActive(true);
		}
		else
		{
			SkillDetails.SetActive(false);
		}
	}

	bool ispressed = false;

	public void OnPointerDown(PointerEventData eventData)
	{
		ispressed = true;
	}

	public void OnPointerUp(PointerEventData eventData)
	{
		ispressed = false;
	}
}
