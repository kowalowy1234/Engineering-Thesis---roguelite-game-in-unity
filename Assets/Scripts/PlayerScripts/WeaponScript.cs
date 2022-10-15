using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponScript : MonoBehaviour
{
  private float nextShot = 0.0f;
  public WeaponTemplate weapon;
  private SpriteRenderer weaponSprite;
  [SerializeField]
  private Transform shootingPoint;

  private void Awake()
  {
    gameObject.GetComponent<SpriteRenderer>().sprite = weapon.sprite;
  }

  private void Update()
  {
    if (Input.GetMouseButton(0) && Time.time > nextShot)
    {
      Shoot();
    }
  }

  private void Shoot()
  {
    nextShot = Time.time + weapon.rateOfFire;
    Instantiate(weapon.projectile, shootingPoint.position, transform.rotation);
  }

  // Should this exist here?
  private void Swap()
  {

  }
}
