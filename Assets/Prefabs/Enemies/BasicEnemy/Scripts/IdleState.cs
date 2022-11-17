using System.Collections;
using UnityEngine;

namespace BasicEnemy
{
  public class IdleState : State
  {
    public bool playerVisible;
    private bool wait = true;
    private float distanceToPlayer;

    public ChaseState chaseState;
    public LayerMask layerMask;
    public GameObject body;
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
      distanceToPlayer = Vector3.Distance(transform.position, playerPosition);
      directionToPlayer = playerPosition - transform.position;

      playerHit = Physics2D.Raycast(transform.position, directionToPlayer, distanceToPlayer, layerMask);
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
}
