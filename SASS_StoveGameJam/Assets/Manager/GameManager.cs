using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : Singleton<GameManager>
{
    [Header("Setting")]
    [SerializeField] private GameObject Setting_Panel;
    [SerializeField] private Button Setting_Open_Button;
    [SerializeField] private Button Setting_Close_Button;
    void Update()
    {
        
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
        while(Panel_Movetimer < 1)
        {
            Panel_Movetimer += Panel_Movetimer * 2;
            Setting_Panel.transform.position = Vector3.Lerp(transform.position, Vector3.zero, Panel_Movetimer);
            yield return null;
        }
    }
    IEnumerator C_SettingClose()
    {
        StopCoroutine(C_SettingOpen());

        float Panel_Movetimer = 0;
        while (Panel_Movetimer < 1)
        {
            Panel_Movetimer += Panel_Movetimer * 2;
            Setting_Panel.transform.position = Vector3.Lerp(transform.position, Vector3.up * 900, Panel_Movetimer);
            yield return null;
        }
    }

}
