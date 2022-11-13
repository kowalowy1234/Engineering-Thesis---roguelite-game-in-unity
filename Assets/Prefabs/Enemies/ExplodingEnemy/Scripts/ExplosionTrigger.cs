using System.Collections;
using UnityEngine;

namespace ExplodingEnemy
{
  public class ExplosionTrigger : MonoBehaviour
  {
    public GameObject body;
    public float explosionDamage;
    public float explosionTimer;
    private float explosionCountdown;
    private float distanceToPlayer;
    private Vector3 playerPosition;
    private Vector3 initialScale;

    private void Start()
    {
      explosionCountdown = explosionTimer;
      initialScale = transform.localScale;
    }

    private void Update()
    {
      playerPosition = GameObject.FindGameObjectWithTag("Player").transform.position;
      distanceToPlayer = Vector3.Distance(transform.position, playerPosition);

      float scale = 10 * Time.deltaTime;
      transform.localScale += new Vector3(scale, scale, scale);
      explosionCountdown -= Time.deltaTime;

      if (distanceToPlayer > 5f)
      {
        StopExplosion();
      }
      else if (explosionCountdown <= 0)
      {
        Explode();
      }
    }

    public void Explode()
    {
      gameObject.GetComponent<CircleCollider2D>().enabled = true;
      StartCoroutine(Delay());
    }

    public void StopExplosion()
    {
      StopCoroutine(Delay());
      gameObject.GetComponent<CircleCollider2D>().enabled = false;
      transform.localScale = initialScale;
      explosionCountdown = explosionTimer;
      gameObject.SetActive(false);
    }

    private IEnumerator Delay()
    {
      yield return new WaitForSeconds(0.1f);
      body.GetComponent<Enemy>().die();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
      PlayerController player = other.gameObject.GetComponent<PlayerController>();

      if (player != null)
      {
        player.takeDamage(explosionDamage);
      }
    }

  }
}
