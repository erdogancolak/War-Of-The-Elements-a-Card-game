using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class OptionsController : MonoBehaviour
{
    [Header("Options Panel")]
    [SerializeField] private GameObject optionsPanel;
    [Header("Toggle Fullscreen / Vsync")]
    [SerializeField] private Toggle fullscreenToggle;
    [SerializeField] private Toggle vsyncToggle;

    [Header("Resolution")]
    [SerializeField] private Button leftResButton;
    [SerializeField] private Button rightResButton;

    [SerializeField] private TMP_Text resolutionsText;
    [SerializeField] private ResItem[] resolutions;
    private int selectedResolutions;

    [Header("Audio Mixer")]
    [SerializeField] private AudioMixer Mixer;
    [SerializeField] private Slider MasterVolumeSlider;
    [SerializeField] private Slider MusicVolumeSlider;
    [SerializeField] private Slider SFXVolumeSlider;

    [Header("Apply - Close")]
    [SerializeField] private Button applyButton;
    [SerializeField] private Button closeButton;


    #region Start
    private void Start()
    {
        selectedResolutions = 0;
        UpdateResolutionText();
    }
    #endregion
    #region Resolution
    public void LeftResolutionButton()
    {
        Animator playAnimator = leftResButton.GetComponent<Animator>();
        playAnimator.SetTrigger("Clicked");
        selectedResolutions--;
        if (selectedResolutions < 0)
        {
            selectedResolutions = 0;
        }
        UpdateResolutionText();
    }

    public void RightResolutionButton()
    {
        Animator playAnimator = rightResButton.GetComponent<Animator>();
        playAnimator.SetTrigger("Clicked");
        selectedResolutions++;
        if (selectedResolutions > resolutions.Length - 1)
        {
            selectedResolutions = resolutions.Length - 1;
        }
        UpdateResolutionText();
    }

    public void UpdateResolutionText()
    {
        resolutionsText.text = $"{resolutions[selectedResolutions].Horizontal.ToString()} X {resolutions[selectedResolutions].Vertical.ToString()}";
    }
    #endregion
    #region Audio Volume Set
    public void MasterVolumeSet()
    {
        Mixer.SetFloat("MasterVol", MasterVolumeSlider.value);
    }

    public void MusicVolumeSet()
    {
        Mixer.SetFloat("MusicVol", MusicVolumeSlider.value);
    }
    public void SFXVolumeSet()
    {
        Mixer.SetFloat("SFXVol", SFXVolumeSlider.value);
    }
    #endregion  
    #region Apply - Close
    public void Apply()
    {
        Animator playAnimator = applyButton.GetComponent<Animator>();
        playAnimator.SetTrigger("Clicked");
        Screen.fullScreen = fullscreenToggle.isOn;

        if (vsyncToggle.isOn)
        {
            QualitySettings.vSyncCount = 1;
        }
        else
        {
            QualitySettings.vSyncCount = 0;
        }
        Screen.SetResolution(resolutions[selectedResolutions].Horizontal, resolutions[selectedResolutions].Vertical, fullscreenToggle.isOn);
        Close();
    }

    public void Close()
    {
        optionsPanel.SetActive(false);
    }
    #endregion
}
#region ResItem
[System.Serializable]
public class ResItem
{
    public string name;
    public int Horizontal;
    public int Vertical;
}
#endregion