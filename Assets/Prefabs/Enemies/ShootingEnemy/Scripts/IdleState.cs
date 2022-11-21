using System.Collections;
using UnityEngine;

namespace ShootingEnemy
{
  public class IdleState : State
  {
    private bool playerVisible;
    private bool wait = true;
    private float distanceToPlayer;

    public ChaseState chaseState;
    public RunState runState;
    public LayerMask layerMask;
    public Shoot shootingComponent;
    public Rigidbody2D rb;
    private Vector3 playerPosition;
    private GameObject player;
    private Vector3 directionToPlayer;
    private RaycastHit2D playerHit;

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
      shootingComponent.StartShooting();
    }

    public override void RunPhysicsState()
    {
      rb.velocity = Vector2.zero;
    }
  }
}
