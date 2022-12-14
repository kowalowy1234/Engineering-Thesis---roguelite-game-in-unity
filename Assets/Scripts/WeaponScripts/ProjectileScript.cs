using UnityEngine;

public class ProjectileScript : MonoBehaviour
{
  public float velocity = 100f;
  public int damage = 10;
  public int damageOverTime = 2;
  public int dotDuration = 2;

  public PlayerController playerController;
  private Rigidbody2D rigidBD;

  private void Awake()
  {
    rigidBD = gameObject.GetComponent<Rigidbody2D>();
  }

  private void Start()
  {
    playerController = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
    rigidBD.velocity = transform.up * velocity;
  }

  private void OnCollisionEnter2D(Collision2D other)
  {
    Enemy enemy = other.gameObject.GetComponent<Enemy>();

    if (enemy != null)
    {
      dealDamage(enemy);
    }
    Destroy(gameObject);
  }

  public virtual void dealDamage(Enemy enemy)
  {
    // Damage logic;
  }
}
