using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElixirTemplate : ScriptableObject
{
  public new string name;
  public float duration;
  public int charges;

  public Sprite sprite;

  public virtual void Activate()
  {
    // Elixir activation logic
    charges -= 1;
  }
}
