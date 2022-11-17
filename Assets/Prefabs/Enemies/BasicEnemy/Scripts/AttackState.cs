using System.Collections;
using UnityEngine;

namespace BasicEnemy
{
  public class AttackState : State
  {
    public float damage = 4f;
    private float distanceToPlayer;
    private bool isAttacking;
    private bool performedAttack;

    public ChaseState chaseState;
    public GameObject body;
    private GameObject player;
    private Vector3 playerPosition;
    private Animator animator;

    private void Start()
    {
      player = GameObject.FindGameObjectWithTag("Player");
      animator = body.GetComponent<Animator>();
    }

    public override State RunCurrentState()
    {
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
