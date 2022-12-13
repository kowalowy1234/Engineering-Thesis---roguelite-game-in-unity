using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class SaveManager : MonoBehaviour
{
  public static SaveManager instance;

  // Equipment
  public WeaponTemplate currentWeapon;
  public ScrollTemplate currentScroll;
  public ElixirTemplate currentElixir;

  //========================== Level progression =====================================
  [System.Serializable]
  public class DungeonStructure
  {
    public int DungeonKey;
    public List<bool> levels;
  }

  [SerializeField]
  public List<DungeonStructure> DungeonList = new List<DungeonStructure>();
  public Dictionary<int, List<bool>> levelCompletion = new Dictionary<int, List<bool>>();

  //=========================== Teleports opened =====================================

  [System.Serializable]
  public class TeleportOpenedPair
  {
    public string dungeonName;
    public bool isOpened;
  }

  public List<TeleportOpenedPair> teleportsOpenedList = new List<TeleportOpenedPair>();

  public TrophyTemplate currentTrophy;
  public TrophyTemplate carriedTrophy;

  // Points;
  public int points;
  public float bonusPointsModificator;

  // Attributes
  public float playerMaxHealth;
  public float itemMaxHealthBonus;
  public float playerMaxEnergy;
  public float playerMoveSpeed;

  //Settings;
  public bool isFullScreen;
  public int resolutionWidth;
  public int resolutionHeight;
  public float musicVolume;
  public AudioMixer musicMixer;
  public float sfxVolume;
  public AudioMixer sfxMixer;

  // Keys
  const string EQUIPMENT_KEY = "/equipment";
  const string POINTS_KEY = "/points";
  const string ATTRIBUTES_KEY = "/attributes";
  const string SETTINGS_KEY = "/settings";
  const string PROGRESS_KEY = "/progress";

  private void Awake()
  {
    resolutionWidth = Screen.currentResolution.width;
    resolutionHeight = Screen.currentResolution.height;

    if (instance == null)
    {
      instance = this;
      DontDestroyOnLoad(gameObject);
    }
    else if (instance != null)
    {
      Destroy(gameObject);
    }
    foreach (DungeonStructure dungeon in DungeonList)
    {
      levelCompletion[dungeon.DungeonKey] = dungeon.levels;
    }

    Load();
  }

  public void Save()
  {
    EquipmentData equipmentData = new EquipmentData(currentWeapon, currentScroll, currentElixir, carriedTrophy, currentTrophy);
    SaveSystem.Save(equipmentData, EQUIPMENT_KEY);

    ProgressData progressData = new ProgressData(levelCompletion, teleportsOpenedList);
    SaveSystem.Save(progressData, PROGRESS_KEY);

    PointsData pointsData = new PointsData(points, bonusPointsModificator);
    SaveSystem.Save(pointsData, POINTS_KEY);

    AttributesData attributesData = new AttributesData(playerMaxHealth, playerMoveSpeed, playerMaxEnergy, itemMaxHealthBonus);
    SaveSystem.Save(attributesData, ATTRIBUTES_KEY);

    SettingsData settingsData = new SettingsData(isFullScreen, resolutionWidth, resolutionHeight, musicVolume, sfxVolume);
    SaveSystem.Save(settingsData, SETTINGS_KEY);
  }

  void Load()
  {
    PointsData pointsData = SaveSystem.Load<PointsData>(POINTS_KEY);
    points = pointsData.points;
    bonusPointsModificator = pointsData.bonusPointsModificator;

    EquipmentData equipmentData = SaveSystem.Load<EquipmentData>(EQUIPMENT_KEY);
    currentWeapon = Resources.Load<WeaponTemplate>(equipmentData.scriptedWeaponName);
    currentScroll = Resources.Load<ScrollTemplate>(equipmentData.scriptedScrollName);
    currentElixir = Resources.Load<ElixirTemplate>(equipmentData.scriptedElixirName);
    carriedTrophy = Resources.Load<TrophyTemplate>(equipmentData.scriptedCarriedTrophyName);
    currentTrophy = Resources.Load<TrophyTemplate>(equipmentData.scriptedCurrentTrophyName);

    AttributesData attributesData = SaveSystem.Load<AttributesData>(ATTRIBUTES_KEY);
    playerMaxHealth = attributesData.health;
    playerMoveSpeed = attributesData.moveSpeed;
    playerMaxEnergy = attributesData.energy;
    itemMaxHealthBonus = attributesData.itemMaxHealthBonus;

    // Progression load
    ProgressData progressData = SaveSystem.Load<ProgressData>(PROGRESS_KEY);

    teleportsOpenedList = progressData.teleportsOpened;

    for (int i = 0; i < progressData.Keys.Count; i++)
    {
      levelCompletion[progressData.Keys[i]] = progressData.Levels[i];
    }

    SettingsData settingsData = SaveSystem.Load<SettingsData>(SETTINGS_KEY);
    resolutionHeight = settingsData.resolutionHeight;
    resolutionWidth = settingsData.resolutionWidth;
    isFullScreen = settingsData.isFullScreen;
    Screen.SetResolution(resolutionWidth, resolutionHeight, Screen.fullScreen);
    Screen.fullScreen = isFullScreen;
    musicVolume = settingsData.musicVolume;
    sfxVolume = settingsData.sfxVolume;
  }

  private void OnApplicationQuit()
  {
    Save();
  }
}
