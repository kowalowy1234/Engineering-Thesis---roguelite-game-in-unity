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
    public GameObject body;
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

      Vector3 destination = (transform.position - playerPosition).normalized;

      if (!stopMoving)
      {
        body.transform.position = Vector3.MoveTowards(transform.position, transform.position + destination, chaseSpeed * Time.deltaTime);
      }

      return this;
    }

    private void OnTriggerStay2D(Collider2D other)
    {
      if (other.gameObject.layer == 8 || other.gameObject.layer == 12)
      {
        stopMoving = true;
      }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
      if (other.gameObject.layer == 8 || other.gameObject.layer == 12)
      {
        stopMoving = false;
      }
    }
  }
}
