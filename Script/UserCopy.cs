// public abstract class UserInterface : MonoBehaviour
// {
//     public PickupTest player;
    
//     public InventoryObject inventory;

//     public Dictionary<GameObject,InventorySlot> itemsDisplayed = new Dictionary<GameObject,InventorySlot>();
    
//     // Start is called before the first frame update
//     void Start()
//     {
//         CreateSlots();
//         for(int i = 0;i < inventory.Container.Items.Length;i++)
//         {
//             inventory.Container.Items[i].parent = this;
//         }
//     }

//     // Update is called once per frame
//     void Update()
//     {
//         //UpdateDisPlay();
//         UpdateSlot();
//         //Debug.Log(inventory.Container.Items[0].amount);
       

//     }
//     public void UpdateSlot()
//     {
//         foreach(KeyValuePair<GameObject, InventorySlot> _slot in itemsDisplayed)
//         {
//             if(_slot.Value.ID >= 0)
//             {
//                 _slot.Key.transform.GetChild(0).GetComponentInChildren<Image>().sprite = inventory.database.GetItem[_slot.Value.item.Id].uiDisplay;
//                 _slot.Key.transform.GetChild(0).GetComponentInChildren<Image>().color = new Color(1,1,1,1);
//                 _slot.Key.GetComponentInChildren<Text>().text = _slot.Value.amount == 1 ? "" : _slot.Value.amount.ToString("n0");
//             }
//             else
//             {
//                  _slot.Key.transform.GetChild(0).GetComponentInChildren<Image>().sprite = null;
//                 _slot.Key.transform.GetChild(0).GetComponentInChildren<Image>().color = new Color(1,1,1,0);
//                 _slot.Key.GetComponentInChildren<Text>().text = "";
//             }
//         }
//     }

//     // public void UpdateDisPlay()
//     // {
//     //     for(int i = 0; i < inventory.Container.Items.Count; i++)
//     //     {
//     //         InventorySlot slot =  inventory.Container.Items[i];
//     //         if(itemsDisplayed.ContainsKey(slot))
//     //         {
//     //             itemsDisplayed[inventory.Container.Items[i]].GetComponentInChildren<Text>().text = slot.amount.ToString("0");
//     //         }
//     //         else
//     //         {
//     //             var obj = Instantiate(inventoryPrefab, Vector3.zero , Quaternion.identity, transform);
//     //             obj.transform.GetChild(0).GetComponentInChildren<Image>().sprite = inventory.database.GetItem[slot.item.Id].uiDisplay;
//     //             obj.GetComponent<RectTransform>().localPosition = GetPosition(i);
//     //             obj.GetComponentInChildren<Text>().text =  slot.amount.ToString("0");
//     //             itemsDisplayed.Add(inventory.Container.Items[i], obj);
//     //         }
//     //     }
//     // }
//     public abstract void CreateSlots();
//     protected void AddEvent(GameObject obj, EventTriggerType type, UnityAction<BaseEventData> action)
//     {
//         EventTrigger trigger = obj.GetComponent<EventTrigger>();
//         var eventTrigger = new EventTrigger.Entry();
//         eventTrigger.eventID = type; 
//         eventTrigger.callback.AddListener(action);
//         trigger.triggers.Add(eventTrigger);
//     }

//     public void OnEnter(GameObject obj)
//     {
//         player.mouseItem.hoverObj = obj;
//         if(itemsDisplayed.ContainsKey(obj))
//         {
//             player.mouseItem.hoverItem = itemsDisplayed[obj];
//         }
//     }
//     public void OnExit(GameObject obj)
//     {
//         player.mouseItem.hoverObj = null;
//         player.mouseItem.hoverItem = null;
//     }
//     public void OnDragStart(GameObject obj)
//     {
//         var mouseObject = new GameObject();
//         var rt = mouseObject.AddComponent<RectTransform>();
//         rt.sizeDelta = new Vector2(50,50);
//         mouseObject.transform.SetParent(transform.parent);
//         if(itemsDisplayed[obj].ID >= 0)
//         {
//             var img =  mouseObject.AddComponent<Image>();
//             img.sprite = inventory.database.GetItem[itemsDisplayed[obj].ID].uiDisplay;
//             img.raycastTarget = false;
//         }
//         player.mouseItem.obj = mouseObject;
//         player.mouseItem.item = itemsDisplayed[obj];

//     }
//     public void OnDragEnd(GameObject obj)
//     {
//         // var itemOnmouse = player.mouseItem;
//         // var mouseHoverItem = itemOnmouse.hoverItem;
//         // var mouseHoverObj = itemOnmouse.hoverObj;
//         // var get 
        
//         if(player.mouseItem.hoverObj)
//         {
//             inventory.MoveItem(itemsDisplayed[obj],player.mouseItem.hoverItem.parent.itemsDisplayed[player.mouseItem.hoverObj]);
//         }
//         else
//         {
//             inventory.RemoveItem(itemsDisplayed[obj].item);
//         }
//         Destroy(player.mouseItem.obj);
//         player.mouseItem.item = null;
//     }
//     public void OnDrag(GameObject obj)
//     {
//         if(player.mouseItem.obj != null)
//         {
//             player.mouseItem.obj.GetComponent<RectTransform>().position = Input.mousePosition;
//         }
//     }
   
// }
// public class MouseItem
// {
//     public GameObject obj;
//     public InventorySlot item;
//     public InventorySlot hoverItem;
//     public GameObject hoverObj;

// }
