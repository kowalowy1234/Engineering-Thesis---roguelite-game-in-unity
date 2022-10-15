using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponScript : MonoBehaviour
{
  private float nextShot = 0.0f;
  private SpriteRenderer weaponSprite;
  private WeaponTemplate weapon;
  public Transform shootingPoint;

  private void Start()
  {
    weapon = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>().currentWeapon;
    weaponSprite = gameObject.GetComponent<SpriteRenderer>();
    weaponSprite.sprite = weapon.sprite;
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

  public void Swap(WeaponTemplate newWeapon)
  {
    weapon = newWeapon;
    weaponSprite.sprite = newWeapon.sprite;
  }
}
