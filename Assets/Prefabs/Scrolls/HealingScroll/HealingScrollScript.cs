using UnityEngine;

[CreateAssetMenu(menuName = "Scrolls/HealingScroll")]
public class HealingScrollScript : ScrollTemplate
{
  public float healValue = 10f;
  public override bool Activate()
  {
    PlayerController playerController = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
    if (playerController.currentHealth == playerController.maxHealth)
    {
      return false;
    }
    else
    {
      playerController.Heal(healValue);
      return true;
    }
  }
}
