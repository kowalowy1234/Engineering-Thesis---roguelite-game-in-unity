using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class EnergyElixirScript : ElixirTemplate
{
  public override void Activate()
  {
    Debug.Log("Used energy elixir");
  }
}
