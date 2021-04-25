using System;
using System.Collections.Generic;
using ImportedTools;
using UnityEngine;
using Random = UnityEngine.Random;

[RequireComponent(typeof(AudioSource))]
public class AudioManager : Singleton<AudioManager>
{
    public AudioSource sfxAudioSource;
    public AudioSource musicAudioSource;

    private bool MuteMusic
    {
        get
        {
            return PlayerPrefs.GetInt("MuteMusic", 0) == 1;
        }
        set
        {
            PlayerPrefs.SetInt("MuteMusic", value ? 1 : 0);
        }
    }

    void Awake()
    {
        musicAudioSource.volume = MuteMusic ? 0 : .3f;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.M))
        {
            ToggleMusicSound();
        }
    }

    public Dictionary<AudioClip, DateTime> lastPlayed = new Dictionary<AudioClip, DateTime>();
    [SerializeField] private int MinMillisecondsBetweenSameAudioClip;
    private static float randomSFXAmount = .1f;

    public static void PlayOneShot(AudioClip ac)
    {
        if (AudioClipPlayedTooRecently(ac))
            return;
        Instance.lastPlayed[ac] = DateTime.Now;
        if (!Instance.sfxAudioSource.isPlaying)
            Instance.sfxAudioSource.pitch = 1.0f + Random.Range(-randomSFXAmount, randomSFXAmount);
        
        Instance.sfxAudioSource.PlayOneShot(ac);
    }

    private static bool AudioClipPlayedTooRecently(AudioClip ac)
    {
        if (!Instance.lastPlayed.ContainsKey(ac))
            return false;
        return Instance.lastPlayed[ac] > DateTime.Now - TimeSpan.FromMilliseconds(Instance.MinMillisecondsBetweenSameAudioClip);
    }

    public void ToggleMusicSound()
    {
        MuteMusic = !MuteMusic;
        Instance.musicAudioSource.volume = MuteMusic ? 0 : .3f;
    }

}