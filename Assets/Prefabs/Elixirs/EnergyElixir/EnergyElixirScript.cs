using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Elixirs/EnergyElixir")]
public class EnergyElixirScript : ElixirTemplate
{
  public override void Activate()
  {
    Debug.Log("Used energy elixir");
  }
}
