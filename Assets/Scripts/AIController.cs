using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class AIController : MonoBehaviour 
{
	public enum AIState {Stand, Moving, ToPlayer};
	public AIState aiState;
	public GameObject AIModel;
	public Vector3 direction = Vector3.forward;
	public float distances = 8;
	public float speed = 3;
	public int step = 0;
	public GameObject player;
	public GameObject gameoverPanel;
	public Text winText;
	public float waitTime = 0.5f;
	public GameObject dic1,dic2,dic3,dic4,dic5,dic6;

	private string preTag;
	private string curTag;

	void Update()
	{
		if (aiState == AIState.Moving) 
		{
			transform.position = Vector3.Lerp (transform.position, transform.position + (direction * distances), Time.deltaTime * speed);
		}

		if (player.GetComponent<PlayerController> ().playerState == PlayerController.PlayerState.ToAI) 
		{
			player.GetComponent<PlayerController> ().playerState = PlayerController.PlayerState.Stand;
			Move ();
		}

	}

	public void Move()
	{
		player.GetComponent<PlayerController> ().playerState = PlayerController.PlayerState.Stand;
		step = Random.Range (1, 6);
		if (step == 1) {
			dic1.SetActive (true);
			dic2.SetActive (false);
			dic3.SetActive (false);
			dic4.SetActive (false);
			dic5.SetActive (false);
			dic6.SetActive (false);

		}
		if (step == 2) {
			dic1.SetActive (false);
			dic2.SetActive (true);
			dic3.SetActive (false);
			dic4.SetActive (false);
			dic5.SetActive (false);
			dic6.SetActive (false);

		}
		if (step == 3) {
			dic1.SetActive (false);
			dic2.SetActive (false);
			dic3.SetActive (true);
			dic4.SetActive (false);
			dic5.SetActive (false);
			dic6.SetActive (false);

		}
		if (step == 4) {
			dic1.SetActive (false);
			dic2.SetActive (false);
			dic3.SetActive (false);
			dic4.SetActive (true);
			dic5.SetActive (false);
			dic6.SetActive (false);

		}
		if (step == 5) {
			dic1.SetActive (false);
			dic2.SetActive (false);
			dic3.SetActive (false);
			dic4.SetActive (false);
			dic5.SetActive (true);
			dic6.SetActive (false);

		}
		if (step == 6) {
			dic1.SetActive (false);
			dic2.SetActive (false);
			dic3.SetActive (false);
			dic4.SetActive (false);
			dic5.SetActive (false);
			dic6.SetActive (true);

		}
		StartCoroutine(WaitAndPrint(1.0F));
		//print ("Step:" + step);

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
				RandomDirection (2, Vector3.left, Vector3.right, Vector3.forward);
				break;
			case "TurnUpOrRight":
				if (preTag == "DirectionDetect") 
				{
					Moving (other.transform, Vector3.forward);
				} 
				else 
				{
					RandomDirection (2, Vector3.forward, Vector3.right, Vector3.forward);
				}
				break;
			case "TurnUpOrLeft":
				if (preTag == "DirectionDetect") 
				{
					Moving (other.transform, Vector3.forward);
				} 
				else 
				{
					RandomDirection (2, Vector3.forward, Vector3.left, Vector3.forward);
				}
				break;
			case "TurnUpOrLeftOrRight":
				RandomDirection (3, Vector3.forward, Vector3.left, Vector3.right);
				break;
			case "End":
				step = 0;
				winText.text = "AI Win!";
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

			aiState = AIState.Stand;
			step--;

			if (step > 0) 
			{
				aiState = AIState.Moving;
			} 
			else 
			{
				ToPlayer ();
			}
		}
		dic1.SetActive (false);
		dic2.SetActive (false);
		dic3.SetActive (false);
		dic4.SetActive (false);
		dic5.SetActive (false);
		dic6.SetActive (false);
	}

	void RandomDirection(int directionNum, Vector3 direction1, Vector3 direction2, Vector3 direction3)
	{
		aiState = AIState.Stand;
		step--;

		int direct = Random.Range (0, directionNum);

		print (direct);

		switch (direct) 
		{
			case 0:
				SetDirection (direction1);
				break;
			case 1:
				SetDirection (direction2);
				break;
			case 2:
				SetDirection (direction3);
				break;
		}

	}

	void SetDirection(Vector3 direct)
	{
		direction = direct;
		CharacterRotate ();

		if (step > 0) 
		{
			aiState = AIState.Moving;
		} 
		else 
		{
			ToPlayer ();
		}

	}

	void CharacterRotate()
	{
		float zRotate = 0f;

		if (direction == Vector3.forward) 
		{
			zRotate = 0f;
		}
		if (direction == Vector3.right) 
		{
			zRotate = 90f;
		}
		if (direction == Vector3.left) 
		{
			zRotate = 270f;
		}

		Quaternion tempRotation = Quaternion.identity;
		tempRotation.eulerAngles = new Vector3 (0f, 0f, zRotate);
		AIModel.transform.localRotation = tempRotation;
	}

	void ToPlayer()
	{
		StartCoroutine (WaitToChange(waitTime));
	}

	IEnumerator WaitToChange(float time)
	{
		yield return new WaitForSeconds (time);
		player.transform.GetChild (0).GetComponent<Camera> ().enabled = true;
		transform.GetChild (0).GetComponent<Camera> ().enabled = false;
		aiState = AIState.ToPlayer;
	}
	IEnumerator WaitAndPrint(float waitTime)  
	{  
		yield return new WaitForSeconds(waitTime);  
		aiState = AIState.Moving;
	}    
}






