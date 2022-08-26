using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(InputComponent))]
[RequireComponent(typeof(MoveComponent))]
[RequireComponent(typeof(Rigidbody))]
public class Character : MonoBehaviour
{
    private InputComponent inputComp;
    private MoveComponent moveComp;
    public Rigidbody myRigid;

    // Start is called before the first frame update
    void Start()
    {
        inputComp = GetComponent<InputComponent>();
        moveComp = GetComponent<MoveComponent>();
    }

    // Update is called once per frame
    void Update()
    {
        CheckCondition();
    }

    //캐릭터의 조건 상태 등을 확인하고 동작시키는 함수
    private void CheckCondition()
    {
        bool isJump = inputComp.jumpAxis > 0.5;
        if (isJump) moveComp.JumpSelf();
    }
}
