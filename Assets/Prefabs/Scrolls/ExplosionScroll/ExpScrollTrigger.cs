using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExpScrollTrigger : MonoBehaviour
{
  public int damage = 15;
  void Start()
  {
    StartCoroutine(Delay());
  }

  void Update()
  {
    transform.localScale += transform.localScale * 20f * Time.deltaTime;
  }

  private IEnumerator Delay()
  {
    yield return new WaitForSeconds(0.1f);
    Destroy(gameObject);
  }

  private void OnTriggerEnter2D(Collider2D other)
  {
    if (other.CompareTag("Enemy"))
    {
      other.GetComponent<Enemy>().takeDamage(damage);
    }
  }
}
