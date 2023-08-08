using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunShop : MonoBehaviour
{
   public StaticInterface staInterface;
   public int slot;
   //public InventoryObject inventory;
 
 
 void Update()
 {
    string a = staInterface.inventory.Container.Items[slot].item.Name;
    int b = staInterface.inventory.Container.Items[slot].amount;
    //string a = staInterface.inventory.Container.Items.Length;

   //  if(a == "AK-47")
   //  {
       
   //  }
   //  else{
       
   //  }
 }
}
