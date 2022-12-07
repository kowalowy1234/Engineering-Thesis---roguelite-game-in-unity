using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Trophies/Spinner Trophy")]
public class SpinnerTrophyScript : TrophyTemplate
{
  public GameObject stalkerShield;
  private GameObject shieldInstance;
  private GameObject player;

  public override void EquipTrophy()
  {
    shieldInstance = Instantiate(stalkerShield);
  }

  public override void UnequipTrophy()
  {
    Destroy(shieldInstance);
  }
}
