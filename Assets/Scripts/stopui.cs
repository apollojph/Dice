using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class stopui : MonoBehaviour {
	public GameObject stopmenu;

	void Start () 
	{
		Time.timeScale = 1;
	}
	// Use this for initialization
	public void playsence1(){

		Application.LoadLevel ("0411-1");
	}
	public void mainmenu(){

		Application.LoadLevel ("MainMenu");
	}
	public void gameStop(){
		Time.timeScale = 0;
		stopmenu.SetActive (true);


		//Img_stop.SetActive (false);
	}
	public void gameStart(){
		Time.timeScale = 1;
		stopmenu.SetActive (false);




	}

}
