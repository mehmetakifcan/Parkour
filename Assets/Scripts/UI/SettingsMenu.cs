using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class SettingsMenu : MonoBehaviour
{

    public AudioMixer audiomixer;

    

    public void SetResoulation(int index)
    {
        if(index==0)
        {
            Screen.SetResolution(1920, 1080,true);
        }
        else if(index==1)
        {
            Screen.SetResolution(1366, 768, true);
        }
        else if (index == 2)
        {
            Screen.SetResolution(1280, 720, true);
        }
    }



    public void SetQuality(int qualityIndex)
    {
        QualitySettings.SetQualityLevel(qualityIndex);
    }

    public void SetFullScreen(bool fullscreen_enable)
    {
        Screen.fullScreen = fullscreen_enable;
    }
    public void SetMouseSensitivity(float value)
    {
        PlayerPrefs.SetFloat("MouseSensitivity", value);
        if (GameObject.FindGameObjectWithTag("Player") != null)
        {
            GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>().mouseSensitivity = value;
        }

    }

    public void SetMasterVolume(float value)
    {
        audiomixer.SetFloat("MasterVolume", value);
    }

    public void SetMusicVolume(float value)
    {
        audiomixer.SetFloat("MusicVolume", value);
    }

}
