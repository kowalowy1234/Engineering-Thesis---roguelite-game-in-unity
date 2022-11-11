using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleState : State
{
  public bool playerVisible;
  private bool wait = true;

  public ChaseState chaseState;
  public LayerMask layerMask;
  public Vector3 playerPosition;
  public GameObject body;

  public override State RunCurrentState()
  {
    playerPosition = GameObject.FindGameObjectWithTag("Player").transform.position;
    float distanceToPlayer = Vector3.Distance(transform.position, playerPosition);
    Vector3 directionToPlayer = playerPosition - transform.position;

    directionToPlayer.y += 0.1f;

    RaycastHit2D playerHit = Physics2D.Raycast(transform.position, directionToPlayer, distanceToPlayer, layerMask);
    Debug.DrawRay(transform.position, directionToPlayer, Color.black);

    playerVisible = playerHit ? playerHit.collider.CompareTag("Player") : false;

    if (wait && playerVisible)
    {
      StartCoroutine(Delay());
    }

    if (!wait && playerVisible)
    {
      return chaseState;
    }
    return this;
  }

  private IEnumerator Delay()
  {
    yield return new WaitForSeconds(0.5f);
    wait = false;
  }
}
