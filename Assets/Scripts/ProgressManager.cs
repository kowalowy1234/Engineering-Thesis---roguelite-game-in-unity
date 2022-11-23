using System.Collections.Generic;
using UnityEngine;

public class ProgressManager : MonoBehaviour
{
  private static ProgressManager instance;

  [System.Serializable]
  public class DungeonStructure
  {
    public int DungeonKey;
    public List<bool> levels;
  }
  [SerializeField]
  public List<DungeonStructure> DungeonList = new List<DungeonStructure>();
  public Dictionary<int, List<bool>> levelCompletion = new Dictionary<int, List<bool>>();

  public SaveManager saveManager;

  void Awake()
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

  void Start()
  {
    saveManager = GameObject.FindGameObjectWithTag("SaveManager").GetComponent<SaveManager>();
    levelCompletion = saveManager.levelCompletion;
  }

  public void CompleteLevel(int dungeonNumber)
  {
    for (int i = 0; i < levelCompletion[dungeonNumber].Count; i++)
    {
      if (levelCompletion[dungeonNumber][i] == false)
      {
        levelCompletion[dungeonNumber][i] = true;
        break;
      }
    }
    SaveLevels();
  }

  public bool DungeonCompleted(int dungeonNumber)
  {
    if (levelCompletion[dungeonNumber].Contains(false))
    {
      return false;
    }
    return true;
  }

  private void SaveLevels()
  {
    saveManager.levelCompletion = levelCompletion;
  }
}
