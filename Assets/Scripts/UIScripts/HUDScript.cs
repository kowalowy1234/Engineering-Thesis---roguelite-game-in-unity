using UnityEngine;
using UnityEngine.UI;

public class HUDScript : MonoBehaviour
{
  [Header("Elixir")]
  public Image ElixirSprite;
  public GameObject ElixirInfo;
  public Text ElixirCharges;
  public Text ElixirDescription;
  public Text ElixirName;

  [Header("Scroll")]
  public Image ScrollSprite;
  public GameObject ScrollInfo;
  public Text Cooldown;
  public Text ScrollDescription;
  public Text ScrollName;

  [Header("Weapon")]
  public Image WeaponSprite;
  public GameObject WeaponInfo;
  public Text WeaponDescription;
  public Text WeaponName;

  [Header("Trophy")]
  public Image TrophySprite;
  public GameObject TrophyInfo;
  public Text TrophyDescription;
  public Text TrophyName;

  [Header("Points")]
  public Text Points;
  public Text BonusPointsModificator;

  private bool itemsShowing;

  private void Start()
  {
    GameController gameController = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();

    UpdateElixirInfo(gameController.currentElixir.name, gameController.currentElixir.description);
    UpdateElixirSprite(gameController.currentElixir.sprite);
    UpdateElixirCharges(gameController.currentElixir.charges);

    UpdateScrollInfo(gameController.currentScroll.name, gameController.currentScroll.description);
    UpdateScrollSprite(gameController.currentScroll.sprite);

    UpdateWeaponInfo(gameController.currentWeapon.name, gameController.currentWeapon.description);
    UpdateWeaponSprite(gameController.currentWeapon.sprite);

    UpdateTrophyInfo(gameController.currentTrophy.TrophySprite, gameController.currentTrophy.name, gameController.currentTrophy.TrophyDescription);

    UpdatePoints(gameController.points, gameController.bonusPointsModificator);
  }

  private void Update()
  {
    if (Input.GetKeyDown(KeyCode.LeftAlt) && Time.timeScale > 0f)
    {
      ShowItemInfo();
    }

    if (Input.GetKeyUp(KeyCode.LeftAlt) && itemsShowing)
    {
      HideItemInfo();
    }
  }

  public void UpdateElixirSprite(Sprite sprite)
  {
    ElixirSprite.sprite = sprite;
  }

  public void UpdateElixirInfo(string name, string description)
  {
    ElixirName.text = name;
    ElixirDescription.text = description;
  }

  public void UpdateElixirCharges(int charges)
  {
    ElixirCharges.text = "" + charges;
  }

  public void UpdateScrollSprite(Sprite sprite)
  {
    ScrollSprite.sprite = sprite;
  }

  public void UpdateScrollInfo(string name, string description)
  {
    ScrollName.text = name;
    ScrollDescription.text = description;
  }

  public void UpdateScrollCooldown(string cooldown)
  {
    Cooldown.text = cooldown;
  }

  public void UpdateWeaponSprite(Sprite sprite)
  {
    WeaponSprite.sprite = sprite;
  }

  public void UpdateWeaponInfo(string name, string description)
  {
    WeaponName.text = name;
    WeaponDescription.text = description;
  }

  public void UpdateTrophyInfo(Sprite sprite, string name, string description)
  {
    TrophySprite.sprite = sprite;
    TrophyName.text = name;
    TrophyDescription.text = description;
  }

  public void UpdatePoints(int points, float bonusPointsModificator)
  {
    Points.text = points + "";
    BonusPointsModificator.text = bonusPointsModificator + "";
  }

  private void ShowItemInfo()
  {
    if (Time.timeScale > 0f)
    {
      Time.timeScale = 0f;
      itemsShowing = true;
      ElixirInfo.SetActive(true);
      ScrollInfo.SetActive(true);
      WeaponInfo.SetActive(true);
      TrophyInfo.SetActive(true);
    }
  }

  private void HideItemInfo()
  {
    Time.timeScale = 1f;
    itemsShowing = false;
    ElixirInfo.SetActive(false);
    ScrollInfo.SetActive(false);
    WeaponInfo.SetActive(false);
    TrophyInfo.SetActive(false);
  }
}
