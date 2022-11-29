using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Boss1
{
  public class PrepareState : State
  {
    [SerializeField]
    private float timeToCharge = 2f;
    private float timeLeft;
    public State chargeState;
    [SerializeField]
    private Rigidbody2D rb;
    [SerializeField]
    private Animator animator;

    private void Start()
    {
      timeLeft = timeToCharge;
    }

    public override State RunCurrentState()
    {
      rb.velocity = Vector3.zero;
      animator.SetBool("prepare", true);
      animator.SetFloat("velocity", 0f);
      if (timeLeft <= 0f)
      {
        timeLeft = timeToCharge;
        return chargeState;
      }
      else
      {
        timeLeft -= Time.deltaTime;
      }
      return this;
    }

    public override void RunPhysicsState()
    {
    }
  }
}

