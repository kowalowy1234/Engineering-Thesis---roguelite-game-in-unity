using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class HealingScrollScript : ScrollTemplate
{
  public override void Activate()
  {
    Debug.Log("Used healing scroll");
  }
}
