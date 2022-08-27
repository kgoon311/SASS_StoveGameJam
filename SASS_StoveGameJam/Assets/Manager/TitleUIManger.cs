using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TitleUIManger : MonoBehaviour
{
    private void Start()
    {
        SoundManager.Instance.PlaySound("TitleBGM", SoundType.BGM, 0.6f, 1);
    }
    public void ChangeStage(int stageidx)
    {
        SoundManager.Instance.PlaySound("Button", SoundType.SFX, 1, 1);
        SceneManager.LoadScene("Main");
        GameManager.Instance.Stageidx = stageidx;
        GameManager.Instance.getItemList.Clear();
        GameManager.Instance.collectCount = 0;
        GameManager.Instance.isClear = false;
    }
}
