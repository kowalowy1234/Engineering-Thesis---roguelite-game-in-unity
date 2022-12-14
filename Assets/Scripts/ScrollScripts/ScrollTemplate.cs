using UnityEngine;

public class ScrollTemplate : ScriptableObject
{
  public string ScrollName;
  public float cooldown;
  public float duration;
  public string description;

  public Sprite sprite;

  public virtual bool Activate()
  {
    return true;
  }

  public virtual void Active() { }

  public virtual void Deactivate() { }
}
