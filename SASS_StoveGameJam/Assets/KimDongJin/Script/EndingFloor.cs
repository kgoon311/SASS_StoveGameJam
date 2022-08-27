using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ending : MonoBehaviour
{
    [SerializeField] GameObject PushFloor;//보급품 오브젝트를 위로 밀어주는 오브젝트
    [SerializeField] List<GameObject> contents = new List<GameObject>();
    void Start()
    {
        StartCoroutine(MoveUp());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    IEnumerator MoveUp()
    {
        float Uptimer = 0;
        Rigidbody2D FloorRG = GetComponent<Rigidbody2D>();
        while(Uptimer < 1)
        {
            Uptimer += Time.deltaTime*2;
            FloorRG.velocity = Vector3.up*20;

            yield return null;
        }
        FloorRG.velocity = Vector2.zero;
    }
}
