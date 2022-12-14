using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Trophies/Alpha Trophy")]
public class AlphaTrophyScript : TrophyTemplate
{
  public GameObject alphaDamagePool;

  public override void EquipTrophy()
  {
    Instantiate(alphaDamagePool);
  }

  public override void UnequipTrophy()
  {
    Destroy(GameObject.FindGameObjectWithTag("AlphaDamagePool"));
  }
}
