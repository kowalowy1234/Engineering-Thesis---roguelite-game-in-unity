using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BasicEnemy
{
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

      if (distanceToPlayer >= 1.7f && !isAttacking)
      {
        return chaseState;
      }

      if (distanceToPlayer <= 1.7f && !isAttacking)
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
      StartCoroutine(CurrentlyAttacking(playerPosition));
      StartCoroutine(NextAttackDelay());
    }

    private IEnumerator CurrentlyAttacking(Vector3 designatedPosition)
    {
      performedAttack = true;
      Animator animator = body.GetComponent<Animator>();
      animator.SetTrigger("Attack");
      yield return new WaitForSeconds(0.3f);
      designatedPosition.y += 0.5f;
      body.transform.position = designatedPosition;

      if (distanceToPlayer <= 2f)
      {
        player.GetComponent<PlayerController>().takeDamage(damage);
      }
      isAttacking = false;
    }

    private IEnumerator NextAttackDelay()
    {
      yield return new WaitForSeconds(0.6f);
      performedAttack = false;
    }
  }
}
