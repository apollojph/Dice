using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GainCard : MonoBehaviour
{
    public Text cardNum;
	public GameObject depositPanel;
	public GameObject buyDiamondsPanel;
	public GameObject buyCoinsPanel;

    private int gainNum;
	[SerializeField]
	private Inventory inventory;
	[SerializeField]
	private GameManager gameManager;

    void Update()
    {
        //print(gainNum);
    }

    public void Coin()
    {
		if (GameManager.coins >= 2000) 
		{
			GameManager.coins -= 2000;

			int seed = System.Guid.NewGuid().GetHashCode();
			Random.InitState(seed);

			gainNum = (int)(Random.Range(1, 100));

			if (gainNum > 0 && gainNum <= 15) 
			{
				SetCard ("出獄卡", 0);
			} 
			else if (gainNum > 15 && gainNum <= 30) 
			{
				SetCard ("監獄卡", 1);
			}
			else if (gainNum > 30 && gainNum <= 45) 
			{
				SetCard ("單數卡", 2);
			}
			else if (gainNum > 45 && gainNum <= 60) 
			{
				SetCard ("雙數卡", 3);
			}
			else if (gainNum > 60 && gainNum <= 75) 
			{
				SetCard ("暫停卡", 4);
			}
			else if (gainNum > 75 && gainNum <= 90) 
			{
				SetCard ("強制PK卡", 5);
			}
			else
			{
				switch (gainNum) 
				{
				case 91:
					SetCard ("出獄卡", 0);
					break;
				case 92:
					SetCard ("監獄卡", 1);
					break;
				case 93:
					SetCard ("單數卡", 2);
					break;
				case 94:
					SetCard ("雙數卡", 3);
					break;
				case 95:
					SetCard ("暫停卡", 4);
					break;
				case 96:
					SetCard ("強制PK卡", 5);
					break;
				case 97:
					SetCard ("兩倍卡", 6);
					break;
				case 98:
					SetCard ("指定數字卡", 7);
					break;
				case 99:
					SetCard ("回頭卡", 8);
					break;
				case 100:
					SetCard ("金錢雙倍卡", 9);
					break;
				}
			}
		} 
		else 
		{
			depositPanel.SetActive (true);
			buyCoinsPanel.SetActive (true);
		}

        
    }
    
	public void Diamond()
	{
		if (GameManager.diamonds >= 100) 
		{
			GameManager.diamonds -= 100;

			int seed = System.Guid.NewGuid().GetHashCode();
			Random.InitState(seed);

			gainNum = (int)(Random.Range(1, 100));

			if (gainNum > 0 && gainNum <= 15) 
			{
				SetCard ("出獄卡", 0);
			} 
			else if (gainNum > 15 && gainNum <= 30) 
			{
				SetCard ("監獄卡", 1);
			}
			else if (gainNum > 30 && gainNum <= 45) 
			{
				SetCard ("單數卡", 2);
			}
			else if (gainNum > 45 && gainNum <= 60) 
			{
				SetCard ("雙數卡", 3);
			}
			else if (gainNum > 60 && gainNum <= 75) 
			{
				SetCard ("暫停卡", 4);
			}
			else if (gainNum > 75 && gainNum <= 90) 
			{
				SetCard ("強制PK卡", 5);
			}
			else
			{
				switch (gainNum) 
				{
				case 91:
					SetCard ("出獄卡", 0);
					break;
				case 92:
					SetCard ("監獄卡", 1);
					break;
				case 93:
					SetCard ("單數卡", 2);
					break;
				case 94:
					SetCard ("雙數卡", 3);
					break;
				case 95:
					SetCard ("暫停卡", 4);
					break;
				case 96:
					SetCard ("強制PK卡", 5);
					break;
				case 97:
					SetCard ("兩倍卡", 6);
					break;
				case 98:
					SetCard ("指定數字卡", 7);
					break;
				case 99:
					SetCard ("回頭卡", 8);
					break;
				case 100:
					SetCard ("金錢雙倍卡", 9);
					break;
				}
			}
		} 
		else 
		{
			depositPanel.SetActive (true);
			buyDiamondsPanel.SetActive (true);
		}


	}

	void SetCard(string cardName, int itemNum)
	{
		cardNum.text = cardName;
		inventory.AddToItem (itemNum);
	}
}
