using UnityEngine;

[CreateAssetMenu(menuName = "Scrolls/ShieldScroll")]
public class ShieldScrollScript : ScrollTemplate
{
  public override void Activate()
  {
    Debug.Log("Used shield scroll");
  }
}
