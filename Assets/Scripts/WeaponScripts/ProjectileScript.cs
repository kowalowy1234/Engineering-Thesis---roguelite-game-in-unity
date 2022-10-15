using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileScript : MonoBehaviour
{
  public float velocity = 100f;
  private Rigidbody2D rigidBD;

  private void Awake()
  {
    rigidBD = gameObject.GetComponent<Rigidbody2D>();
  }

  void Start()
  {
    rigidBD.velocity = transform.up * velocity;
  }

  private void OnCollisionEnter2D(Collision2D other)
  {
    Destroy(gameObject);
  }
}
