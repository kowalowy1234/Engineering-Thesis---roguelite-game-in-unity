using UnityEngine;

public class ElixirTemplate : ScriptableObject
{
  public string ElixirName;
  public float duration;
  public int charges;
  public string description;

  public Sprite sprite;

  public virtual bool Activate()
  {
    // Elixir activation logic
    return true;
  }

  public virtual void Active()
  {
    // Elixir active logic
  }

  public virtual void Deactivate()
  {
    // Elixir deactivate logic
  }
}
