using UnityEngine;
using UnityEngine.UI;

public class HUDScript : MonoBehaviour
{
  public Image ElixirSprite;
  public Text ElixirCharges;

  public Image ScrollSprite;
  public Text Cooldown;

  public Image WeaponSprite;
  public Image TrophySprite;

  public Text Points;
  public Text BonusPointsModificator;

  private void Start()
  {
    GameController gameController = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();

    UpdateElixirSprite(gameController.currentElixir.sprite);
    UpdateElixirCharges(gameController.currentElixir.charges);
    UpdateScrollSprite(gameController.currentScroll.sprite);
    UpdateWeaponSprite(gameController.currentWeapon.sprite);
    UpdatePoints(gameController.points, gameController.bonusPointsModificator);
  }

  public void UpdateElixirSprite(Sprite sprite)
  {
    ElixirSprite.sprite = sprite;
  }

  public void UpdateElixirCharges(int charges)
  {
    ElixirCharges.text = "" + charges;
  }

  public void UpdateScrollSprite(Sprite sprite)
  {
    ScrollSprite.sprite = sprite;
  }

  public void UpdateScrollCooldown(string cooldown)
  {
    Cooldown.text = cooldown;
  }

  public void UpdateWeaponSprite(Sprite sprite)
  {
    WeaponSprite.sprite = sprite;
  }

  public void UpdateTrophySprite(Sprite sprite)
  {
    TrophySprite.sprite = sprite;
  }

  public void UpdatePoints(int points, float bonusPointsModificator)
  {
    Points.text = points + "";
    BonusPointsModificator.text = bonusPointsModificator + "";
  }
}
