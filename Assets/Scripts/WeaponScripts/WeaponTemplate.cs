using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class WeaponTemplate : ScriptableObject
{
  public new string name;
  public float rateOfFire;
  public Sprite sprite;
  public GameObject projectile;
}
