using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

  public float maxHealth = 100;
  [SerializeField]
  public float currentHealth;
  private int dotTicks;
  private bool takingDotDamage = false;
  public bool invoulnerable = false;
  public bool boss;

  public HealthBar healthBar;
  public GameObject Teleport;
  public GameObject Trophy;
  public GameObject pointsObject;
  private RoomController roomController;
  private IEnumerator coroutine;

  void Start()
  {
    currentHealth = maxHealth;
    healthBar.SetMaxHealth(maxHealth);
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
      if (gameObject.activeInHierarchy)
      {
        StartCoroutine(coroutine);
      }
    }
  }

  public void die()
  {
    StopAllCoroutines();
    Instantiate(pointsObject, transform.position, Quaternion.identity);
    if (boss)
    {
      Instantiate(Teleport, transform.position, Quaternion.identity);
    }
    roomController = transform.parent.GetComponent<RoomController>();
    roomController.Kill(gameObject);
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
