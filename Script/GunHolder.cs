using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunHolder : MonoBehaviour
{
 public StaticInterface staInterface;
 public GameObject gun;
 
 void Update()
 {
    string a = staInterface.inventory.Container.Items[2].item.Name;

    
    if(a == "AK-47")
    {
        gun.SetActive(true);
    }
    else{
        gun.SetActive(false);
    }
 }
       
}
