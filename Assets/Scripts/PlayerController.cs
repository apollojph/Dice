using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour 
{
	public enum PlayerState {Stand, Moving, ToAI, DoubleMove, OddMove, EvenMove, OrderMove, Stop};
	public PlayerState playerState;
	public GameObject playerModel;
	public Vector3 direction = Vector3.forward;
	public float distances = 8;
	public float speed = 3;
	public int step = 0;
	public GameObject switchDirectionPanel;
	public GameObject directionBtnLeft;
	public GameObject directionBtnRight;
	public GameObject directionBtnUp;
	public GameObject rollDiceBtn;
	public GameObject AI;
	public GameObject gameoverPanel;
	public Text winText;
	public float waitTime = 0.5f;
	public GameObject dic1,dic2,dic3,dic4,dic5,dic6;
	public Sprite dirUp, dirLeft, dirRight;

	private string preTag;
	private string curTag;

	void Start () 
	{
		int seed = System.Guid.NewGuid().GetHashCode();
		Random.InitState(seed);
	}
		
	void Update()
	{
		if (playerState == PlayerState.Moving) 
		{
			transform.position = Vector3.Lerp (transform.position, transform.position + (direction * distances), Time.deltaTime * speed);
			rollDiceBtn.SetActive (false);
		}

		if (AI.GetComponent<AIController> ().aiState == AIController.AIState.ToPlayer) 
		{
			AI.GetComponent<AIController> ().aiState = AIController.AIState.Stand;
			rollDiceBtn.SetActive (true);
		}

        if (playerState == PlayerState.Stop)
        {
            ToAI();
        }
    }


	public void SetStep()
	{
        if(playerState != PlayerState.OrderMove)
        {
            step = Random.Range(1, 6);
        }

        if(playerState == PlayerState.DoubleMove)
        {
            step *= 2;
        }

        if (playerState == PlayerState.OddMove)
        {
            if (step % 2 != 1)
            {
                step = Random.Range(1, 6);
            }
        }

        if (playerState == PlayerState.EvenMove)
        {
            if (step % 2 != 0)
            {
                step = Random.Range(1, 6);
            }
        }

        /*
        switch (playerState)
        {
            case PlayerState.DoubleMove:
                
                break;

            case PlayerState.OddMove:
                
                break;

            case PlayerState.EvenMove:
                if (step % 2 != 0)
                {
                    step = Random.Range(1, 6);
                }
                break;
        }
        */

		if (step == 1) 
		{
			dic1.SetActive (true);
			dic2.SetActive (false);
			dic3.SetActive (false);
			dic4.SetActive (false);
			dic5.SetActive (false);
			dic6.SetActive (false);

		}
		if (step == 2) 
		{
			dic1.SetActive (false);
			dic2.SetActive (true);
			dic3.SetActive (false);
			dic4.SetActive (false);
			dic5.SetActive (false);
			dic6.SetActive (false);

		}
		if (step == 3) 
		{
			dic1.SetActive (false);
			dic2.SetActive (false);
			dic3.SetActive (true);
			dic4.SetActive (false);
			dic5.SetActive (false);
			dic6.SetActive (false);

		}
		if (step == 4) 
		{
			dic1.SetActive (false);
			dic2.SetActive (false);
			dic3.SetActive (false);
			dic4.SetActive (true);
			dic5.SetActive (false);
			dic6.SetActive (false);

		}
		if (step == 5) 
		{
			dic1.SetActive (false);
			dic2.SetActive (false);
			dic3.SetActive (false);
			dic4.SetActive (false);
			dic5.SetActive (true);
			dic6.SetActive (false);

		}
		if (step == 6) 
		{
			dic1.SetActive (false);
			dic2.SetActive (false);
			dic3.SetActive (false);
			dic4.SetActive (false);
			dic5.SetActive (false);
			dic6.SetActive (true);

		}

		print ("Step:" + step);
		//dic1.SetActive (true);
		//StartCoroutine (timecount ());
		StartCoroutine(WaitAndPrint(1.0F));
		//playerState = PlayerState.Moving;

	}


	void OnTriggerEnter(Collider other)
	{
		preTag = curTag;
		curTag = other.tag;

		//print ("Previous Tag: " + preTag);
		//print ("Current Tag: " + curTag);

		switch (other.tag) 
		{
		case "Ground":
				Moving (other.transform, direction);
				break;
			case "TurnRight":
				Moving (other.transform, Vector3.right);
				CharacterRotate ();
				break;
			case "TurnUp":
				Moving (other.transform, Vector3.forward);
				CharacterRotate ();
				break;
			case "TurnLeftOrRight":
	//			ShowDirectionPanel ("Left", "Right", "None", false);
	//			ShowDirectionPanel (dirLeft, dirRight, null, false);
				ShowDirectionPanel (true, true, false);
				break;
			case "TurnUpOrRight":
				if (preTag == "DirectionDetect") 
				{
					Moving (other.transform, Vector3.forward);
				} 
				else 
				{
	//				ShowDirectionPanel ("Up", "Right", "None", false);
	//				ShowDirectionPanel (dirUp, dirRight, null, false);
					ShowDirectionPanel (false, true, true);
				}
				break;
			case "TurnUpOrLeft":
				if (preTag == "DirectionDetect") 
				{
					Moving (other.transform, Vector3.forward);
				} 
				else 
				{
	//				directionBtn3.SetActive (true);
	//				ShowDirectionPanel ("Up", "Left", "None", false);
	//				ShowDirectionPanel (dirUp, dirLeft, null, false);
					ShowDirectionPanel (true, false, true);
				}
				break;
			case "TurnUpOrLeftOrRight":
	//			ShowDirectionPanel ("Up", "Left", "Right", true);
	//			ShowDirectionPanel (dirUp, dirLeft, dirRight, false);
				ShowDirectionPanel (true, true, true);
				break;
			case "End":
				step = 0;
				winText.text = "You Win!";
				gameoverPanel.SetActive (true);
				break;
		}

	}

	void Moving(Transform other, Vector3 direct)
	{
		direction = direct;

		if (step > 0) 
		{
			Vector3 pos = transform.position;
			pos.z = other.position.z;
            transform.position = pos;

			playerState = PlayerState.Stand;
			step--;

			if (step > 0) 
			{
				playerState = PlayerState.Moving;
			} 
			else 
			{
				ToAI ();
			}
		}
		dic1.SetActive (false);
		dic2.SetActive (false);
		dic3.SetActive (false);
		dic4.SetActive (false);
		dic5.SetActive (false);
		dic6.SetActive (false);

	}

	public void SwtichDirectionBtn1()
	{
		ChangeDirectionBtnText (directionBtnLeft.GetComponent<Image>().sprite.name);
	}

	public void SwtichDirectionBtn2()
	{
		ChangeDirectionBtnText (directionBtnRight.GetComponent<Image>().sprite.name);
	}
	public void SwtichDirectionBtn3()
	{
		ChangeDirectionBtnText (directionBtnUp.GetComponent<Image>().sprite.name);
	}

	void ShowDirectionPanel(bool leftShow, bool rightShow, bool upShow)
	{
//		playerState = PlayerState.Stand;
//		step--;
//		rollDiceBtn.SetActive (false);
//		directionBtn1.transform.GetChild(0).GetComponent<Text>().text = btn1Text;
//		directionBtn2.transform.GetChild(0).GetComponent<Text>().text = btn2Text;
//		directionBtn3.transform.GetChild(0).GetComponent<Text>().text = btn3Text;
//		directionBtn3.SetActive (showBtn3);
//		switchDirectionPanel.SetActive (true);

//		playerState = PlayerState.Stand;
//		step--;
//		rollDiceBtn.SetActive (false);
//		directionBtnLeft.GetComponent<Image>().sprite = direction1;
//		directionBtnRight.GetComponent<Image>().sprite = direction2;
//		directionBtnUp.GetComponent<Image>().sprite = direction3;
//		directionBtnUp.SetActive (showBtn3);
//		switchDirectionPanel.SetActive (true);

		playerState = PlayerState.Stand;
		step--;
		rollDiceBtn.SetActive (false);
		directionBtnLeft.SetActive (leftShow);
		directionBtnRight.SetActive (rightShow);
		directionBtnUp.SetActive (upShow);
		switchDirectionPanel.SetActive (true);

	}

	void ChangeDirectionBtnText(string tex)
	{
		switch (tex) 
		{
			case "button_direction_up":
				SetDirection (Vector3.forward);
				break;
			case "button_direction_left":
				SetDirection (Vector3.left);
				break;
			case "button_direction_right":
				SetDirection (Vector3.right);
				break;
		}
	}

	void SetDirection(Vector3 direct)
	{
		
		direction = direct;
		CharacterRotate ();

		if (step > 0) 
		{
			playerState = PlayerState.Moving;
		}
		else 
		{
			ToAI ();
		}

		switchDirectionPanel.SetActive (false);
	}

	void ToAI()
	{
		StartCoroutine (WaitToChange(waitTime));
	}

	void CharacterRotate()
	{
		float xRotate = 0f;

		if (direction == Vector3.forward) 
		{
			xRotate = -90f;
		}
		if (direction == Vector3.right) 
		{
			xRotate = -180f;
		}
		if (direction == Vector3.left) 
		{
			xRotate = 0f;
		}

		Quaternion tempRotation = Quaternion.identity;
		tempRotation.eulerAngles = new Vector3 (xRotate, 90f, 90f);
		playerModel.transform.localRotation = tempRotation;
	}

	IEnumerator WaitToChange(float time)
	{
		yield return new WaitForSeconds (time);
		AI.transform.GetChild (0).GetComponent<Camera> ().enabled = true;
		transform.GetChild (0).GetComponent<Camera> ().enabled = false;
		playerState = PlayerState.ToAI;
	}
	IEnumerator WaitAndPrint(float waitTime)  
	{  
		yield return new WaitForSeconds(waitTime);  
		playerState = PlayerState.Moving;
	}    
}


	

