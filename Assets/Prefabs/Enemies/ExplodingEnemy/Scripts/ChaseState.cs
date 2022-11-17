using UnityEngine;

namespace ExplodingEnemy
{
  public class ChaseState : State
  {
    private float distanceToPlayer;
    public float chaseSpeed;

    public ExplodeState explodeState;
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

      if (distanceToPlayer <= 1.5f)
      {
        body.GetComponent<Animator>().SetBool("Exploding", true);
        return explodeState;
      }

      body.transform.position = Vector3.MoveTowards(transform.position, playerPosition, chaseSpeed * Time.deltaTime);
      return this;
    }
  }
}
