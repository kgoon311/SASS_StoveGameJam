using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    //1번이 산, 2번이 해변
    public int itemType;
    public Sprite mySprite;

    private InGameManager inGm;
    private GameManager gm;

    private void Start()
    {
        inGm = FindObjectOfType<InGameManager>();
        gm = GameManager.Instance;
        mySprite = GetComponent<SpriteRenderer>().sprite;
    }

    public void Awarded()
    {
        if (gm.getItemList.Count >= 8) return;

        gm.getItemList.Add(mySprite);
        inGm.UpdateItemSlot();
        if (itemType == gm.Stageidx) inGm.collectItemCount++;
        gameObject.SetActive(false);
    }
}
