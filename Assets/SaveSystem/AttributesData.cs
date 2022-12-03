using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class AttributesData
{
  public float health;
  public float moveSpeed;
  public float energy;
  public float itemMaxHealthBonus;

  public AttributesData(float health, float moveSpeed, float energy, float itemHealthBonus)
  {
    this.health = health;
    this.moveSpeed = moveSpeed;
    this.energy = energy;
    this.itemMaxHealthBonus = itemHealthBonus;
  }
}
