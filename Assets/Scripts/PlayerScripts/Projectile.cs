using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{

  public float velocity = 100f;

  public Rigidbody2D rigidBD;

  // Update is called once per frame
  void Update()
  {
    rigidBD.velocity = transform.right * velocity;
  }

  private void OnCollisionEnter2D(Collision2D other)
  {
    Destroy(gameObject);
  }
}

