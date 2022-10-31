using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Scrolls/ExplosionScroll")]
public class ExplosionScrollScript : ScrollTemplate
{
  public override void Activate()
  {
    Debug.Log("Used explosion scroll");
  }
}
