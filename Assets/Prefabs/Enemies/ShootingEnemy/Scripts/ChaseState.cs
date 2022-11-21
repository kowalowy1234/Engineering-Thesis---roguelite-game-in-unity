using UnityEngine;

namespace ShootingEnemy
{
  public class ChaseState : State
  {
    public float chaseSpeed;
    private float distanceToPlayer;

    public RunState runState;
    public IdleState idleState;
    public Rigidbody2D rb;
    private Vector3 playerPosition;
    private GameObject player;

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

      // body.transform.position = Vector3.MoveTowards(transform.position, playerPosition, chaseSpeed * Time.deltaTime);
      return this;
    }

    public override void RunPhysicsState()
    {
      rb.velocity = (playerPosition - transform.position).normalized * chaseSpeed;
    }
  }
}
