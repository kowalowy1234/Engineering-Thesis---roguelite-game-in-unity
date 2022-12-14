using UnityEngine;

[CreateAssetMenu(menuName = "Scrolls/ExplosionScroll")]
public class ExplosionScrollScript : ScrollTemplate
{
  public GameObject explosionProjectile;

  public override bool Activate()
  {
    Instantiate(explosionProjectile, GameObject.FindGameObjectWithTag("Player").transform);
    return true;
  }
}
