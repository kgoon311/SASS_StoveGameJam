using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InGameManager : MonoBehaviour
{
    //TODO : 게임매니저 산, 해변 변수 정해지면 받아와서 Resources폴더의 리소스로 배경, 바닥 이미지 변경
    //TODO : 배경 이미지, 바닥 이미지 여유 공간 확보

    //반복 사용할 배경이미지 위치와 바닥 위치
    [SerializeField] private Transform[] backgroundImg;
    private int moveImgIndex = 0;
    [SerializeField] private Transform[] ground;
    private int movePlatIndex = 0;

    //캐릭터 참조_배경 재상용을 위해 캐릭터와의 거리 측정에 사용
    [SerializeField] private Character character;
    //재시작시 캐릭터 원위치용 시작위치
    private Vector2 characterStartPoint;

    //게임 점수
    public int score = 100;
    public int scoreLosePoint = 10;

    //hp바 ui
    [SerializeField] private Image hpImg;
    [SerializeField] private Text hpText;

    //재시작시 다시 사용하기 위한 아이템 목록
    [SerializeField] private Item[] items;

    // Start is called before the first frame update
    void Start()
    {
        characterStartPoint = character.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        FlowPage();
        UpdateHpBar();
    }

    private void UpdateHpBar()
    {
        int currentHp = character.currentHp;
        int maxHp = character.maxHp;
        hpImg.fillAmount = (float)currentHp / maxHp;
        hpText.text = currentHp.ToString() + " / " + maxHp.ToString();
    }

    //게임 재시작
    public void Restart()
    {
        character.transform.position = characterStartPoint;
        for(int i = 0; i<items.Length; i++)
        {
            items[i].gameObject.SetActive(true);
        }
        score = 100;
        character.currentHp = character.maxHp;
    }

    //반복 사용을 위한 배경과 지면 이동
    private void FlowPage()
    {
        //배경 이동_19.5는 임의의 값이라 변경해야 될 수 있음
        float imgCharacterDistance = Vector3.Distance(character.transform.position, backgroundImg[moveImgIndex].position);
        if (imgCharacterDistance > 19.5f)
        {
            backgroundImg[moveImgIndex].position = backgroundImg[moveImgIndex].position + new Vector3(19.18f * 2, 0, 0);
            moveImgIndex = (moveImgIndex == 0) ? 1 : 0;
        }

        float platCharacterDistance = Vector3.Distance(character.transform.position, ground[movePlatIndex].position);
        if (platCharacterDistance > 19.5f)
        {
            ground[movePlatIndex].position = ground[movePlatIndex].position + new Vector3(19.18f * 2, 0, 0);
            movePlatIndex = (movePlatIndex == 0) ? 1 : 0;
        }
    }
}
