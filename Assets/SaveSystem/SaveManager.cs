using System.Collections.Generic;
using UnityEngine;

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
  //==================================================================================

  public int currentTrophy;
  // Passive boss trophy goes here (not yet implemented)

  // Points;
  public int points;
  public float bonusPointsModificator;

  // Attributes
  public float playerMaxHealth;
  public float playerMaxEnergy;
  public float playerMoveSpeed;

  // Progress
  public Dictionary<string, bool[]> dungeonProgress;
  public bool[] portalsOpened;

  // Settings
  const string EQUIPMENT_KEY = "/equipment";
  const string POINTS_KEY = "/points";
  const string ATTRIBUTES_KEY = "/attributes";
  const string SETTINGS_KEY = "/settings";
  const string PROGRESS_KEY = "/progress";

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
    foreach (DungeonStructure dungeon in DungeonList)
    {
      levelCompletion[dungeon.DungeonKey] = dungeon.levels;
    }

    Load();
  }

  public void Save()
  {
    EquipmentData equipmentData = new EquipmentData(currentWeapon, currentScroll, currentElixir);
    SaveSystem.Save(equipmentData, EQUIPMENT_KEY);

    ProgressData progressData = new ProgressData(levelCompletion);
    SaveSystem.Save(progressData, PROGRESS_KEY);

    PointsData pointsData = new PointsData(points, bonusPointsModificator);
    SaveSystem.Save(pointsData, POINTS_KEY);

    AttributesData attributesData = new AttributesData(playerMaxHealth, playerMoveSpeed, playerMaxEnergy);
    SaveSystem.Save(attributesData, ATTRIBUTES_KEY);
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

    AttributesData attributesData = SaveSystem.Load<AttributesData>(ATTRIBUTES_KEY);
    playerMaxHealth = attributesData.health;
    playerMoveSpeed = attributesData.moveSpeed;
    playerMaxEnergy = attributesData.energy;

    // Progression load
    ProgressData progressData = SaveSystem.Load<ProgressData>(PROGRESS_KEY);

    for (int i = 0; i < progressData.Keys.Count; i++)
    {
      levelCompletion[progressData.Keys[i]] = progressData.Levels[i];
    }

    currentTrophy = 1;
  }

  private void OnApplicationQuit()
  {
    Save();
  }
}
