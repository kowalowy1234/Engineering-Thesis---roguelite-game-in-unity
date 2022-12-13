using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

public class MusicPlayer : MonoBehaviour
{
  public static MusicPlayer instance;

  public AudioSource audioSource;
  public AudioMixer musicMixer;
  private SaveManager saveManager;

  [System.Serializable]
  public class SceneMusicPair
  {
    public string sceneName;
    public AudioClip sceneMusic;
  }

  [Header("Music clips")]
  public List<SceneMusicPair> sceneMusicPairs = new List<SceneMusicPair>();

  private void Awake()
  {
    if (instance == null)
    {
      instance = this;
      DontDestroyOnLoad(gameObject);
    }
    else if (instance != null)
    {
      Destroy(gameObject);
    }
  }

  private void Start()
  {
    saveManager = GameObject.FindGameObjectWithTag("SaveManager").GetComponent<SaveManager>();
    musicMixer.SetFloat("Volume", saveManager.musicVolume);
    audioSource.Play();

  }

  private void OnEnable()
  {
    SceneManager.sceneLoaded += OnSceneLoaded;
  }

  private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
  {
    foreach (SceneMusicPair pair in sceneMusicPairs)
    {
      if (pair.sceneName == scene.name)
      {
        if (pair.sceneMusic != audioSource.clip)
        {
          audioSource.clip = pair.sceneMusic;
          audioSource.Play();
        }
        break;
      }
    }
  }
}
