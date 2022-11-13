using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ExplodingEnemy
{
  public class ChaseState : State
  {
    private float distanceToPlayer;
    public float chaseSpeed;

    public ExplodeState explodeState;
    private Vector3 playerPosition;
    public GameObject body;

    public override State RunCurrentState()
    {
      playerPosition = GameObject.FindGameObjectWithTag("Player").transform.position;
      distanceToPlayer = Vector3.Distance(transform.position, playerPosition);

      if (distanceToPlayer <= 1f)
      {
        body.GetComponent<Animator>().SetBool("Exploding", true);
        return explodeState;
      }

      body.transform.position = Vector3.MoveTowards(transform.position, playerPosition, chaseSpeed * Time.deltaTime);
      return this;
    }
  }
}
