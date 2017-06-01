using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AlphaChage : MonoBehaviour 
{
	[Range(0.0f, 1.0f)]
	public float alpha = 1f;

	void Update () 
	{
		if (transform.childCount > 0) 
		{
			for (int i = 0; i < transform.childCount; i++) 
			{
				Color tempColor = transform.GetChild (i).GetComponent<Image> ().color;
				tempColor.a = alpha;
				transform.GetChild (i).GetComponent<Image> ().color = tempColor;
			}
		} 
		else 
		{
			Color tempColor = GetComponent<Image> ().color;
			tempColor.a = alpha;
			GetComponent<Image> ().color = tempColor;
		}

	}
}