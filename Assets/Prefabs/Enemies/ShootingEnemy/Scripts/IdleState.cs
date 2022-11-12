using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ShootingEnemy
{
  public class IdleState : State
  {
    public bool playerVisible;
    private bool wait = true;

    public ChaseState chaseState;
    public RunState runState;
    public LayerMask layerMask;
    public Vector3 playerPosition;
    public GameObject body;
    public GameObject player;

    private void Start()
    {
      player = GameObject.FindGameObjectWithTag("Player");
    }

    public override State RunCurrentState()
    {
      playerPosition = player.transform.position;
      float distanceToPlayer = Vector3.Distance(transform.position, playerPosition);
      Vector3 directionToPlayer = playerPosition - transform.position;

      RaycastHit2D playerHit = Physics2D.Raycast(transform.position, directionToPlayer, distanceToPlayer, layerMask);

      playerVisible = playerHit ? playerHit.collider.CompareTag("Player") : false;

      if (wait && playerVisible)
      {
        StartCoroutine(Delay());
      }

      if (!wait && playerVisible)
      {
        if (distanceToPlayer > 6f)
        {
          return chaseState;
        }
        else if (distanceToPlayer < 4f)
        {
          return runState;
        }
      }
      return this;
    }

    private IEnumerator Delay()
    {
      yield return new WaitForSeconds(0.5f);
      wait = false;
    }
  }
}
