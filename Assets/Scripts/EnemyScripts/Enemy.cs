using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

  public int maxHealth = 100;
  [SerializeField]
  public int currentHealth;
  private int dotTicks;
  private bool takingDotDamage = false;
  private bool invoulnerable = false;

  public HealthBar healthBar;
  private IEnumerator coroutine;

  void Start()
  {
    currentHealth = maxHealth;
    healthBar.SetHealth(maxHealth);
  }

  public void takeDamage(int damage)
  {
    if (!invoulnerable)
    {
      if (currentHealth - damage <= 0)
      {
        die();
      }
      else
      {
        currentHealth -= damage;
        healthBar.SetHealth(currentHealth);
      }
    }
  }

  public void takeDamageOverTime(int damage, int duration)
  {
    if (!takingDotDamage)
    {
      coroutine = damageOverTime(damage, duration);
      StartCoroutine(coroutine);
    }
    else
    {
      StopCoroutine(coroutine);
      dotTicks = 0;
      coroutine = damageOverTime(damage, duration);
      StartCoroutine(coroutine);
    }
  }

  public void die()
  {
    Destroy(gameObject);
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
