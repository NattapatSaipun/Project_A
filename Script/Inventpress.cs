using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventpress : MonoBehaviour
{
    public GameObject inv;

    bool Isopen = false;
    // Start is called before the first frame update
    void Start()
    {
        inv.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
         if(Input.GetKeyDown(KeyCode.Tab))
        {
            if(!Isopen)
            {
                  inv.SetActive(true);
                  Isopen = true;
                  Cursor.visible = true;
                  Cursor.lockState = CursorLockMode.None;
                  
            }
            else
            {
                inv.SetActive(false);
                  Isopen = false;
                  Cursor.visible = false;
                  Cursor.lockState = CursorLockMode.Locked;
                  
            }
          

        }
        if(inv.activeSelf)
        {
            Time.timeScale = 0;
        }else  Time.timeScale = 1;
       
    }
}
