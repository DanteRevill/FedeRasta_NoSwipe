using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

	public class SkillInfoScript : MonoBehaviour, IPointerDownHandler, IPointerUpHandler {

	public GameObject SkillDetails;

	public void OnPointerDown(PointerEventData eventData)
	{
		SkillDetails.SetActive(true);
	}

	public void OnPointerUp(PointerEventData eventData)
	{
		SkillDetails.SetActive(false);
	}
}
