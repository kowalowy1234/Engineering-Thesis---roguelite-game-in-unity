using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrophyTemplate : ScriptableObject
{
  public string TrophyName;
  public int TrophyPrice;
  public string TrophyDescription;
  public Sprite TrophySprite;

  public virtual void EquipTrophy()
  {

  }

  public virtual void UnequipTrophy()
  {

  }
}
