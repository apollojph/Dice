using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameManager : MonoBehaviour 
{
	public static int coins = 50000;
	public static int diamonds = 5000;
	public static Sprite[] usedCards = new Sprite[3];
	public static int cardManaged = 0;

	public Text coinsText;
	public Text diamondsText;
	public Image[] cards = new Image[3];

	void Start()
	{
		for (int i = 0; i < cards.Length; i++) 
		{
			if (cards [i] != null && usedCards[i] != null) 
			{
				cards [i].sprite = usedCards [i];
			}
		}
	}

	void Update()
	{
		coinsText.text = coins.ToString ();
		diamondsText.text = diamonds.ToString ();
	}
}
