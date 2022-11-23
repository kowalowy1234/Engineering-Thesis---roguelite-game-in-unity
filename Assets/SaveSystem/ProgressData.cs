using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class ProgressData
{
  public List<int> Keys;
  public List<List<bool>> Levels;

  public ProgressData(Dictionary<int, List<bool>> levelCompletion)
  {
    Keys = new List<int>();
    Levels = new List<List<bool>>();

    foreach (KeyValuePair<int, List<bool>> level in levelCompletion)
    {
      Keys.Add(level.Key);
      Levels.Add(level.Value);
    }
  }
}
