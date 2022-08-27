using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ending : MonoBehaviour
{
    [SerializeField] List<GameObject> ItemObjects = new List<GameObject>();//보급품 오브젝트
    private List<Item> ItemList = new List<Item>();
    private int ItemIdx;
    void Start()
    {
        StartCoroutine(MoveUp());
        foreach (GameObject Item in ItemObjects)
        {
            ItemIdx++;
            Item.GetComponent<SpriteRenderer>().sprite = null;
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
    IEnumerator MoveUp()
    {
        float Uptimer = 0;
        Rigidbody2D FloorRG = GetComponent<Rigidbody2D>();
        while (Uptimer < 1)
        {
            Uptimer += Time.deltaTime * 2;
            FloorRG.velocity = Vector3.up * 20;

            yield return null;
        }
        FloorRG.velocity = Vector2.zero;
    }
}
