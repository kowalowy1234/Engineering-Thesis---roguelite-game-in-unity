using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionProjectile : MonoBehaviour
{
  public float speed = 10f;
  public GameObject explosionTrigger;
  public Rigidbody2D rb;

  void Start()
  {
    gameObject.transform.rotation = GameObject.FindGameObjectWithTag("WeaponPivot").transform.rotation;
    rb.velocity = transform.right * speed;
  }

  private void OnCollisionEnter2D(Collision2D other)
  {
    Instantiate(explosionTrigger, transform.position, Quaternion.identity);
    Destroy(gameObject);
  }
}
