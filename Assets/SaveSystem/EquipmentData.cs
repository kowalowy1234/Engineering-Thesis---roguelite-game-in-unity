using UnityEngine;

[System.Serializable]
public class EquipmentData
{
  public string scriptedWeaponName;
  public string scriptedScrollName;
  public string scriptedElixirName;
  public string scriptedCarriedTrophyName;
  public string scriptedCurrentTrophyName;

  public EquipmentData(WeaponTemplate weapon, ScrollTemplate scroll, ElixirTemplate elixir, TrophyTemplate carriedTrophy, TrophyTemplate currentTrophy)
  {
    scriptedWeaponName = weapon.name;
    scriptedScrollName = scroll.name;
    scriptedElixirName = elixir.name;
    scriptedCarriedTrophyName = carriedTrophy.name;
    scriptedCurrentTrophyName = currentTrophy.name;
  }
}
