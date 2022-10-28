using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
  public float damageReduce = 0f;
  public bool invoulnerable = false;

  [SerializeField]
  private float maxHealth;
  [SerializeField]
  private float currentHealth;
  private int dotTicks;
  private bool takingDotDamage = false;

  void Start()
  {
    currentHealth = maxHealth;
    // healthBar.SetHealth(maxHealth);
  }

  public void takeDamage(int damage)
  {
    if (!invoulnerable)
    {
      if (currentHealth - damage * damageReduce <= 0)
      {
        die();
      }
      else
      {
        currentHealth -= damage * damageReduce;
        // healthBar.SetHealth(currentHealth);
      }
    }
  }

  public void takeDamageOverTime(int damage, int duration)
  {
    if (!takingDotDamage)
    {
      StartCoroutine(damageOverTime(damage, duration));
    }
  }

  public void die()
  {
    // Destroy(gameObject);
    Debug.Log("Game Over");
  }

  public void Heal(int health)
  {
    //heal logic;
  }

  IEnumerator damageOverTime(int damage, int duration)
  {
    takingDotDamage = true;

    yield return new WaitForSeconds(0.5f);

    while (dotTicks < duration)
    {
      takeDamage(damage);
      dotTicks += 1;
      yield return new WaitForSeconds(1f);
    }

    dotTicks = 0;
    takingDotDamage = false;
  }
}
