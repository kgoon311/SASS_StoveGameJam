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

    #region 버튼
    public void ExitButton()
    {
        Application.Quit();
    }
    public void TitleButton()
    {
        SceneManager.LoadScene(0);
    }
    public void SettingOpen()
    {
        StartCoroutine(C_SettingOpen());
    }
    public void SettingClose()
    {
        StartCoroutine(C_SettingClose());
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
