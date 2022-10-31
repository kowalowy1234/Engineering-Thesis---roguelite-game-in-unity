using UnityEngine;

[System.Serializable]
public class EquipmentData
{
  public string scriptedWeaponName;
  public string scriptedScrollName;
  public string scriptedElixirName;

  public EquipmentData(WeaponTemplate weapon, ScrollTemplate scroll, ElixirTemplate elixir)
  {
    scriptedWeaponName = weapon.name;
    scriptedScrollName = scroll.name;
    scriptedElixirName = elixir.name;
  }
}
