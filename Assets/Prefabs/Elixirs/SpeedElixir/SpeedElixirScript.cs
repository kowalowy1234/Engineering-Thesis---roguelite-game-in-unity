using UnityEngine;

[CreateAssetMenu(menuName = "Elixirs/SpeedElixir")]
public class SpeedElixirScript : ElixirTemplate
{
  public float speedBonus = 5f;

  public override bool Activate()
  {
    PlayerMovement playerMovement = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>();
    playerMovement.moveSpeed += speedBonus;
    return true;
  }

  public override void Deactivate()
  {
    PlayerMovement playerMovement = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>();
    playerMovement.moveSpeed -= speedBonus;
  }
}
