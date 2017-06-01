using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class Inventory : MonoBehaviour 
{
	public GameObject panel;
	public GameObject slotPanel;
	public GameObject inventorySlot;
	public GameObject inventoryItem;

	private ItemDatabase database;

	public int slotAmount = 20;
	public List<Item> items = new List<Item> ();
	public List<GameObject> slots = new List<GameObject> ();

	void Start()
	{
		database = GetComponent<ItemDatabase> ();

		for (int i = 0; i < slotAmount; i++) 
		{
			items.Add (new Item ());
			slots.Add (Instantiate(inventorySlot));
			slots [i].GetComponent<Slot> ().id = i;
			slots [i].transform.SetParent (slotPanel.transform);
			slots [i].GetComponent<RectTransform> ().localScale = Vector3.one;

			Vector3 temp;
			temp = slots [i].GetComponent<RectTransform> ().anchoredPosition3D;
			temp.z = 0;
			slots [i].GetComponent<RectTransform> ().anchoredPosition3D = temp;
		}
	}

	public void AddToItem(int id)
	{
		Item itemToAdd = database.FetchItemByID (id);

		if (itemToAdd.Stackable && CheckIfItemIsInventory (itemToAdd))
		{
			for (int i = 0; i < items.Count; i++) 
			{
				if (items [i].ID == id) 
				{
					ItemData data = slots [i].transform.GetChild (0).GetComponent<ItemData> ();
					data.amount++;
					data.transform.GetChild (0).GetComponent<Text> ().text = data.amount.ToString ();
				}
			}
		} 
		else if (!itemToAdd.Stackable && !CheckIfItemIsInventory (itemToAdd))
		{
			for (int i = 0; i < items.Count; i++) 
			{
				if (items [i].ID == -1) 
				{
					items [i] = itemToAdd;
					GameObject itemObj = Instantiate (inventoryItem);
					itemObj.GetComponent<ItemData> ().item = itemToAdd;
					itemObj.GetComponent<ItemData> ().slot = i;
					itemObj.transform.SetParent (slots[i].transform);
					itemObj.GetComponent<RectTransform> ().anchoredPosition3D = Vector3.zero;
					itemObj.GetComponent<RectTransform>().localScale = Vector3.one;
					itemObj.GetComponent<Image> ().sprite = itemToAdd.Sprite;
					itemObj.name = itemToAdd.Title;

					if (items [i].Stackable) 
					{
						itemObj.GetComponent<ItemData> ().amount++;
						itemObj.transform.GetChild (0).GetComponent<Text> ().text = itemObj.GetComponent<ItemData> ().amount.ToString ();
					}

					break;
				}
			}
		}
	}

	bool CheckIfItemIsInventory(Item item)
	{
		for (int i = 0; i < items.Count; i++) 
		{
			if (items [i].ID == item.ID) 
			{
				return true;
			}
		}
		return false;
	}
}
