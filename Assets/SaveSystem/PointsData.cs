using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PointsData
{
  public int points;
  public float bonusPointsModificator;

  public PointsData(int points, float bonusPointsModificator)
  {
    this.points = points;
    this.bonusPointsModificator = bonusPointsModificator;
  }
}
