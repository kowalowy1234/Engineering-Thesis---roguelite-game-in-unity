using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChaseState : State
{
  private float distanceToPlayer;
  public float chaseSpeed;

  public AttackState attackState;
  private Vector3 playerPosition;
  public GameObject body;

  public override State RunCurrentState()
  {
    playerPosition = GameObject.FindGameObjectWithTag("Player").transform.position;
    distanceToPlayer = Vector3.Distance(transform.position, playerPosition);

    if (distanceToPlayer < 1.3f)
    {
      return attackState;
    }
    body.transform.position = Vector3.MoveTowards(transform.position, playerPosition, chaseSpeed * Time.deltaTime);
    return this;
  }
}
