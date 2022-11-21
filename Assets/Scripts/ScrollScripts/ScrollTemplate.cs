using UnityEngine;

public class ScrollTemplate : ScriptableObject
{
  public string ScrollName;
  public float cooldown;
  public float duration;

  public Sprite sprite;

  public virtual bool Activate()
  {
    return true;
  }

  public virtual void Active() { }

  public virtual void Deactivate() { }
}
