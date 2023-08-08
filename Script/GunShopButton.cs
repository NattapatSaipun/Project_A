using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GunShopButton : MonoBehaviour
{
    public GameObject cal;
    public Text title;
    public string a;
    public int b ;
     public StaticInterface staInterface;
   public int slot;
   public GameObject calUI;
  void Start()
  {
    a = staInterface.inventory.Container.Items[slot].item.Name;
     b = staInterface.inventory.Container.Items[slot].amount;
     
  }

  public void OpenCal()
  {
    cal.SetActive (true);
    calUI.SetActive(true);
     
  }
 
 
}
