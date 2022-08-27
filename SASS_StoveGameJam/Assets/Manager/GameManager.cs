using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : Singleton<GameManager>
{
    public int Stageidx;
    [Header("Setting")]
    [SerializeField] private GameObject Setting_Panel;

    [Space(3.0f)]
    public bool isPause;

    [Header("Item")]
    //게임 클리어시 정산을 위한 먹은 아이템 목록
    public List<Item> getItemList;

    #region 버튼
    public void ExitButton()
    {
        Application.Quit();
        SoundManager.Instance.PlaySound("Button", SoundType.SFX,3, 1);
    }
    public void TitleButton()
    {
        SceneManager.LoadScene(0);
        SoundManager.Instance.PlaySound("Button", SoundType.SFX, 3, 1);
    }
    public void SettingOpen()
    {
        isPause = true;
        StartCoroutine(C_SettingOpen());
        SoundManager.Instance.PlaySound("Button", SoundType.SFX, 3, 1);
    }
    public void SettingClose()
    {
        isPause = false;
        StartCoroutine(C_SettingClose());
        SoundManager.Instance.PlaySound("Button", SoundType.SFX, 3, 1);
    }
    IEnumerator C_SettingOpen()
    {
        StopCoroutine(C_SettingClose());

        float Panel_Movetimer = 0;
        Vector3 PanelPos = Setting_Panel.transform.localPosition;
        while (Panel_Movetimer < 1)
        {
            Panel_Movetimer += Time.deltaTime *2;
            Setting_Panel.transform.localPosition = Vector3.Lerp(PanelPos, Vector3.zero, Panel_Movetimer);
            yield return null;
        }
    }
    IEnumerator C_SettingClose()
    {
        StopCoroutine(C_SettingOpen());

        float Panel_Movetimer = 0;
        Vector3 PanelPos = Setting_Panel.transform.localPosition;
        while (Panel_Movetimer < 1)
        {
            Panel_Movetimer += Time.deltaTime*2;
            Setting_Panel.transform.localPosition = Vector3.Lerp(PanelPos, Vector3.up * 900, Panel_Movetimer);            
            yield return null;
        }
    }
    #endregion
}
