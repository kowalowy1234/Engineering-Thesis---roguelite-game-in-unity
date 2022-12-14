using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Boss1
{
  public class ChargeState : State
  {
    [SerializeField]
    private float chargeVelocity = 15f;
    [SerializeField]
    private float chargeDamage = 5f;
    private bool hitWall;
    private bool hitPlayer;
    private bool isCharging;
    public State prepareState;
    public State stunnedState;
    [SerializeField]
    private Rigidbody2D rb;
    private Vector3 playerDestination;
    private Vector3 chargeDirection;
    [SerializeField]
    private CircleCollider2D circleCollider2D;
    [SerializeField]
    private Animator animator;

    public override State RunCurrentState()
    {
      if (hitWall)
      {
        hitWall = false;
        return stunnedState;
      }
      else if (hitPlayer)
      {
        hitPlayer = false;
        return prepareState;
      }

      if (!isCharging)
      {
        playerDestination = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>().playerDestination;
        chargeDirection = (playerDestination - transform.position).normalized;
        rb.velocity = chargeDirection * chargeVelocity;
        isCharging = true;
      }

      animator.SetFloat("velocity", 1f);

      return this;
    }

    public override void RunPhysicsState()
    {
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
      int layerNumber = other.gameObject.layer;
      if (isCharging)
      {
        if (layerNumber == 8 || layerNumber == 12)
        {
          isCharging = false;
          hitWall = true;
          rb.velocity = Vector3.zero;
        }
        else if (other.CompareTag("Player"))
        {
          isCharging = false;
          hitPlayer = true;
          rb.velocity = Vector3.zero;
          other.GetComponent<PlayerController>().takeDamage(chargeDamage);
        }
      }
    }
  }
}

