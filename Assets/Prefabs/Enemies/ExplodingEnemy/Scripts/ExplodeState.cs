using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ExplodingEnemy
{
  public class ExplodeState : State
  {
    private float distanceToPlayer;
    public GameObject explosionTrigger;
    public ChaseState chaseState;
    private Vector3 playerPosition;
    public GameObject body;

    public override State RunCurrentState()
    {
      playerPosition = GameObject.FindGameObjectWithTag("Player").transform.position;
      distanceToPlayer = Vector3.Distance(transform.position, playerPosition);

      if (distanceToPlayer > 5f)
      {
        body.GetComponent<Animator>().SetBool("Exploding", false);
        return chaseState;
      }
      Explode();
      return this;
    }

    public void Explode()
    {
      explosionTrigger.SetActive(true);
    }
  }
}
