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
