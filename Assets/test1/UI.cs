using UnityEngine;
using System.Collections;

public class UI : MonoBehaviour {


	public static int dice; //宣告一個全域可使用的整數

	private GameObject win_ui4;

	void Start () //遊戲初始值
	{
		dice = 6; //預設生命初始值為3
		//win_ui4 = GameObject.Find ("win_ui4");
		//win_ui4.transform.position = new Vector2 (10000, 10000);
	}

	void OnTriggerEnter2D()
	{
		/*if (Life <= 0) 
		{
			print ("gameover");
		}

		if (Life <= 0 && goin2.sucess_count >= 7) 
		{
			print ("perfect");
		}*/

		//Life -= 1;

	}

	void Update () //持續執行
	{


		/*if(Life < 0) //Life和血條的上限和下限邊界值設定
		{
			Time.timeScale = 0;
			win_ui4.transform.position = new Vector2 (520, 370);
		}else if(Life >8)
		{
			Life = 8;
			//HPNow = HPAll;
			print("補過頭了拉");
		}*/
	}
}
