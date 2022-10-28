using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollTemplate : ScriptableObject
{
  public new string name;
  public float cooldown;
  public float duration;

  public Sprite sprite;

  public virtual void Activate()
  {
    // Scroll activation logic
  }
}
