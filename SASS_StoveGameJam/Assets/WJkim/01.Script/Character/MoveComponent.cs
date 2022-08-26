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

    // Start is called before the first frame update
    void Start()
    {
        myCharacter = GetComponent<Character>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        MoveToFront();
    }

    //오른쪽(정면)방향으로 지속적으로 이동시키는 함수
    private void MoveToFront()
    {
        transform.Translate(Vector2.right * moveSpeed * Time.deltaTime, Space.World);
    }

    //점프
    public void JumpSelf()
    {
        myCharacter.myRigid.AddForce(Vector2.up * jumpSpeed * Time.deltaTime, ForceMode2D.Impulse);
    }
}
