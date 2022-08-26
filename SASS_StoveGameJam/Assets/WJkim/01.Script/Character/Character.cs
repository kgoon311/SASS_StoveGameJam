using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(InputComponent))]
[RequireComponent(typeof(MoveComponent))]
[RequireComponent(typeof(Rigidbody2D))]
public class Character : MonoBehaviour
{
    private InputComponent inputComp;
    private MoveComponent moveComp;
    public Rigidbody2D myRigid;

    //지면에 닿아있는지 검사
    private bool isGrounded;

    // Start is called before the first frame update
    void Start()
    {
        inputComp = GetComponent<InputComponent>();
        moveComp = GetComponent<MoveComponent>();
        myRigid = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        //상태 검사 후 동작
        CheckCondition();
    }

    //캐릭터의 조건 상태 등을 확인하고 동작시키는 함수
    private void CheckCondition()
    {
        bool isJump = inputComp.jumpAxis > 0.5 && isGrounded;
        if (isJump) moveComp.JumpSelf();
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.tag.CompareTo("Ground") == 0)
        {
            isGrounded = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag.CompareTo("Ground") == 0)
        {
            isGrounded = false;
        }
    }
}
