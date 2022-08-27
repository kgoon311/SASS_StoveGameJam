using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    //1번이 산, 2번이 해변
    public int itemType;

    private InGameManager inGm;

    private void Start()
    {
        inGm = FindObjectOfType<InGameManager>();
    }

    public void Awarded()
    {
        if (inGm.getItemList.Count >= 8) return;

        inGm.getItemList.Add(gameObject.GetComponent<Item>());
        gameObject.SetActive(false);
    }
}
