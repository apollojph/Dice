using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Slot : MonoBehaviour, IDropHandler
{

	public int id;

	private Inventory inv;
	private CardManage cardManage;

	void Awake()
	{
		inv = GameObject.Find ("InventoryManager").GetComponent<Inventory> ();
		cardManage = GameObject.Find ("InventoryManager").GetComponent<CardManage> ();
	}

	public void OnDrop(PointerEventData eventData)
	{
		ItemData droppedItem = eventData.pointerDrag.GetComponent<ItemData> ();

		if (inv.items [id].ID == -1) 
		{
			inv.items [droppedItem.slot] = new Item ();
			inv.items [id] = droppedItem.item;

			droppedItem.slot = id;

			print ("-1");
		} 
		else if (droppedItem.slot != id) 
		{
			if (transform.parent.name == "CardManagePanel") 
			{
				SetCard (droppedItem, eventData.pointerDrag);
			} 
			else 
			{
				Transform item = this.transform.GetChild (0);
				item.GetComponent<ItemData> ().slot = droppedItem.slot;
				item.transform.SetParent (inv.slots[droppedItem.slot].transform);
				item.transform.position = inv.slots [droppedItem.slot].transform.position;

				droppedItem.slot = id;
				droppedItem.transform.SetParent (this.transform);
				droppedItem.transform.position = this.transform.position;

				print ("change pos");
			}
		}
		else if (transform.parent.name == "CardManagePanel") 
		{
			SetCard (droppedItem, eventData.pointerDrag);
		} 

	}

	void SetCard(ItemData droppedItem, GameObject itemObject)
	{
		if (GameManager.cardManaged < 3) 
		{
            /*
			droppedItem.amount--;
			droppedItem.transform.GetChild (0).GetComponent<Text> ().text = droppedItem.amount.ToString();
            */

			GameObject useCardsIns = Instantiate (itemObject) as GameObject;
			useCardsIns.transform.SetParent (cardManage.slots[GameManager.cardManaged].transform);
			useCardsIns.transform.position = cardManage.slots [GameManager.cardManaged].transform.position;
			useCardsIns.GetComponent<RectTransform>().localScale = Vector3.one;

			//useCardsIns.transform.GetChild (0).GetComponent<Text> ().text = "";

			GameManager.useCardName[GameManager.cardManaged] = useCardsIns.GetComponent<Image> ().sprite.name;
			GameManager.cardManaged++;

			print ("Card manage");
		}
	}
}
