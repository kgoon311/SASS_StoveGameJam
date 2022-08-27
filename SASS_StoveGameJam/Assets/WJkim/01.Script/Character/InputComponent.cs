using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputComponent : MonoBehaviour
{
    //점프키 입력 여부 확인(스페이스바)
    public float jumpAxis;

    // Update is called once per frame
    void FixedUpdate()
    {
        GetInput();
    }

    //입력 값들을 받아오는 함수
    void GetInput()
    {
        jumpAxis = Input.GetAxisRaw("Jump");
    }
}
