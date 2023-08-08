using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupTest : MonoBehaviour
{
   private void Awake()
   {
        inventory[0].Container.Clear();
        inventory[1].Container.Clear();
        inventory[2].Container.Clear();
        inventory[3].Container.Clear();
        
   }
   //public MouseItem mouseItem = new MouseItem();
    public InventoryObject[] inventory;
    // Start is called before the first frame update
   public void OnTriggerEnter(Collider other)
   {
     var item = other.GetComponent<GroundItem>();
     if(item)
     {
        inventory[0].AddItem(new Item(item.item),1);
        Destroy(other.gameObject);
     }
   }
   private void Update()
   {
      

      if(Input.GetKeyDown(KeyCode.O))
      {
            inventory[0].Save();
            inventory[1].Save();
            inventory[2].Save();
            inventory[3].Save();
      }
      if(Input.GetKeyDown(KeyCode.P))
      {
            inventory[0].Load();
            inventory[1].Load();
            inventory[2].Load();
            inventory[3].Load();
      }
      if(Input.GetKeyDown(KeyCode.M))
      {
         inventory[0].Delete();
         inventory[1].Delete();
         inventory[2].Delete();
         inventory[3].Delete();
      }
   }

   private void OnApplicationQuit()
   {
        inventory[0].Container.Clear();
        inventory[1].Container.Clear();
        inventory[2].Container.Clear();
        inventory[3].Container.Clear();
        
   }
}
