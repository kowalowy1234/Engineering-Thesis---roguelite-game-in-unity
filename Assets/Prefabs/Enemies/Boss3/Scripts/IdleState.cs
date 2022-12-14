using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Alpha
{
  public class IdleState : State
  {
    private bool wait = true;
    private bool playerVisible;
    private float distanceToPlayer;

    public LayerMask layerMask;
    public SpawningState spawningState;
    private Vector3 playerPosition;
    private GameObject player;
    private RaycastHit2D playerHit;
    private Vector3 directionToPlayer;

    private void Start()
    {
      player = GameObject.FindGameObjectWithTag("Player");
    }

    public override State RunCurrentState()
    {
      playerPosition = player.transform.position;
      directionToPlayer = playerPosition - transform.position;
      distanceToPlayer = Vector3.Distance(transform.position, playerPosition);
      playerHit = Physics2D.Raycast(transform.position, directionToPlayer, distanceToPlayer, layerMask);
      playerVisible = playerHit ? playerHit.collider.CompareTag("Player") : false;

      if (wait && playerVisible)
      {
        StartCoroutine(Delay());
      }

      if (!wait && playerVisible)
      {
        return spawningState;
      }

      return this;
    }

    public override void RunPhysicsState()
    {
    }

    private IEnumerator Delay()
    {
      yield return new WaitForSeconds(0.5f);
      wait = false;
    }
  }
}
