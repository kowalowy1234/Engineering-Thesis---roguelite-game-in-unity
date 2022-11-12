using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
  public float damageReduce = 1f;
  public bool invoulnerable = false;

  public float maxHealth;
  public float currentHealth;
  private int dotTicks;
  private bool takingDotDamage = false;

  private GameController gameController;
  public HealthBar healthBar;

  void Start()
  {
    gameController = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();
    maxHealth = gameController.playerMaxHealth;
    currentHealth = gameController.playerMaxHealth;
    healthBar.SetMaxHealth(gameController.playerMaxHealth);
    healthBar.SetHealth(gameController.playerMaxHealth);
  }

  void Update()
  {
    if (Input.GetKeyDown(KeyCode.K))
    {
      takeDamage(2f);
    }

    if (Input.GetKeyDown(KeyCode.H))
    {
      Heal(10);
    }
  }

  public void takeDamage(float damage)
  {
    if (!invoulnerable)
    {
      if (currentHealth - (damage * damageReduce) <= 0)
      {
        die();
      }
      else
      {
        currentHealth -= damage * damageReduce;
        healthBar.SetHealth(currentHealth);
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
    healthBar.SetHealth(0);
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
