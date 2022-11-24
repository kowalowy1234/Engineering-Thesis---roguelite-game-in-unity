using System.Collections;
using UnityEngine;

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
    healthBar = GameObject.FindGameObjectWithTag("HUDHealthbar").GetComponent<HealthBar>();
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
    healthBar.SetHealth(0);
    gameController.PlayerDied();
  }

  public void Heal(float health)
  {
    if (currentHealth + health > maxHealth)
    {
      currentHealth = maxHealth;
      healthBar.SetHealth(maxHealth);
    }
    else
    {
      currentHealth += health;
      healthBar.SetHealth(currentHealth);
    }
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
