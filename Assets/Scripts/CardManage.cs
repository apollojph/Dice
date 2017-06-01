using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class CardManage : MonoBehaviour 
{
	public GameObject panel;
	public GameObject slotPanel;
	public GameObject inventorySlot;

	public int slotAmount = 20;
	public List<Item> items = new List<Item> ();
	public List<GameObject> slots = new List<GameObject> ();

	void Start()
	{
		for (int i = 0; i < slotAmount; i++) 
		{
			slots.Add (Instantiate(inventorySlot));
			slots [i].GetComponent<Slot> ().id = i;
			slots [i].transform.SetParent (slotPanel.transform);
			slots [i].GetComponent<RectTransform>().localScale = Vector3.one;

			Vector3 temp;
			temp = slots [i].GetComponent<RectTransform> ().anchoredPosition3D;
			temp.z = 0;
			slots [i].GetComponent<RectTransform> ().anchoredPosition3D = temp;
		}
	}
}
