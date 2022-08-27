using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Ending : MonoBehaviour
{
    [Header("sprite")]
    [SerializeField] Sprite TrashImage;
    [SerializeField] Sprite ClearImage;
    [SerializeField] Sprite OverImage;
    [Header("Anime")]
    [SerializeField] GameObject PushFloor;//보급품을 밀어주는 콜라이더
    [SerializeField] GameObject UnderEffect;
    [SerializeField] List<SpriteRenderer> ItemObjects = new List<SpriteRenderer>();//보급품 오브젝트
    [SerializeField] private List<Sprite> ItemList = new List<Sprite>();//먹은 오브젝트 스프라이트
    private int ItemIdx;

    [Header("Finaal_Score")]
    [SerializeField] GameObject ScorePanel;//최종 스코어창 
    [SerializeField] List<Image> Stars = new List<Image>();//별들
    [SerializeField] List<Image> ItemImageObjects = new List<Image>();//먹은 아이템 안내
    void Start()
    {
        ItemList = GameManager.Instance.getItemList;

        StartCoroutine(MoveUp());
        foreach (SpriteRenderer Item in ItemObjects)
        {
            if (ItemList.Count > ItemIdx)
            {                
                Item.sprite = ItemList[ItemIdx];
                ItemIdx++;
            }
            else
            {
                Item.sprite = TrashImage;
            }
        }
    }
    IEnumerator MoveUp()
    {
        float Uptimer = 0;
        Rigidbody2D FloorRG = PushFloor.GetComponent<Rigidbody2D>();
        while (Uptimer < 1)
        {
            Uptimer += Time.deltaTime * 2;
            FloorRG.velocity = Vector3.up * 20;
            yield return null;
        }
        FloorRG.velocity = Vector2.zero;

        UnderEffect.GetComponent<Image>().sprite = (GameManager.Instance.isClear == true) ? ClearImage : OverImage;
        UnderEffect.SetActive(true);
        yield return new WaitForSeconds(3f);
        StartCoroutine(DropScorePanel());
    }
    IEnumerator DropScorePanel()
    {
        ItemIdx = 0;
        foreach (Image Item in ItemImageObjects)
        {
            if (ItemList.Count > ItemIdx)
            {                
                Item.sprite = ItemList[ItemIdx];
                ItemIdx++;
            }
            else
            {
                Item.sprite = TrashImage;
            }
        }
        float MoveTimer = 0;
        while (MoveTimer < 1)
        {
            MoveTimer += Time.deltaTime * 2;
            ScorePanel.transform.localPosition = Vector3.Lerp(ScorePanel.transform.localPosition, Vector3.zero, MoveTimer);
            yield return null;
        }
        for (float i = 0; i < GameManager.Instance.collectCount / 3; i++)
        {
            StartCoroutine(StarColorChange((int)i));
            yield return new WaitForSeconds(0.5f);
        }
        yield return null;
    }
    IEnumerator StarColorChange(int idx)
    {
        float ChangeTimer = 0;
        while (ChangeTimer < 1)
        {
            ChangeTimer += Time.deltaTime;
            Stars[idx].color = new Color(ChangeTimer, ChangeTimer, 0, 1);
            yield return null;
        }
    }

    //버튼 스크립트
    public void Restart()
    {
        GameManager.Instance.getItemList.Clear();
        GameManager.Instance.collectCount = 0;
        GameManager.Instance.isClear = false;
        SceneManager.LoadScene(1);
        SoundManager.Instance.PlaySound("Button", SoundType.SFX, 3, 1);
    }
    public void Title()
    {
        GameManager.Instance.getItemList.Clear();
        GameManager.Instance.collectCount = 0;
        GameManager.Instance.isClear = false;
        SceneManager.LoadScene(0);
        SoundManager.Instance.PlaySound("Button", SoundType.SFX, 3, 1);
    }
}
