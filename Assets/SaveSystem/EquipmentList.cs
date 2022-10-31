using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "databases/equipment")]
public class EquipmentList : ScriptableObject
{
  public List<WeaponTemplate> weapons = new List<WeaponTemplate>();
  public List<ScrollTemplate> scrolls = new List<ScrollTemplate>();
  public List<ElixirTemplate> elixirs = new List<ElixirTemplate>();
}
