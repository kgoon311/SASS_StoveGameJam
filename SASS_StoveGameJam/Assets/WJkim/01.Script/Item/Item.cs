using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    //0번이 산, 1번이 해변
    public int itemType;


    public void Awarded()
    {
        gameObject.SetActive(false);
    }
}
