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
    Dictionary<string, AudioClip> sounds = new Dictionary<string, AudioClip>();//Sound폴더 안에 음원들을 담는 변수
    Dictionary<SoundType, float> Volumes = new Dictionary<SoundType, float>() { { SoundType.SFX, 1 }, { SoundType.BGM, 1 } };//볼륨(효과음과 배경을 따로 받음) 
    Dictionary<SoundType, AudioSource> AudioSources = new Dictionary<SoundType, AudioSource>();//효과음과 배경음을 실행시킬 오디오소스 컴퍼넌트

    [SerializeField] Slider BGMSlider;
    [SerializeField] Slider SFXSlider;

    protected override void Awake()
    {
        base.Awake();
        GameObject SFX = new GameObject();//효과음을 실행시키는 오브젝트
        SFX.transform.parent = transform;//자식으로 넣기
        SFX.AddComponent<AudioSource>();//오디오소스 컴퍼넌트 적용
        AudioSources[SoundType.SFX] = SFX.GetComponent<AudioSource>();//딕셔너리 변수에 넣어주기

        GameObject Bgm = new GameObject();//배경음을 실행시키는 오브젝트
        Bgm.transform.parent = transform;//자식으로 넣기
        Bgm.AddComponent<AudioSource>().loop = true;//오디오소스 컴퍼넌트 적용 배경음 이므로 루프 true
        AudioSources[SoundType.BGM] = Bgm.GetComponent<AudioSource>();//딕셔너리 변수에 넣어주기

        AudioClip[] clips = Resources.LoadAll<AudioClip>("Sound/");//사운트 폴더안 오디오클립을 모두 가져오기
        foreach (AudioClip clip in clips)
            sounds[clip.name] = clip;
    }
    public void PlaySound(string clipName, SoundType ClipType = SoundType.SFX, float Volume = 1, float Pitch = 1)//예시 SoundManager.In.PlaySound("test(음향 파일 이름)", SoundType.SFX or BGM, 1, 1);
    {
        if (ClipType == SoundType.BGM)
        {
            AudioSources[SoundType.BGM].clip = sounds[clipName];
            Volumes[SoundType.BGM] = Volume;
            AudioSources[SoundType.BGM].Play();
        }
        else
        {
            AudioSources[ClipType].pitch = Pitch;
            Volumes[SoundType.SFX] = Volume;
            AudioSources[ClipType].PlayOneShot(sounds[clipName], Volumes[SoundType.SFX] * SFXSlider.value);
        }
    }
    private void Update()
    {
        AudioSources[SoundType.BGM].volume = Volumes[SoundType.BGM] * BGMSlider.value;
    }
}
