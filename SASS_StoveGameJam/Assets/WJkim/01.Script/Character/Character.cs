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
    public InGameManager inGm;
    private GameManager gm;

    //캐릭터 체력, 장애물과 접촉시 10씩 소모
    public int maxHp;
    public int currentHp;

    //지면에 닿아있는지 검사
    private bool isGrounded;

    // Start is called before the first frame update
    void Start()
    {
        inputComp = GetComponent<InputComponent>();
        moveComp = GetComponent<MoveComponent>();
        myRigid = GetComponent<Rigidbody2D>();
        gm = GameManager.Instance;
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
        //점프키 입력받고 지면에 닿아있으면 점프
        bool isJump = inputComp.jumpAxis > 0.5 && isGrounded;
        if (isJump) moveComp.JumpSelf();
        //todo캐릭터 점프 애니메이션

        //캐릭터 채력이 0이하이면 게임 오버
        if(currentHp < 1)
        {
            Debug.Log("게임 오버");
            //todo캐릭터 사망 애니메이션
            //todo게임 오버 화면 출력
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //장애물과 충돌하면 데미지를 입고 점수를 잃는다.
        if (collision.gameObject.tag.CompareTo("Obstacle") == 0)
        {
            currentHp -= collision.GetComponent<Obstacle>().damageValue;
            //todo캐릭터 피격 애니메이션
        }

        if (collision.gameObject.tag.CompareTo("Item") == 0)
        {
            Item itemCollision = collision.GetComponent<Item>();
            itemCollision.Awarded();
            if(itemCollision.itemType != gm.Stageidx) inGm.score -= inGm.scoreUpDownPoint;
            else inGm.score += inGm.scoreUpDownPoint;
            //todo아이템 습득 모션
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        //땅에 접촉해있는 상태
        if (collision.gameObject.tag.CompareTo("Ground") == 0)
        {
            isGrounded = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        //땅에서 뜨워진 상태
        if (collision.gameObject.tag.CompareTo("Ground") == 0)
        {
            isGrounded = false;
        }
    }
}
