using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollTemplate : ScriptableObject
{
  public string ScrollName;
  public float cooldown;
  public float duration;

  public Sprite sprite;

  public virtual void Activate() { }

  public virtual void Active() { }

  public virtual void Deactivate() { }
}
