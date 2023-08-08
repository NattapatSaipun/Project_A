using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopText : MonoBehaviour
{
    public Text title;
    public GunShopButton bt;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
      
             title.GetComponent<Text>().text =  bt.a +"Amount = "+ bt.b; 
       
    }
}
