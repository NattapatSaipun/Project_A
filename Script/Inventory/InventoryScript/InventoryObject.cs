using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;


[CreateAssetMenu(fileName = "New Inventory",menuName = "Inventory System/Inventory")]
public class InventoryObject : ScriptableObject
{
    public string savePath;
    public ItemDatabaseObject database;
    public Inventory Container;
   

   



    /* private void OnEnable()
     {
 #if UNITY_EDITOR
         database = (ItemDatabaseObject)AssetDatabase.LoadAssetAtPath("Assets/Resources/Database.asset", typeof(ItemDatabaseObject));
         #else
         database =Resources.Load<ItemDatabaseObject>("Database");
 #endif
     }*/
    public bool AddItem(Item _item , int _amount)
    {

       if(EmptySlotCount <= 0)
       return false;

       InventorySlot slot = FindItemOnInventory(_item);
       if(!database.GetItem[_item.Id].stackable || slot == null)
       {
            SetEmptySlot(_item,_amount);
            return true;
       }
       slot.AddAmount(_amount);
       return true;
        
        
        
    }
    public int EmptySlotCount
    {
        get
        {
            int counter = 0;
            for (int i = 0; i < Container.Items.Length; i++)
            {
                if(Container.Items[i].item.Id <= -1)
                {
                    counter++;
                }
            } 
            return counter;
        }
    }
    public InventorySlot FindItemOnInventory(Item _item)
    {
        for (int i = 0; i < Container.Items.Length; i++)
        {
            if(Container.Items[i].item.Id == _item.Id)
            {
                return Container.Items[i];
            }
        }
        return null;
    }

    public InventorySlot SetEmptySlot(Item _item,int _amount)
    {
        for(int i = 0; i < Container.Items.Length ;i++)
        {
            if(Container.Items[i].item.Id <= -1)
            {
                Container.Items[i].UpdateSlot( _item, _amount);
                return Container.Items[i];
            }
        }
        //set up functionality for full inventory
        return null;
    }

    public void SwapItems(InventorySlot item1, InventorySlot item2)
    {
        if(item2.CanPlaceInSlot(item1.ItemObject) && item1.CanPlaceInSlot(item2.ItemObject))
        {
              InventorySlot temp = new InventorySlot( item2.item, item2.amount);
              item2.UpdateSlot( item1.item, item1.amount);
              item1.UpdateSlot( temp.item, temp.amount);
        }
      
    }

    public void RemoveItem(Item _item)
    {
        for(int i = 0; i < Container.Items.Length; i++)
        {
            if(Container.Items[i].item ==  _item)
            {
                Container.Items[i].UpdateSlot( null,0);
            }
        }
    }
   
    [ContextMenu("Save")]
    public void Save()
    {
        string saveData = JsonUtility.ToJson(this, true);
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(string.Concat(Application.persistentDataPath,savePath));
        bf.Serialize(file, saveData);
        file.Close();

        // IFormatter formatter = new BinaryFormatter();
        // Stream stream =  new FileStream(string.Concat(Application.persistentDataPath,savePath),FileMode.Create,FileAccess.Write);
        // formatter.Serialize(stream,Container);
        // stream.Close();
       
    }
    [ContextMenu("Load")]
    public void Load()
    {
        if(File.Exists(string.Concat(Application.persistentDataPath,savePath)))
        {
            // BinaryFormatter bf = new BinaryFormatter();
            // FileStream file = File.Open(string.Concat(Application.persistentDataPath,savePath), FileMode.Open);
            // JsonUtility.FromJsonOverwrite(bf.Deserialize(file).ToString(),this);
            // Debug.Log(string.Concat(Application.persistentDataPath,savePath));
            // file.Close();

            // IFormatter formatter  = new BinaryFormatter();
            // Stream stream = new FileStream(string.Concat(Application.persistentDataPath,savePath),FileMode.Open,FileAccess.Read);

            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(string.Concat(Application.persistentDataPath,savePath), FileMode.Open);
           //Inventory newContainer = (Inventory)formatter.Deserialize(stream);
           //Inventory newContainer = (Inventory)bf.Deserialize(file);
           JsonUtility.FromJsonOverwrite(bf.Deserialize(file).ToString(),this);
        //    for(int i=0; i < Container.Items.Length; i++)
        //    {
        //         Container.Items[i].UpdateSlot(newContainer.Items[i].ID,newContainer.Items[i].item, newContainer.Items[i].amount);
        //    }
            //stream.Close();
            file.Close();
             
        }
    }
    [ContextMenu("Clear")]
    public void Clear()
    {
        //Container = new Inventory();
        Container.Clear();
    }
    public void Delete()
    {

    
            
        

        string filePath = Application.persistentDataPath + savePath;

        Debug.Log(filePath);
        File.Delete( filePath );
          

        
        //AssetDatabase.Refresh();
         
         
         
         
         
         // if(File.Exists(string.Concat(Application.persistentDataPath,savePath)))
        // {
        //      File.Delete("E:/GameDev Export 2/Gamesave4/My project_Data/resources.assets");
        //       File.Delete(Application.persistentDataPath+"/Inventory.Save");

        //      AssetDatabase.Refresh();

        //      Debug.Log(2);
        // }



        //     string saveData = JsonUtility.ToJson(this, true);
        // if(File.Exists(string.Concat(Application.persistentDataPath,savePath)))
        // {
        //     BinaryFormatter bf = new BinaryFormatter();
        //     FileStream file = File.Open(string.Concat(Application.persistentDataPath,savePath), FileMode.Open);
        //     JsonUtility.FromJsonOverwrite(savedData, this);
        //     file.Close();
        // }

      //JsonUtility.FromJsonOverwrite(savedData, this);
        //File.Delete(savePath);
    }

}

[System.Serializable]
public class Inventory
{
    public InventorySlot[] Items = new InventorySlot[20];
    public void Clear()
    {
        for(int i = 0;i < Items.Length; i++)
        {
            Items[i].RemoveItem();
        }
    }

}

[System.Serializable]
public class InventorySlot
{
    public ItemType[] AllowedItems = new ItemType[0];
    public UserInterface parent;
   
    public Item item;
    public int amount;

    public ItemObject ItemObject
    {
        get
        {
            if(item.Id >= 0)  
            {
                //return parent.inventory.database.GetItem[item.Id];
                return parent.inventory.database.GetItem[item.Id];
            } 
            return null;
        }
    }
     public InventorySlot()
    {
       
        item = new Item();
        amount = 0;
    }
    public InventorySlot(Item _item, int _amount)
    {
        
        item = _item;
        amount = _amount;
    }
    // public void RemoveItem()
    // {
    //     item = new Item();
    //     amount = 0;
    // }
     public void UpdateSlot(Item _item, int _amount)
    {
        
        item = _item;
        amount = _amount;
    }
    public void RemoveItem()
    {
        item = new Item();
        amount = 0;
    }
    public void AddAmount(int value)
    {
        amount += value;
    }
    public bool CanPlaceInSlot(ItemObject _itemObject)
    {
        if(AllowedItems.Length <= 0 || _itemObject == null || _itemObject.data.Id < 0)
        {
            return true;
        }
        for (int i = 0; i < AllowedItems.Length; i++)
        {
            if (_itemObject.type == AllowedItems[i])
            {
                return true;
            }
        }
        return false;
    }
}
