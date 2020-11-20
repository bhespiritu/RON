using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageAudio : MonoBehaviour
{
    private AudioSource source;
    private float currentMaxVolume;

    private void Awake()
    {
        source = GetComponent<AudioSource>();
        currentMaxVolume = source.volume;
        source.volume = VolumeManager.musicVal * currentMaxVolume;
        
    }

    private void OnEnable()
    {
        VolumeManager.OnMusicVolumeChange += updateVolume;
    }

    private void OnDisable()
    {
        VolumeManager.OnMusicVolumeChange -= updateVolume;
    }

    private void OnDestroy()
    {
        VolumeManager.OnMusicVolumeChange -= updateVolume;
    }

    private void updateVolume()
    {
        source.volume = VolumeManager.musicVal * currentMaxVolume;
    }


}
