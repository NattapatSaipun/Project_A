using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class canclebt : MonoBehaviour
{
    public GameObject cal;
    public GameObject calUi;
    public void Close()
    {
        cal.SetActive(false);
        calUi.SetActive(false);
    }
}
