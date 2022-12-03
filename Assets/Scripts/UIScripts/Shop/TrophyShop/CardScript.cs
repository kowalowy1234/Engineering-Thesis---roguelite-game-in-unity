using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardScript : MonoBehaviour
{
  public TrophyTemplate Trophy;
  public Button SellButton;
  public Button ExchangeButton;
  public Text Description;
  public Text Price;
  public Image Image;
  public GameController gameController;

  void Start()
  {
    gameController = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();
    Image.sprite = Trophy.TrophySprite;
    Description.text = Trophy.TrophyDescription;
    Price.text = "Sell for " + Trophy.TrophyPrice;
    RefreshCard();
  }

  void Update()
  {
    if (gameController == null)
    {
      gameController = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();
    }
  }

  private void OnEnable()
  {
    RefreshCard();
  }

  public void SellTrophy()
  {
    gameController.PickUpTrophy(gameController.defaultTrophy);
    gameController.Sell(Trophy.TrophyPrice);
    RefreshCard();
  }

  public void ExchangeTrophy()
  {
    gameController.EquipNewTrophy(Trophy);
    RefreshCard();
  }

  private void RefreshCard()
  {
    if (gameController.carriedTrophy.name != Trophy.name)
    {
      SellButton.interactable = false;
      ExchangeButton.interactable = false;
    }
    else if (gameController.carriedTrophy.name == Trophy.name && gameController.currentTrophy.name == Trophy.name)
    {
      SellButton.interactable = true;
      ExchangeButton.interactable = false;
    }
    else if (gameController.carriedTrophy.name == Trophy.name && gameController.currentTrophy.name != Trophy.name)
    {
      SellButton.interactable = true;
      ExchangeButton.interactable = true;
    }
    else
    {
      SellButton.interactable = false;
      ExchangeButton.interactable = false;
    }
  }
}
