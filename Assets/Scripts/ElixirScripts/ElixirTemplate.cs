using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElixirTemplate : ScriptableObject
{
  public string ElixirName;
  public float duration;
  public int charges;

  public Sprite sprite;

  public virtual void Activate()
  {
    // Elixir activation logic
    charges -= 1;
  }
}
