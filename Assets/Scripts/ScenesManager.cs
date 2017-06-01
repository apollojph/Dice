using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ScenesManager : MonoBehaviour 
{

	public GameObject mainMenu;
	public GameObject characterMenu;
	public GameObject inventoryMenu;
	public GameObject gainCardsMenu;
	public GameObject changeNamePanel;
	public Text name;
	public Text inputName;
	public GameObject depositPanel;
	public GameObject buyDiamondsPanel;
	public GameObject buyCoinsPanel;

	[SerializeField]
	private GameManager gameManager;
	[SerializeField]
	private Canvas canvas;

	public void ToCharacterMenu()
	{
		canvas.renderMode = RenderMode.ScreenSpaceCamera;
		mainMenu.SetActive (false);
		characterMenu.SetActive (true);
		inventoryMenu.SetActive (false);
		gainCardsMenu.SetActive (false);
	}

	public void ToMainMenu()
	{
		canvas.renderMode = RenderMode.ScreenSpaceCamera;
		mainMenu.SetActive (true);
		characterMenu.SetActive (false);
		inventoryMenu.SetActive (false);
		gainCardsMenu.SetActive (false);
	}

	public void ToInventoryMenu()
	{
		canvas.renderMode = RenderMode.ScreenSpaceOverlay;
		mainMenu.SetActive (false);
		characterMenu.SetActive (false);
		inventoryMenu.SetActive (true);
		gainCardsMenu.SetActive (false);
	}

	public void ToGainCardsMenu()
	{
		canvas.renderMode = RenderMode.ScreenSpaceOverlay;
		mainMenu.SetActive (false);
		characterMenu.SetActive (false);
		inventoryMenu.SetActive (false);
		gainCardsMenu.SetActive (true);
	}

	public void ToChangeNamePanel()
	{
		changeNamePanel.SetActive (true);
	}

	public void SureToChangeName()
	{
		name.text = inputName.text;
		changeNamePanel.SetActive (false);
	}

	public void StartGame()
	{
		GameManager.cardManaged = 0;
		Application.LoadLevel ("0411-1");
	}

	public void PurchaseDiamonds(int value)
	{
		GameManager.diamonds += value;
	}

	public void PurchaseCoins(int value)
	{		
		GameManager.coins += value;
	}

	public void CostDiamonds(int price)
	{
		GameManager.diamonds -= price;
	}

	public void ToBuyDiamondsPanel()
	{
		depositPanel.SetActive (true);
		buyDiamondsPanel.SetActive (true);
	}

	public void CloseBuyDiamondsPanel()
	{
		depositPanel.SetActive (false);
		buyDiamondsPanel.SetActive (false);
	}

	public void ToBuyCoinsPanel()
	{
		depositPanel.SetActive (true);
		buyCoinsPanel.SetActive (true);
	}

	public void CloseBuyCoinsPanel()
	{
		depositPanel.SetActive (false);
		buyCoinsPanel.SetActive (false);
	}
}
