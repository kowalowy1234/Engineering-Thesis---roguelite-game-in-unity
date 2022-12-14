using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopNavigator : MonoBehaviour
{
  public Button characterShopButton;
  public Text characterShopButtonText;
  public GameObject CharacterShop;

  public Button trophyShopButton;
  public Text trophyShopButtonText;
  public GameObject TrophyShop;

  private void OnEnable()
  {
    OpenCharacterShop();
  }

  public void OpenCharacterShop()
  {
    CharacterShop.SetActive(true);
    characterShopButton.interactable = false;
    characterShopButtonText.color = Color.white;

    TrophyShop.SetActive(false);
    trophyShopButton.interactable = true;
    trophyShopButtonText.color = Color.black;
  }

  public void OpenTrophyShop()
  {
    TrophyShop.SetActive(true);
    trophyShopButton.interactable = false;
    trophyShopButtonText.color = Color.white;

    CharacterShop.SetActive(false);
    characterShopButton.interactable = true;
    characterShopButtonText.color = Color.black;
  }
}
