using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterShop : MonoBehaviour
{
  public float maxBonusHp = 20;
  public float maxBonusMs = 3;
  public float maxBonusEn = 20;

  public int HpPrice = 2500;
  public int MsPrice = 2500;
  public int EnPrice = 2500;

  private GameController gameController;
  private PlayerController playerController;
  private PlayerMovement playerMovement;
  public HPScript hPScript;
  public MSScript mSScript;
  public ENScript eNScript;

  public Button BuyHPButton;
  public Button BuyMsButton;
  public Button BuyEnButton;

  private void Start()
  {
    gameController = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();
    playerController = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
    playerMovement = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>();

    hPScript.SetMaxValue(maxBonusHp);
    hPScript.SetValue(gameController.playerMaxHealth - gameController.baseMaxHp);
    mSScript.SetMaxValue(maxBonusMs);
    mSScript.SetValue(gameController.playerMoveSpeed - gameController.baseMs);
    eNScript.SetMaxValue(maxBonusEn);
    eNScript.SetValue(gameController.playerMaxEnergy - gameController.baseMaxEnergy);

    if (gameController.playerMaxHealth == maxBonusHp + gameController.baseMaxHp)
    {
      BuyHPButton.interactable = false;
    }
    if (gameController.playerMoveSpeed == maxBonusMs + gameController.baseMs)
    {
      BuyMsButton.interactable = false;
    }
    if (gameController.playerMaxEnergy == maxBonusEn + gameController.baseMaxEnergy)
    {
      BuyEnButton.interactable = false;
    }
  }

  public void BuyHp()
  {
    if (gameController.points >= HpPrice)
    {
      gameController.points -= HpPrice;
      gameController.AddPoints(-HpPrice);
      gameController.playerMaxHealth += 10f;
      playerController.maxHealth += 10f;
      playerController.currentHealth = playerController.maxHealth;
      playerController.healthBar.SetMaxHealth(playerController.maxHealth);
      playerController.healthBar.SetHealth(playerController.maxHealth);
      hPScript.SetValue(gameController.playerMaxHealth - gameController.baseMaxHp);
    }

    if (gameController.playerMaxHealth == maxBonusHp + gameController.baseMaxHp)
    {
      BuyHPButton.interactable = false;
    }

    gameController.SaveGame();
  }

  public void BuyMs()
  {
    if (gameController.points >= MsPrice)
    {
      gameController.points -= MsPrice;
      gameController.AddPoints(-MsPrice);
      gameController.playerMoveSpeed += 1f;
      playerMovement.moveSpeed = playerMovement.moveSpeed + 1f;
      mSScript.SetValue(gameController.playerMoveSpeed - gameController.baseMs);
    }

    if (gameController.playerMoveSpeed == maxBonusMs + gameController.baseMs)
    {
      BuyMsButton.interactable = false;
    }

    gameController.SaveGame();
  }

  public void BuyEn()
  {
    if (gameController.points >= EnPrice)
    {
      gameController.points -= EnPrice;
      gameController.AddPoints(-EnPrice);
      gameController.playerMaxEnergy += 10f;
      playerMovement.maxEnergy += 10f;
      playerMovement.energyBar.SetMaxEnergy(playerMovement.maxEnergy);
      playerMovement.energyBar.SetEnergy(playerMovement.maxEnergy);
      eNScript.SetValue(gameController.playerMaxEnergy - gameController.baseMaxEnergy);
    }

    if (gameController.playerMaxEnergy == maxBonusEn + gameController.baseMaxEnergy)
    {
      BuyEnButton.interactable = false;
    }

    gameController.SaveGame();
  }
}
