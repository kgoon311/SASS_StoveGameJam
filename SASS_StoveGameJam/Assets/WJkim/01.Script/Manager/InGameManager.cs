using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class InGameManager : MonoBehaviour
{
    //TODO : 게임매니저 산, 해변 변수 정해지면 받아와서 Resources폴더의 리소스로 바닥 이미지 변경

    //재시작시 캐릭터 원위치용 시작위치
    private Vector2 characterStartPoint;
    //스테이지에 맞는 아이템 획득 수
    public int collectItemCount = 0;
    //캐릭터 참조_배경 재상용을 위해 캐릭터와의 거리 측정에 사용
    [SerializeField] private Character character;

    [Header("Background")]   
    //반복 사용할 배경이미지 위치와 바닥 위치
    [SerializeField] private Transform[] backgroundImg;
    private int moveImgIndex = 0;
    [SerializeField] private Transform[] ground;
    private int movePlatIndex = 0;

    [Header("UI")]
    //hp바 ui
    [SerializeField] private Image hpImg;
    [SerializeField] private Text hpText;
    //화면에 먹은 아이템 표기할 아이템 슬롯
    public Image[] itemSlotImgs;

    [Header("Items")]
    //재시작시 다시 사용하기 위한 아이템 목록 -> 해변과 산 모두 받아둘까?
    [SerializeField] private Item[] items;

    [Header("Field")]
    //맵 종류에 따른 아이템과 장애물 선택에 사용_맵에 맞는 쪽을 활성화
    [SerializeField] private GameObject oceanObstacles;
    [SerializeField] private GameObject mountainObstacles;
    [SerializeField] private GameObject oceanItems;
    [SerializeField] private GameObject mountainItems;

    //맵의 끝 지점
    [SerializeField] private Transform endPoint;

    //게임매니저_선택한 맵의 종류 받아오기위함
    private GameManager gm;

    public bool isClear= false;

    // Start is called before the first frame update
    void Start()
    {
        characterStartPoint = character.transform.position;
        gm = GameManager.Instance;

        //선택한 맵 종류에 따라 이미지 변경
        SelectMapType();
    }

    // Update is called once per frame
    void Update()
    {
        FlowPage();
        UpdateHpBar();
        CheckClearGame();
    }

    public void UpdateItemSlot()
    {
        for(int i = 0; i<gm.getItemList.Count; i++)
        {
            itemSlotImgs[i].sprite = gm.getItemList[i].GetComponent<SpriteRenderer>().sprite;
        }
    }

    //맵 배경 변경함수
    private void SelectMapType()
    {
        //산
        if (gm.Stageidx == 1)
        {
            for (int i = 0; i < backgroundImg.Length; i++)
            {
                backgroundImg[i].GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Background/Mountain");
                //바닥 변경
            }
            oceanObstacles.SetActive(false);
            oceanItems.SetActive(false);
            mountainObstacles.SetActive(true);
            mountainItems.SetActive(true);
        }
        //바다
        else if (gm.Stageidx == 2)
        {
            for (int i = 0; i < backgroundImg.Length; i++)
            {
                backgroundImg[i].GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Background/Ocean");
                //바닥 변경
            }
            oceanObstacles.SetActive(true);
            oceanItems.SetActive(true);
            mountainObstacles.SetActive(false);
            mountainItems.SetActive(false);
        }
    }

    private void CheckClearGame()
    {
        if(character.transform.position.x > endPoint.position.x)
        {
            isClear = true;
            gm.isClear = true;
            SceneManager.LoadScene("Ending");
        }
        else
        {
            isClear = false;
        }
    }

    //체력바 ui갱신
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
        //캐릭터 위치 초기화
        character.transform.position = characterStartPoint;
        //아이템 활성화
        for(int i = 0; i<items.Length; i++)
        {
            items[i].gameObject.SetActive(true);
        }
        //체력 회복
        character.currentHp = character.maxHp;
        //먹은 아이템 목록 초기화
        gm.getItemList.Clear();
        collectItemCount = 0;
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
