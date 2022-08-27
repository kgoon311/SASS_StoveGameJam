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
        GameManager.Instance.Stageidx = stageidx;
        SoundManager.Instance.PlaySound("Button", SoundType.SFX, 3, 1);
    }
}
