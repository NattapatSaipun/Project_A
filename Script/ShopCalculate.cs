using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class ShopCalculate : MonoBehaviour
{
    public Text inputField;
    public InventoryObject inventory;
    public GroundItem item;
    public int getAmount;
    public void Showcal()
    {
        
       Debug.Log(inputField.GetComponent<Text>().text);
        //getAmount = int.Parse(inputField.GetComponent<TMP_Text>().text);
        string A = inputField.GetComponent<Text>().text;
       
        Debug.Log(A);
        getAmount =int.Parse(A);
       
        inventory.AddItem(new Item(item.item),getAmount);
        // Destroy(other.gameObject);
        


    }
}
