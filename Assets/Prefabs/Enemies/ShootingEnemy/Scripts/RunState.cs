using UnityEngine;

namespace ShootingEnemy
{
  public class RunState : State
  {
    private float distanceToPlayer;
    public float chaseSpeed;
    public bool stopMoving;

    public ChaseState chaseState;
    public IdleState idleState;
    public Rigidbody2D rb;
    private Vector3 destination;
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

      if (distanceToPlayer >= 4f)
      {
        stopMoving = false;
        return idleState;
      }

      destination = (transform.position - playerPosition).normalized;

      return this;
    }

    public override void RunPhysicsState()
    {
      rb.velocity = destination * chaseSpeed;
    }
  }
}
