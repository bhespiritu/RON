using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class VolumeManager
{

    public delegate void VolumeChangeEvent();
    public static event VolumeChangeEvent OnVolumeChange;
    public static event VolumeChangeEvent OnMusicVolumeChange;
    public static event VolumeChangeEvent OnSFXVolumeChange;


    private static float _masterVolume = 1;
    private static float _sfxVolume = 1;
    private static float _musicVolume = 1;
    public static float masterVolume
    {
        get
        {
            return _masterVolume;
        }
        set
        {
            OnVolumeChange?.Invoke();
            _masterVolume = value;
            Debug.Log("New Master Volume:" + masterVolume);
        }
    }
    public static float sfxVolume
    {
        get
        {
            return _sfxVolume;
        }
        set
        {
            
            OnSFXVolumeChange?.Invoke();
            _sfxVolume = value;
            Debug.Log("New SFX Volume:" + sfxVolume);
        }
    }
    public static float musicVolume
    {
        get
        {
            return _musicVolume;
        }
        set
        {
            
            OnMusicVolumeChange?.Invoke();
            _musicVolume = value;
            Debug.Log("New Music Volume:" + musicVolume);
        }
    }

    static VolumeManager()
    {
        OnVolumeChange += triggerSFX;
        OnVolumeChange += triggerMusic;
    }

    private static void triggerSFX()
    {
        OnSFXVolumeChange?.Invoke();
    }

    private static void triggerMusic()
    {
        OnMusicVolumeChange?.Invoke();
    }
    public static float sfxVal
    {
        get
        {
            return masterVolume * sfxVolume;
        }
    }

    public static float musicVal
    {
        get
        {
            return masterVolume * musicVolume;
        }
    }
     
    
}
