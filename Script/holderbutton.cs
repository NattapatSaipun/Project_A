using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class holderbutton : MonoBehaviour
{
    public GameObject invent;
   public void OpenInventory()
   {
        invent.SetActive(true);
   }
    public void CloseInventory()
   {
        invent.SetActive(false);
   }
}
