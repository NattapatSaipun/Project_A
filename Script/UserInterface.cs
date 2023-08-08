using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;



public abstract class UserInterface : MonoBehaviour
{
   
    
    public InventoryObject inventory;

    public Dictionary<GameObject,InventorySlot> slotOnInterface = new Dictionary<GameObject,InventorySlot>();
    
    // Start is called before the first frame update
    void Start()
    {
        CreateSlots();
        for(int i = 0;i < inventory.Container.Items.Length;i++)
        {
            inventory.Container.Items[i].parent = this;
        }
        
        AddEvent(gameObject, EventTriggerType.PointerEnter, delegate {OnEnterInterface(gameObject);});
        AddEvent(gameObject, EventTriggerType.PointerExit, delegate {OnExitInterface(gameObject);});
    }

    // Update is called once per frame
    void Update()
    {
        //UpdateDisPlay();
        UpdateSlot();
        //Debug.Log(inventory.Container.Items[0].amount);
       

    }
    public void UpdateSlot()
    {
        foreach(KeyValuePair<GameObject, InventorySlot> _slot in slotOnInterface)
        {
            if(_slot.Value.item.Id >= 0)
            {
                _slot.Key.transform.GetChild(0).GetComponentInChildren<Image>().sprite = _slot.Value.ItemObject.uiDisplay;//inventory.database.GetItem[_slot.Value.item.Id].uiDisplay;
                _slot.Key.transform.GetChild(0).GetComponentInChildren<Image>().color = new Color(1,1,1,1);
                _slot.Key.GetComponentInChildren<Text>().text = _slot.Value.amount == 1 ? "" : _slot.Value.amount.ToString("n0");
            }
            else
            {
                 _slot.Key.transform.GetChild(0).GetComponentInChildren<Image>().sprite = null;
                _slot.Key.transform.GetChild(0).GetComponentInChildren<Image>().color = new Color(1,1,1,0);
                _slot.Key.GetComponentInChildren<Text>().text = "";
            }
        }
    }

    // public void UpdateDisPlay()
    // {
    //     for(int i = 0; i < inventory.Container.Items.Count; i++)
    //     {
    //         InventorySlot slot =  inventory.Container.Items[i];
    //         if(itemsDisplayed.ContainsKey(slot))
    //         {
    //             itemsDisplayed[inventory.Container.Items[i]].GetComponentInChildren<Text>().text = slot.amount.ToString("0");
    //         }
    //         else
    //         {
    //             var obj = Instantiate(inventoryPrefab, Vector3.zero , Quaternion.identity, transform);
    //             obj.transform.GetChild(0).GetComponentInChildren<Image>().sprite = inventory.database.GetItem[slot.item.Id].uiDisplay;
    //             obj.GetComponent<RectTransform>().localPosition = GetPosition(i);
    //             obj.GetComponentInChildren<Text>().text =  slot.amount.ToString("0");
    //             itemsDisplayed.Add(inventory.Container.Items[i], obj);
    //         }
    //     }
    // }
    public abstract void CreateSlots();
    protected void AddEvent(GameObject obj, EventTriggerType type, UnityAction<BaseEventData> action)
    {
        EventTrigger trigger = obj.GetComponent<EventTrigger>();
        var eventTrigger = new EventTrigger.Entry();
        eventTrigger.eventID = type; 
        eventTrigger.callback.AddListener(action);
        trigger.triggers.Add(eventTrigger);
    }

    public void OnEnter(GameObject obj)
    {
        MouseData.slotHoveredOver = obj;
       
    }
    public void OnExit(GameObject obj)
    {
       MouseData.slotHoveredOver = null;
    }
       public void OnEnterInterface(GameObject obj)
    {
        MouseData.interfaceMouseIsOver = obj.GetComponent<UserInterface>();

    }
     public void OnExitInterface(GameObject obj)
    {
        MouseData.interfaceMouseIsOver = null;
    }
    public void OnDragStart(GameObject obj)
    {
        var mouseObject = new GameObject();
        var rt = mouseObject.AddComponent<RectTransform>();
        rt.sizeDelta = new Vector2(50,50);
        mouseObject.transform.SetParent(transform.parent);
       
            var img =  mouseObject.AddComponent<Image>();
            img.sprite = slotOnInterface[obj].ItemObject.uiDisplay;//inventory.database.GetItem[slotOnInterface[obj].item.Id].uiDisplay;
            img.raycastTarget = false;
        
         MouseData.tempItemBeingDragging = mouseObject;
        

    }
    public void OnDragEnd(GameObject obj)
    {
        

        Destroy(MouseData.tempItemBeingDragging);
        if(MouseData.interfaceMouseIsOver == null)
        {
            slotOnInterface[obj].RemoveItem();
            return;
        }
        if(MouseData.slotHoveredOver)
        {
            InventorySlot mouseHoverSlotData = MouseData.interfaceMouseIsOver.slotOnInterface[MouseData.slotHoveredOver];
            inventory.SwapItems(slotOnInterface[obj], mouseHoverSlotData);
        }

       
    }
    public void OnDrag(GameObject obj)
    {
        if(MouseData.tempItemBeingDragging != null)
        {
            MouseData.tempItemBeingDragging.GetComponent<RectTransform>().position = Input.mousePosition;
        }
    }
   
}
public static class MouseData
{
    public static UserInterface interfaceMouseIsOver;
    public static GameObject tempItemBeingDragging;
    public static GameObject slotHoveredOver;

}
