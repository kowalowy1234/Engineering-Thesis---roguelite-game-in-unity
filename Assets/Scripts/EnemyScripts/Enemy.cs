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
  public TrophyTemplate Trophy;
  public GameObject pointsObject;
  [SerializeField]
  private RoomController roomController;
  private IEnumerator coroutine;
  public GameObject Alpha;
  public LineRenderer lineRenderer;

  void Start()
  {
    if (Alpha)
    {
      lineRenderer = gameObject.GetComponent<LineRenderer>();
    }
    currentHealth = maxHealth;
    healthBar.SetMaxHealth(maxHealth);
  }

  private void Update()
  {
    if (Alpha)
    {
      DrawLineToAlpha();
    }
    else
    {
      HideLine();
    }

    if (!roomController)
    {
      roomController = transform.parent.GetComponent<RoomController>();
    }
  }

  public void takeDamage(int damage)
  {
    if (!invoulnerable)
    {
      if (currentHealth - damage <= 0)
      {
        if (Alpha)
        {
          Alpha.GetComponent<AlphaScript>().DealDamageToParent();
        }
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
      GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>().PickUpTrophy(Trophy);
    }
    roomController = transform.parent.GetComponent<RoomController>();
    roomController.Kill(gameObject);
    // Destroy(gameObject);
    gameObject.SetActive(false);
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

  private void DrawLineToAlpha()
  {
    lineRenderer.SetPosition(0, transform.position);
    lineRenderer.SetPosition(1, Alpha.transform.position);
  }

  private void HideLine()
  {
    lineRenderer.SetPosition(0, transform.position);
    lineRenderer.SetPosition(1, transform.position);
  }
}
