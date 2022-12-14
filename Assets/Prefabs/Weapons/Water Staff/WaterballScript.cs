using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterballScript : ProjectileScript
{
  // int   damage
  // int   damageOverTime
  // int   dotDuration
  public int healAmount = 3;
  public float healChance = 0.3f;

  public override void dealDamage(Enemy enemy)
  {
    if (Random.Range(0f, 1f) <= healChance)
    {
      playerController.Heal(healAmount);
    }

    enemy.takeDamage(damage);

    // enemy.takeDamageOverTime(damageOverTime, dotDuration);
  }
}
