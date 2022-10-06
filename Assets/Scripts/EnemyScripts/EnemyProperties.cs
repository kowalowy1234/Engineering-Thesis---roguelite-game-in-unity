using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyProperties : MonoBehaviour
{

  public int baseHealth = 100;

  void Update()
  {
    if (baseHealth <= 0)
    {
      Destroy(gameObject);
    }
  }

  private void OnCollisionEnter2D(Collision2D other)
  {
    if (other.gameObject.tag == "Projectile")
    {
      baseHealth -= 10;
    }
  }
}
