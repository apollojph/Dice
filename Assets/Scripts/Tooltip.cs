﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Tooltip : MonoBehaviour 
{
	
	private Item item;
	private string data;
	public GameObject tooltip;

	void Start()
	{
		tooltip.SetActive (false);
	}

	void Update()
	{
		if (tooltip.activeSelf) 
		{
			tooltip.transform.position = Input.mousePosition;
		}
	}

	public void Activate(Item item)
	{
		this.item = item;
		ConstructDataString ();
		tooltip.SetActive (true);
	}

	public void Deactivate()
	{
		tooltip.SetActive (false);
	}

	public void ConstructDataString()
	{
		data = "<color=#3b58c7><b>" + item.Title + "</b></color>\n\n" + item.Description;
		tooltip.transform.GetChild (0).GetComponent<Text> ().text = data;
	}

}
