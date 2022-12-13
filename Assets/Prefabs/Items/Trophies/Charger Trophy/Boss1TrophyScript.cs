using UnityEngine;

[CreateAssetMenu(menuName = "Trophies/Charger Trophy")]
public class Boss1TrophyScript : TrophyTemplate
{
  public float bonusMaxHp;

  public override void EquipTrophy()
  {
    GameController gameController = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();
    PlayerController playerController = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();

    gameController.currentTrophy = this;
    playerController.EquippedTrophy = this;
    gameController.itemMaxHealthBonus += bonusMaxHp;
    playerController.maxHealth = gameController.playerMaxHealth + gameController.itemMaxHealthBonus;
    playerController.currentHealth = gameController.playerMaxHealth + gameController.itemMaxHealthBonus;
    playerController.healthBar.SetMaxHealth(playerController.maxHealth);
    playerController.healthBar.SetHealth(playerController.maxHealth);
  }

  public override void UnequipTrophy()
  {
    GameController gameController = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();
    PlayerController playerController = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();

    gameController.itemMaxHealthBonus -= bonusMaxHp;
    playerController.maxHealth -= bonusMaxHp;
    playerController.currentHealth = playerController.maxHealth;
    playerController.healthBar.SetMaxHealth(playerController.maxHealth);
    playerController.healthBar.SetHealth(playerController.maxHealth);
  }
}
