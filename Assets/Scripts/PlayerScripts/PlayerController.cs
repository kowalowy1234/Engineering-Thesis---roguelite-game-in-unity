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
  private HUDScript hud;
  public HealthBar healthBar;
  public GameObject CarriedTrophySprite;
  public TrophyTemplate CarriedTrophy;
  public TrophyTemplate EquippedTrophy;

  [Header("Audio")]
  public AudioClip hurtSound;
  public AudioSource audioSource;

  void Start()
  {
    gameController = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();
    hud = GameObject.FindGameObjectWithTag("HUD").GetComponent<HUDScript>();
    healthBar = GameObject.FindGameObjectWithTag("HUDHealthbar").GetComponent<HealthBar>();

    maxHealth = gameController.playerMaxHealth + gameController.itemMaxHealthBonus;
    currentHealth = gameController.playerMaxHealth;
    healthBar.SetMaxHealth(gameController.playerMaxHealth + gameController.itemMaxHealthBonus);
    healthBar.SetHealth(gameController.playerMaxHealth + gameController.itemMaxHealthBonus);


    CarriedTrophySprite.GetComponent<SpriteRenderer>().sprite = gameController.carriedTrophy.TrophySprite;
    EquippedTrophy = gameController.currentTrophy;
    CarriedTrophy = gameController.carriedTrophy;
    EquippedTrophy.UnequipTrophy();
    EquippedTrophy.EquipTrophy();

    audioSource.clip = hurtSound;
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
      if (audioSource.clip != hurtSound)
      {
        audioSource.clip = hurtSound;
      }
      audioSource.Play();
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

  public void EquipNewTrophy(TrophyTemplate newTrophy)
  {
    CarriedTrophySprite.GetComponent<SpriteRenderer>().sprite = null;
    CarriedTrophy = null;
    EquippedTrophy.UnequipTrophy();
    EquippedTrophy = newTrophy;
    newTrophy.EquipTrophy();
  }

  public void SellTrophy()
  {
    CarriedTrophySprite.GetComponent<SpriteRenderer>().sprite = null;
    CarriedTrophy = null;
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
