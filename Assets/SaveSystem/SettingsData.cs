using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SettingsData
{
  public bool isFullScreen;
  public int resolutionWidth;
  public int resolutionHeight;
  public float musicVolume;
  public float sfxVolume;

  public SettingsData(bool isFullScreen, int resolutionWidth, int resolutionHeight, float musicVolume, float sfxVolume)
  {
    this.isFullScreen = isFullScreen;
    this.resolutionWidth = resolutionWidth;
    this.resolutionHeight = resolutionHeight;
    this.musicVolume = musicVolume;
    this.sfxVolume = sfxVolume;
  }
}
