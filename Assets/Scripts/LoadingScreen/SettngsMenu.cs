using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
public class SettngsMenu : MonoBehaviour
{
    public TMP_Dropdown resolutionDropdown;
    public AudioMixer audioMixer;
    Resolution[] resolutions;
    public Image volumeImage;
    public Sprite volumeON;
    public Sprite volumeOFF;
    public Slider slider;
    private void Start()
    {
        resolutions= Screen.resolutions;
        resolutionDropdown.ClearOptions();
        List<string> options = new List<string>();
        int currentResolutionIndex = 0;

        for(int i = 0; i < resolutions.Length; i++)
        {
            string option = resolutions[i].width + "x" + resolutions[i].height;
            options.Add(option);
            if(resolutions[i].width== Screen.currentResolution.width && resolutions[i].height == Screen.currentResolution.height)
            {
                currentResolutionIndex = i; 
            }
        }

        resolutionDropdown.AddOptions(options);      
        resolutionDropdown.value = currentResolutionIndex;
        resolutionDropdown.RefreshShownValue();
    }
    public void SetResolution(int resolutionIndex)
    {
        Resolution resolution = resolutions[resolutionIndex];
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
    } 
    public void SetVolume(float volume)
    {
        audioMixer.SetFloat("Volume", volume);
        if (volume == -80f)
            volumeImage.sprite = volumeOFF;
        else
            volumeImage.sprite = volumeON;
    }
    public void SetQuality(int qualityIndex)
    {
        QualitySettings.SetQualityLevel(qualityIndex);
    }
    public void SetFullScreen(bool isFullScreen)
    {
        Screen.fullScreen = isFullScreen;
    }

    public void Toggle_Changed(bool newValue)
    {
        if (newValue)
        {
            SetVolume(0f);
            slider.value = 0f;
        }
        else
        {
            SetVolume(-80f);
            slider.value = -80f;
        }
    }
}
