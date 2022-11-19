using System.Collections.Generic;
using UnityEngine;

public class SaveManager : MonoBehaviour
{
  public static SaveManager instance;

  // Equipment
  public WeaponTemplate currentWeapon;
  public ScrollTemplate currentScroll;
  public ElixirTemplate currentElixir;
  public int currentTrophy;
  // Passive boss trophy goes here (not yet implemented)

  // Points;
  public int points;
  public float bonusPointsModificator;

  // Attributes
  public float playerMaxHealth;
  public float playerMaxEnergy;

  // Progress
  public Dictionary<string, bool[]> dungeonProgress;
  public bool[] portalsOpened;

  // Settings
  const string EQUIPMENT_KEY = "/equipment";
  const string POINTS_KEY = "/points";
  const string ATTRIBUTES_KEY = "/attributes";
  const string SETTINGS_KEY = "/settings";

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
    Load();
  }

  public void Save()
  {
    EquipmentData equipmentData = new EquipmentData(currentWeapon, currentScroll, currentElixir);
    SaveSystem.Save(equipmentData, EQUIPMENT_KEY);
  }

  void Load()
  {
    EquipmentData equipmentData = SaveSystem.Load<EquipmentData>(EQUIPMENT_KEY);
    Debug.Log(equipmentData.scriptedWeaponName);
    currentWeapon = Resources.Load<WeaponTemplate>(equipmentData.scriptedWeaponName);
    currentScroll = Resources.Load<ScrollTemplate>(equipmentData.scriptedScrollName);
    currentElixir = Resources.Load<ElixirTemplate>(equipmentData.scriptedElixirName);
    currentTrophy = 1;
  }

  private void OnApplicationQuit()
  {
    Save();
  }
}
