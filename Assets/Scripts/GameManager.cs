using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameManager : MonoBehaviour 
{
	public static int coins = 50000;
	public static int diamonds = 5000;
    public static string[] useCardName = new string[3];
	public static int cardManaged = 0;

	public Text coinsText;
	public Text diamondsText;
	public Image[] cards = new Image[3];
    public Sprite[] cardImage;

    void Start()
	{
		for (int i = 0; i < cards.Length; i++) 
		{
			if (cards [i] != null && useCardName [i] != null) 
			{
				switch(useCardName[i])
                {
                    case "S_card_1_AI prison":
                        cards[i].sprite = cardImage[0];
                        break;
                    case "S_card_1_one-three-five":
                        cards[i].sprite = cardImage[1];
                        break;
                    case "S_card_1_PK":
                        cards[i].sprite = cardImage[2];
                        break;
                    case "S_card_1_player prison":
                        cards[i].sprite = cardImage[3];
                        break;
                    case "S_card_1_stop AI turn":
                        cards[i].sprite = cardImage[4];
                        break;
                    case "S_card_1_two-four-six":
                        cards[i].sprite = cardImage[5];
                        break;
                    case "S_card_2_$ double":
                        cards[i].sprite = cardImage[6];
                        break;
                    case "S_card_2_digital double":
                        cards[i].sprite = cardImage[7];
                        break;
                    case "S_card_2_position":
                        cards[i].sprite = cardImage[8];
                        break;
                    case "S_card_2_specify digital":
                        cards[i].sprite = cardImage[9];
                        break;
                }
			}
		}
	}

	void Update()
	{
		coinsText.text = coins.ToString ();
		diamondsText.text = diamonds.ToString ();
	}
}
