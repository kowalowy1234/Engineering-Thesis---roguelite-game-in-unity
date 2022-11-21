using UnityEngine;

[CreateAssetMenu(menuName = "Elixirs/EnergyElixir")]
public class EnergyElixirScript : ElixirTemplate
{
  public float energyRechargeBonus = 1f;

  public override bool Activate()
  {
    PlayerMovement playerMovement = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>();
    playerMovement.energyRechargeRate = energyRechargeBonus;
    return true;
  }

  public override void Deactivate()
  {
    PlayerMovement playerMovement = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>();
    playerMovement.energyRechargeRate = 0f;
  }
}
