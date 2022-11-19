using UnityEngine;

public class Shoot : MonoBehaviour
{
  public Transform shootingPoint;
  public GameObject projectile;
  public float fireRate = 2f;
  private float nextShot = 0.0f;

  void Update()
  {
    if (Input.GetMouseButton(0) && Time.time > nextShot)
    {
      nextShot = Time.time + fireRate;
      Instantiate(projectile, shootingPoint.position, transform.rotation);
    }
  }
}
