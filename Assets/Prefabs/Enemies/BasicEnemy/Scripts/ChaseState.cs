using UnityEngine;

namespace BasicEnemy
{
  public class ChaseState : State
  {
    public float chaseSpeed;
    private float distanceToPlayer;

    public AttackState attackState;
    public GameObject body;
    private GameObject player;
    private Vector3 playerPosition;

    private void Start()
    {
      player = GameObject.FindGameObjectWithTag("Player");
    }

    public override State RunCurrentState()
    {
      playerPosition = player.transform.position;
      distanceToPlayer = Vector3.Distance(transform.position, playerPosition);

      if (distanceToPlayer <= 1.7f)
      {
        return attackState;
      }

      body.transform.position = Vector3.MoveTowards(transform.position, playerPosition, chaseSpeed * Time.deltaTime);
      return this;
    }
  }
}
