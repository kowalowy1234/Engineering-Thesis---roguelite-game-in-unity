using UnityEngine;

namespace ShootingEnemy
{
  public class Projectile : MonoBehaviour
  {
    public float velocity = 100f;
    public int damage = 10;
    private Rigidbody2D rigidBD;

    private void OnEnable()
    {
      if (rigidBD != null)
      {
        rigidBD.velocity = transform.right * velocity;
      }
    }

    void Start()
    {
      rigidBD = gameObject.GetComponent<Rigidbody2D>();
      rigidBD.velocity = transform.right * velocity;
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
      PlayerController player = other.gameObject.GetComponent<PlayerController>();

      if (player != null)
      {
        player.takeDamage(damage);
      }
      gameObject.SetActive(false);
    }
  }
}
