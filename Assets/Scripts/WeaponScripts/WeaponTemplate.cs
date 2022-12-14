using UnityEngine;

[CreateAssetMenu]
public class WeaponTemplate : ScriptableObject
{
  public string weaponName;
  public float rateOfFire;
  public Sprite sprite;
  public GameObject projectile;
  public string description;
  public AudioClip shootSound;
}
