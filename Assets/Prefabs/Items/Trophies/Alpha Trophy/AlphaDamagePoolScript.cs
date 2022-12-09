using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlphaDamagePoolScript : MonoBehaviour
{
  [SerializeField]
  private int damagePerTick = 2;
  [SerializeField]
  private float timeInterval = 1f;
  private float timeLeft;
  private bool canDealDamage = true;

  private GameObject player;

  private void Awake()
  {
    player = GameObject.FindGameObjectWithTag("Player");
    timeLeft = timeInterval;
  }

  void Update()
  {
    transform.position = player.transform.position;
    if (timeLeft <= 0f)
    {
      canDealDamage = true;
      timeLeft = timeInterval;
    }
    else
    {
      timeLeft -= Time.deltaTime;
    }
  }

  private void OnTriggerStay2D(Collider2D other)
  {
    if (canDealDamage && other.CompareTag("Enemy"))
    {
      other.GetComponent<Enemy>().takeDamage(damagePerTick);
      canDealDamage = false;
    }
  }
}
