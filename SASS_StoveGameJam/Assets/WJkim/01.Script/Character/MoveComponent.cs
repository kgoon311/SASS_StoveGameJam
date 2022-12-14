using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveComponent : MonoBehaviour
{
    //전방으로 지속적으로 이동, 속도
    [SerializeField] private float moveSpeed;
    //점프 높이
    [SerializeField] private float jumpSpeed;

    //캐릭터 참조
    private Character myCharacter;

    private GameManager gm;

    // Start is called before the first frame update
    void Start()
    {
        myCharacter = GetComponent<Character>();
        gm = GameManager.Instance;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        MoveToFront();
    }

    //오른쪽(정면)방향으로 지속적으로 이동시키는 함수
    private void MoveToFront()
    {
        bool isCanMove = myCharacter.currentHp > 0 && !myCharacter.inGm.isClear && !gm.isPause && !myCharacter.isHited;
        if (isCanMove) transform.Translate(Vector2.right * moveSpeed * Time.deltaTime, Space.World);
    }

    //점프
    public void JumpSelf()
    {
        bool isCanMove = myCharacter.currentHp > 0 && !myCharacter.inGm.isClear && !gm.isPause && !myCharacter.isHited && myCharacter.isGrounded;
        if (isCanMove)
        {
            myCharacter.myRigid.velocity = new Vector3(0, jumpSpeed, 0);
            AudioClipManager.Instance.PlaySFX("jump");
        }
    }
}
