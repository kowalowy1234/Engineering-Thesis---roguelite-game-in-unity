using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackState : State
{
  private float distanceToPlayer;
  private bool isAttacking;
  private bool performedAttack;
  public float damage = 4f;

  public ChaseState chaseState;
  private GameObject player;
  private Vector3 playerPosition;
  public GameObject body;

  public override State RunCurrentState()
  {
    player = GameObject.FindGameObjectWithTag("Player");
    playerPosition = player.transform.position;
    distanceToPlayer = Vector3.Distance(transform.position, playerPosition);

    if (distanceToPlayer >= 1.3f && !isAttacking)
    {
      return chaseState;
    }

    if (distanceToPlayer < 1.3f && !isAttacking)
    {
      if (performedAttack == false)
      {
        Attack();
      }
    }
    return this;
  }

  private void Attack()
  {
    isAttacking = true;
    performedAttack = true;
    StartCoroutine(CurrentlyAttacking());
    StartCoroutine(NextAttackDelay());
  }

  private IEnumerator CurrentlyAttacking()
  {
    performedAttack = true;
    Animator animator = body.GetComponent<Animator>();
    animator.SetTrigger("Attack");
    yield return new WaitForSeconds(0.3f);
    if (distanceToPlayer <= 2f)
    {
      player.GetComponent<PlayerController>().takeDamage(damage);
    }
    isAttacking = false;
  }

  private IEnumerator NextAttackDelay()
  {
    yield return new WaitForSeconds(1f);
    performedAttack = false;
  }
}
