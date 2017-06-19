﻿using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PanelsMovementManager : MonoBehaviour
{
	public Camera MenuCamera;
	public RectTransform Bookmark;
	public CanvasGroup navigationCanvas;
	public CanvasGroup topCanvas;
	public CanvasGroup PanelsCanvas;

	public GameObject SubPanelGroup;
	public GameObject PopupGroup;
	public GameObject TopBarSubPanels;

	public GameObject StoryModeFlow;
	public GameObject HangarFlow;
	public GameObject EventsFlow;
	public GameObject SurvivalFlow;
	public GameObject FriendlyFlow;

	public GameObject LoadingScreen;
	public GameObject LoginScreen;
	public GameObject StoryScreen;
	public GameObject ChapterDetails;
	public GameObject ObjectiveDetails;
	public GameObject ChestDetails;
	public GameObject DarkPanel;
	public GameObject OptionPanel;
	public GameObject ButtonDarkPanel;
	public GameObject FindClanDetails;
	public GameObject FriendlyModeFlow;
	public GameObject AlredyInAClanPanel;
	public GameObject ProfilePanel;
	public GameObject AreYouSurePopup;
	public GameObject ClanMembersDetails;
	public GameObject GAME_MODE_POPUP;

	public Text GameModeCheck;

	//Main Panels
	public GameObject Panel_Play;
	public GameObject Panel_Hangar;
	public GameObject Panel_Rewards;
	public GameObject Panel_Clan;
	public GameObject Panel_Shop;
	public GameObject Panel_Missions;

	public GameObject YourShipDetailsPanel;
	public GameObject UnlockShipDetailsPanel;

	public AudioClip UIClickOpen;
	public AudioClip UIClickClose;
	public new AudioSource audio;

	public Text errorText;

	public float speedBookmark;
	public float speed;
	public float leftSpeed;
	public int ActualPanel;

	[SerializeField]
	private bool interactable;
	private bool topBarPopup;
	private Vector3 LeftPosition;

	public void Awake()
	{
		ActualPanel = 3;

		StoryModeFlow.SetActive(false);
		HangarFlow.SetActive(false);
		EventsFlow.SetActive(false);
		SurvivalFlow.SetActive(false);
		FriendlyFlow.SetActive(false);

		Panel_Shop.SetActive(false);
		Panel_Rewards.SetActive(false);
		Panel_Clan.SetActive(false);
		Panel_Hangar.SetActive(false);
		Panel_Missions.SetActive(false);

		UnlockShipDetailsPanel.SetActive(false);
		LoadingScreen.SetActive(false);
		LoginScreen.SetActive(false);
		ChapterDetails.SetActive(false);
		OptionPanel.SetActive(false);
		ButtonDarkPanel.SetActive(false);
		StoryModeFlow.SetActive(false);
		ProfilePanel.SetActive(false);
		DarkPanel.SetActive(false);
		ObjectiveDetails.SetActive(false);
		FindClanDetails.SetActive(false);
		AreYouSurePopup.SetActive(false);
		AlredyInAClanPanel.SetActive(false);
		ClanMembersDetails.SetActive(false);
		ChestDetails.SetActive(false);
		GAME_MODE_POPUP.SetActive(false);
	}

	public void CloseAll()
	{
		UnlockShipDetailsPanel.SetActive(false);
		LoadingScreen.SetActive(false);
		LoginScreen.SetActive(false);
		ChapterDetails.SetActive(false);
		OptionPanel.SetActive(false);
		ButtonDarkPanel.SetActive(false);
		StoryModeFlow.SetActive(false);
		ProfilePanel.SetActive(false);
		DarkPanel.SetActive(false);
		ObjectiveDetails.SetActive(false); ;
		FindClanDetails.SetActive(false);
		AreYouSurePopup.SetActive(false);
		ClanMembersDetails.SetActive(false);
		ChestDetails.SetActive(false);
	}

	public void CloseEverything(bool closeAll)
	{
		PopupGroup.SetActive(false);
		DarkPanel.SetActive(false);
		ButtonDarkPanel.SetActive(false);
		TopBarSubPanels.SetActive(false);

		if (closeAll == true)
		{
			StoryModeFlow.SetActive(false);
			HangarFlow.SetActive(false);
			EventsFlow.SetActive(false);
			SurvivalFlow.SetActive(false);
			FriendlyFlow.SetActive(false);
		}
	}

	public void PlaySound(AudioClip AudioClip)
	{
		audio.PlayOneShot(AudioClip, 1f);
	}

	public void DestroyGameobject(GameObject transf)
	{
		Destroy(transf);
	}

	/////////////////////////////////////////////////////////////////////
	/////////////////////////////////////////////////////////////////////
	/////////////////////////////////////////////////////////////////////
	public void CopyImage(Image ChestImage)
	{
		Image ActualImage;
		GameObject go = GameObject.Find("ChestImage_image");
		if (go != null)
		{
			ActualImage = go.GetComponentInChildren<Image>();
			ChestImage.overrideSprite = ActualImage.sprite;
			ChestImage = ActualImage;
		}
	}
	/////////////////////////////////////////////////////////////////////
	/////////////////////////////////////////////////////////////////////
	/////////////////////////////////////////////////////////////////////

	public void GAME_MODE_CHECK (string txt)
	{
		GameModeCheck.text = txt;
	}

	public void ResetImage(Image ChestImage)
	{
		ChestImage.overrideSprite = null;
	}

	public void OpenPanel_NO_DARK_PANEL(GameObject go)
	{
		SubPanelGroup.SetActive(true);
		PopupGroup.SetActive(false);
		go.SetActive(true);
		interactable = true;
		Interactable();
	}

	public void OpenPanel_DARK_PANEL(GameObject go)
	{
		//SubPanelGroup.SetActive(true);
		PopupGroup.SetActive(true);
		go.SetActive(true);
		interactable = false;
		Interactable();
	}

	public void OpenPopup(GameObject go)
	{
		SubPanelGroup.SetActive(true);
		PopupGroup.SetActive(true);
		go.SetActive(true);

		TopBarSubPanels.SetActive(false);
		interactable = false;
		Interactable();
	}

	public void OpenTopBarPanel(GameObject go)
	{
		TopBarSubPanels.SetActive(true);
		go.SetActive(true);
		SubPanelGroup.SetActive(true);

		PopupGroup.SetActive(false);
		interactable = false;
		Interactable();
	}

	public void ClosePopup(GameObject go)
	{
		CloseEverything(false);
		interactable = true;
		Interactable();
	}

	public void ClosePanel(GameObject go)
	{
		go.SetActive(false);
		interactable = true;
		Interactable();
	}

	public void Interactable()
	{
		if (interactable == false)
		{
			ButtonDarkPanel.SetActive(true);
			DarkPanel.SetActive(true);
		}
		else if (interactable == true)
		{
			ButtonDarkPanel.SetActive(false);
			DarkPanel.SetActive(false);
		}
	}

	public void MoveCameraButton(int coordinates)
	{
		StartCoroutine(MoveCameraX(coordinates));
		//CloseAll();
	}

	public void MoveBookmark(RectTransform rect)
	{
		Vector2 vectorBookmark = Bookmark.localPosition;
		Vector2 vectorRect = rect.localPosition;
		Vector2 currentSpeed = new Vector2();
		Vector2 newPosition;

		newPosition = Vector2.SmoothDamp(vectorBookmark, vectorRect, ref currentSpeed, 0.05f, speedBookmark, Time.deltaTime);
		vectorBookmark.y = vectorRect.y;
	}

	public void MoveToPanels(int panelValue)
	{
		if (panelValue != ActualPanel)
		{
			CloseEverything(true);
			//CloseAll();
			StartCoroutine(MoveCamera(panelValue));
		}
	}

	IEnumerator MoveCamera(int panel)
	{
		navigationCanvas.blocksRaycasts = false;
		topCanvas.blocksRaycasts = false;
		PanelsCanvas.blocksRaycasts = false;
		yield return MoveCameraX(1500);
		Transform camera = MenuCamera.transform;
		Vector3 targetPosition = camera.position;
		targetPosition.y = GetTargetYPosition(panel);
		camera.position = targetPosition;
		yield return MoveCameraX(0);
		navigationCanvas.blocksRaycasts = true;
		topCanvas.blocksRaycasts = true;
		PanelsCanvas.blocksRaycasts = true;
	}

	float GetTargetYPosition(int panel)
	{
		switch (panel)
		{
			case 0:
				Panel_Shop.SetActive(false);
				Panel_Clan.SetActive(false);
				Panel_Hangar.SetActive(false);
				Panel_Missions.SetActive(false);
				Panel_Play.SetActive(false);

				Panel_Rewards.SetActive(true);

				ActualPanel = 0;
				return 720;

			case 1:
				Panel_Shop.SetActive(false);
				Panel_Clan.SetActive(false);
				Panel_Hangar.SetActive(false);
				Panel_Rewards.SetActive(false);
				Panel_Play.SetActive(false);

				Panel_Missions.SetActive(true);

				ActualPanel = 1;
				return 0;

			case 2:
				Panel_Shop.SetActive(false);
				Panel_Clan.SetActive(false);
				Panel_Missions.SetActive(false);
				Panel_Rewards.SetActive(false);
				Panel_Play.SetActive(false);

				Panel_Hangar.SetActive(true);

				ActualPanel = 2;
				return -720;

			case 3:
				Panel_Shop.SetActive(false);
				Panel_Clan.SetActive(false);
				Panel_Missions.SetActive(false);
				Panel_Rewards.SetActive(false);
				Panel_Hangar.SetActive(false);

				Panel_Play.SetActive(true);

				ActualPanel = 3;
				return -1440;

			case 4:
				Panel_Shop.SetActive(false);
				Panel_Play.SetActive(false);
				Panel_Missions.SetActive(false);
				Panel_Rewards.SetActive(false);
				Panel_Hangar.SetActive(false);

				Panel_Clan.SetActive(true);

				ActualPanel = 4;
				return -2160;

			case 5:
				Panel_Clan.SetActive(false);
				Panel_Play.SetActive(false);
				Panel_Missions.SetActive(false);
				Panel_Rewards.SetActive(false);
				Panel_Hangar.SetActive(false);

				Panel_Shop.SetActive(true);

				ActualPanel = 5;
				return -2880;

			default:
				return 0;
		}
	}


	const float destinationThreashold = 0.5f;

	IEnumerator MoveCameraX(float destinationX)
	{
		PanelsCanvas.blocksRaycasts = false;

		Transform camera = MenuCamera.transform;
		Vector3 targetPosition = camera.position;
		targetPosition.x = destinationX;

		Vector3 newPosition;
		Vector3 currentSpeed = new Vector3();
		do
		{
			newPosition = Vector3.SmoothDamp(camera.position, targetPosition, ref currentSpeed, 0.05f, speed, Time.deltaTime);
			camera.position = newPosition;
			yield return null;
		} while ((newPosition - targetPosition).sqrMagnitude > destinationThreashold);

		camera.position = targetPosition;

		PanelsCanvas.blocksRaycasts = true;
	}
}