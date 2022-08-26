using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public enum SoundType
{
    SFX,
    BGM
}
public class SoundManager : Singleton<SoundManager>
{
    Dictionary<string, AudioClip> sounds = new Dictionary<string, AudioClip>();
    Dictionary<SoundType, float> Volumes = new Dictionary<SoundType, float>() { { SoundType.SFX, 1 }, { SoundType.BGM, 1 } };
    Dictionary<SoundType, AudioSource> AudioSources = new Dictionary<SoundType, AudioSource>();

    [SerializeField] Slider BGMSlider;
    [SerializeField] Slider SFXSlider;

    protected override void Awake()
    {
        base.Awake();
        GameObject Se = new GameObject();
        Se.transform.parent = transform;
        Se.AddComponent<AudioSource>();
        AudioSources[SoundType.SFX] = Se.GetComponent<AudioSource>();

        GameObject Bgm = new GameObject();
        Bgm.transform.parent = transform;
        Bgm.AddComponent<AudioSource>().loop = true;
        AudioSources[SoundType.BGM] = Bgm.GetComponent<AudioSource>();

        AudioClip[] clips = Resources.LoadAll<AudioClip>("Sound/");
        foreach (AudioClip clip in clips)
            sounds[clip.name] = clip;
    }
    public void PlaySound(string clipName, SoundType ClipType = SoundType.SFX, float Volume = 1, float Pitch = 1)//예시 SoundManager.In.PlaySound("test(음향 파일 이름)", SoundType.SFX or BGM, 1, 1);
    {
        if (ClipType == SoundType.BGM)
        {
            AudioSources[SoundType.BGM].clip = sounds[clipName];
            AudioSources[SoundType.BGM].volume = Volume;
            AudioSources[SoundType.BGM].Play();
        }
        else
        {
            AudioSources[ClipType].pitch = Pitch;
            AudioSources[ClipType].PlayOneShot(sounds[clipName], Volume);
        }
    }
    private void Update()
    {
        AudioSources[SoundType.BGM].volume = BGMSlider.value;
        AudioSources[SoundType.SFX].volume = SFXSlider.value;
    }
}
