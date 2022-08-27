using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TitleUIManger : MonoBehaviour
{
    private void Start()
    {
        SoundManager.Instance.PlaySound("TitleBGM", SoundType.BGM, 1, 1);
    }
    public void ChangeStage(int stageidx)
    {
        SoundManager.Instance.PlaySound("Button", SoundType.SFX, 3, 1);
        SceneManager.LoadScene("Main");
        GameManager.Instance.Stageidx = stageidx;
        GameManager.Instance.getItemList.Clear();
        GameManager.Instance.collectCount = 0;
        GameManager.Instance.isClear = false;
    }
}
