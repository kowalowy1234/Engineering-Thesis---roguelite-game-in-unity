using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;

public class SettingsScreen : MonoBehaviour
{
  public AudioMixer MusicMixer;
  public AudioMixer SfxMixer;

  public Toggle fullScreenToggle;
  public Dropdown ResolutionDropdown;
  public Slider musicVolumeSlider;
  public Slider sfxVolumeSlider;

  private SaveManager saveManager;

  Resolution[] Resolutions;

  private void Start()
  {
    saveManager = GameObject.FindGameObjectWithTag("SaveManager").GetComponent<SaveManager>();
    fullScreenToggle.isOn = saveManager.isFullScreen;
    musicVolumeSlider.value = saveManager.musicVolume;
    sfxVolumeSlider.value = saveManager.sfxVolume;

    Resolutions = Screen.resolutions;
    ResolutionDropdown.ClearOptions();

    List<string> Options = new List<string>();

    int currentResolutionIndex = 0;
    for (int i = 0; i < Resolutions.Length; i++)
    {
      string option = Resolutions[i].width + "x" + Resolutions[i].height;
      Options.Add(option);

      if (saveManager.resolutionWidth == Resolutions[i].width && saveManager.resolutionHeight == Resolutions[i].height)
      {
        currentResolutionIndex = i;
      }
    }

    ResolutionDropdown.AddOptions(Options);
    ResolutionDropdown.value = currentResolutionIndex;
    ResolutionDropdown.RefreshShownValue();
  }

  public void SetFullScreen(bool isFullScreen)
  {
    Screen.fullScreen = isFullScreen;
    saveManager.isFullScreen = isFullScreen;
  }

  public void SetResolution(int resolutionIndex)
  {
    Resolution resolution = Resolutions[resolutionIndex];
    Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
    Screen.fullScreen = saveManager.isFullScreen;
    saveManager.resolutionHeight = resolution.height;
    saveManager.resolutionWidth = resolution.width;
  }

  public void SetMusicVolume(float volume)
  {
    MusicMixer.SetFloat("Volume", volume);
    saveManager.musicVolume = volume;
  }

  public void SetSfxVolume(float volume)
  {
    SfxMixer.SetFloat("Volume", volume);
    saveManager.sfxVolume = volume;
  }

  public void GoToMainMenu()
  {
    SceneManager.LoadScene("Main menu");
  }

  public void Exit()
  {
    Application.Quit();
  }
}
