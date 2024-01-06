using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Audio;
using UnityEngine.UI;

public class Audiomixerr : MonoBehaviour
{
    public AudioMixer _audioMixer;
    public GameObject window;
    public Slider masterSlider, sfxSlider, musicSlider;
    // Start is called before the first frame update
    void Start()
    {
        if (PlayerPrefs.HasKey("MasterVolume"))
        {
            _audioMixer.SetFloat("MasterVolume", PlayerPrefs.GetFloat("MasterVolume"));
            _audioMixer.SetFloat("SFXVolume", PlayerPrefs.GetFloat("SFXVolume"));
            _audioMixer.SetFloat("MusicVolume", PlayerPrefs.GetFloat("MusicVolume"));

            SetSlider();
        }
        else
        {
            SetSlider();
        }

    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyUp(KeyCode.V))
        {
            window.SetActive(!window.activeInHierarchy); //Hierarchy de neyse tersini yap
            if(window.activeInHierarchy)
            {
                Cursor.lockState = CursorLockMode.None;
            }
            else
            {
                Cursor.lockState = CursorLockMode.Locked;
            }
        }
    }
    
    private void SetSlider()
    {
        // VERÝ KAYDETME:
        masterSlider.value = PlayerPrefs.GetFloat("MasterVolume");
        sfxSlider.value = PlayerPrefs.GetFloat("SFXVolume");
        musicSlider.value = PlayerPrefs.GetFloat("MusicVolume");
    }

    public void UpdateMasterVolume()
    {
        _audioMixer.SetFloat("MasterVolume", masterSlider.value);
        PlayerPrefs.SetFloat("MasterVolume", masterSlider.value);
    }

    public void UpdateSFXVolume()
    {
        _audioMixer.SetFloat("SFXVolume", sfxSlider.value);
        PlayerPrefs.SetFloat("SFXVolume", sfxSlider.value);
    }

    public void UpdateMusicVolume()
    {
        _audioMixer.SetFloat("MusicVolume", sfxSlider.value);
        PlayerPrefs.SetFloat("MusicVolume", sfxSlider.value);
    }
}
