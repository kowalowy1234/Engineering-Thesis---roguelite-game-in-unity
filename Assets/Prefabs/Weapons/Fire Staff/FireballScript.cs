using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireballScript : ProjectileScript
{
  // int   damage
  // int   damageOverTime
  // int   dotDuration

  public override void dealDamage(Enemy enemy)
  {
    enemy.takeDamage(damage);
    enemy.takeDamageOverTime(damageOverTime, dotDuration);
  }
}