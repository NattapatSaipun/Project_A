using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class chesthitbox : MonoBehaviour
{
    public float radius = 3f;
    public Transform player;
    public Transform interactItem;
    bool hasIneract = false;
    public GameObject chestUI;
    public GameObject InventUI;

    // Start is called before the first frame update
    void Start()
    {
       chestUI.SetActive(false);
       InventUI.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
         float distance = Vector3.Distance(player.position, interactItem.position);
        if(distance <= radius && !hasIneract)
        {
           //Debug.Log(1);
            if (Input.GetKeyDown(KeyCode.E))
            {
                Debug.Log(2);
               
                hasIneract = true;
                chestUI.SetActive(true);
                InventUI.SetActive(true);
                 Cursor.visible = true;
                 Cursor.lockState = CursorLockMode.None;
            }
            
        }
        if(distance > radius && hasIneract)
        {
             hasIneract = false;
             chestUI.SetActive(false);
             InventUI.SetActive(false);
              Cursor.visible = false;
              Cursor.lockState = CursorLockMode.Locked;
        }
       
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(interactItem.position, radius);
    }
}
