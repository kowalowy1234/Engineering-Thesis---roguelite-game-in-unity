using UnityEngine;

namespace ShootingEnemy
{
  public class ChaseState : State
  {
    private float distanceToPlayer;
    public float chaseSpeed;

    public RunState runState;
    public IdleState idleState;
    private Vector3 playerPosition;
    public GameObject player;
    public GameObject body;

    private void Start()
    {
      player = GameObject.FindGameObjectWithTag("Player");
    }

    public override State RunCurrentState()
    {
      playerPosition = player.transform.position;
      distanceToPlayer = Vector3.Distance(transform.position, playerPosition);

      if (distanceToPlayer <= 6f)
      {
        return idleState;
      }

      body.transform.position = Vector3.MoveTowards(transform.position, playerPosition, chaseSpeed * Time.deltaTime);
      // Vector3 direction = playerPosition - transform.position;
      // rb.AddRelativeForce(direction.normalized * chaseSpeed, ForceMode2D.Force);
      return this;
    }

  }
}
