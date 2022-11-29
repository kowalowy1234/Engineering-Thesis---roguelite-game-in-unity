using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Boss1
{
  public class StunnedState : State
  {
    [SerializeField]
    private float stunDuration = 2f;
    private float timeleft;
    public State prepareState;
    [SerializeField]
    private Rigidbody2D rb;
    [SerializeField]
    private Enemy enemyScript;
    [SerializeField]
    private Animator animator;

    private void Start()
    {
      timeleft = stunDuration;
    }

    public override State RunCurrentState()
    {
      rb.velocity = Vector3.zero;
      animator.SetFloat("velocity", 0f);
      animator.SetBool("prepare", false);

      if (timeleft <= 0f)
      {
        timeleft = stunDuration;
        enemyScript.invoulnerable = true;
        return prepareState;
      }
      else
      {
        enemyScript.invoulnerable = false;
        timeleft -= Time.deltaTime;
      }
      return this;
    }

    public override void RunPhysicsState()
    {
    }
  }
}
