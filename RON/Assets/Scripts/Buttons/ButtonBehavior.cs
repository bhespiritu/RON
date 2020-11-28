using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement; 

public class ButtonBehavior : MonoBehaviour
{

    public Slider masterVolumeSlider;
    public Slider sfxVolumeSlider;
    public Slider musicVolumeSlider;

    void Start()
    {
        masterVolumeSlider.onValueChanged.AddListener(delegate { UpdateMasterVolume(); });
        sfxVolumeSlider.onValueChanged.AddListener(delegate { UpdateSFXVolume(); });
        musicVolumeSlider.onValueChanged.AddListener(delegate { UpdateMusicVolume(); });


        masterVolumeSlider.value = VolumeManager.masterVolume;
        sfxVolumeSlider.value = VolumeManager.sfxVolume;
        musicVolumeSlider.value = VolumeManager.musicVolume;
    }
    void Update(){
       
    }

    public void MainMenu()
    {
        // Your code here
        Destroy(Player.playerInstance);
        SceneManager.LoadScene(0);
    }
    public void Tutorial(){
        SceneManager.LoadScene(1); 
    }
    public void Play()
    {
        // Your code here
        SceneManager.LoadScene(5);
    }
    public void Quit(){
    	Application.Quit(); 
    }

    

    public void UpdateMasterVolume()
    {
        VolumeManager.masterVolume = masterVolumeSlider.value;
    }

    public void UpdateSFXVolume()
    {
        VolumeManager.sfxVolume = sfxVolumeSlider.value;
    }

    public void UpdateMusicVolume()
    {
        VolumeManager.musicVolume = musicVolumeSlider.value;
    }


}
