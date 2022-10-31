using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Scrolls/HealingScroll")]
public class HealingScrollScript : ScrollTemplate
{
  public override void Activate()
  {
    Debug.Log("Used healing scroll");
  }
}
