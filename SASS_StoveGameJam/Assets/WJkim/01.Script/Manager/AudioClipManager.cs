using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioClipManager : Singleton<AudioClipManager>
{
    [SerializeField] private AudioClip[] bgm;
    [SerializeField] private AudioClip[] sfx;
    private GameManager gm;

    // Start is called before the first frame update
    void Start()
    {
        gm = GameManager.Instance;
        string bgmStr = bgm[gm.Stageidx - 1].name;
        SoundManager.Instance.PlaySound(bgmStr, SoundType.BGM, 0.6f, 1);
    }

    public void PlaySFX(string clipName)
    {
        SoundManager.Instance.PlaySound(clipName, SoundType.SFX, 0.6f, 1);
    }
}
