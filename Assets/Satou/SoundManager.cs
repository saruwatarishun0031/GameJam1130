using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using DG.Tweening;

/// <summary>
/// �Q�[�����̃T�E���h���Ǘ�����T�E���h�}�l�[�W���[
/// </summary>
public class SoundManager : MonoBehaviour
{
    public static SoundManager Instance;

    [Serializable]
    public struct SoundData
    {
        public string key;
        public AudioClip clip;
        public float volume;
    }

    [SerializeField] SoundData[] _soundDatas;
    [SerializeField] float _distance;

    float _lastTime;
    AudioSource[] _sources = new AudioSource[10];
    Dictionary<string, SoundData> _dic;

    void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
            //DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

        _dic = new Dictionary<string, SoundData>();
        foreach(SoundData data in _soundDatas)
            _dic.Add(data.key, data);

        for(int i = 0; i < _sources.Length; i++)
        {
            _sources[i] = gameObject.AddComponent<AudioSource>();
        }
    }

    /// <summary>
    /// �O�����特��炷�Ƃ��͂��̃��\�b�h���Ă�
    /// </summary>
    /// <param name="key">���ɑΉ�����L�[</param>
    public void Play(string key)
    {
        if (_dic.TryGetValue(key, out SoundData data))
        {
            if (Time.realtimeSinceStartup - _lastTime < _distance) return;
            _lastTime = Time.realtimeSinceStartup;

            if (key.IndexOf("BGM_") >= 0)
                PlayBGM(data);
            else
                PlaySE(data);
        }
        else
        {
            Debug.LogWarning("�����o�^����Ă��܂���: " + key);
        }
    }
    
    /// <summary>
    /// �O������BGM���~�߂�Ƃ��͂��̃��\�b�h���Ă�
    /// </summary>
    /// <param name="duration">�t�F�[�h�ɂ����鎞��</param>
    public void FadeOutBGM(float duration = 0.5f) => _sources[_sources.Length - 1].DOFade(0, duration);

    void PlayBGM(SoundData data)
    {
        AudioSource source = _sources[_sources.Length - 1];
        if(source == null)
        {
            Debug.LogWarning("����点�܂���ł����BAudioSource������܂���");
            return;
        }
        source.clip = data.clip;
        source.volume = data.volume;
        source.Play();
    }

    void PlaySE(SoundData data)
    {
        AudioSource source = GetAudioSource();
        source.clip = data.clip;
        source.volume = data.volume;
        source.loop = true;
        source.Play();
    }

    AudioSource GetAudioSource()
    {
        for (int i = 0; i < _sources.Length - 1; i++)
        {
            if (!_sources[i].isPlaying)
                return _sources[i];
        }
        return null;
    }
}
