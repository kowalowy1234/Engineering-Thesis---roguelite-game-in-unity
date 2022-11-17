using UnityEngine;

namespace ExplodingEnemy
{
  public class ExplodeState : State
  {
    private float distanceToPlayer;

    public GameObject explosionTrigger;
    public ChaseState chaseState;
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

      if (distanceToPlayer > 5f)
      {
        body.GetComponent<Animator>().SetBool("Exploding", false);
        return chaseState;
      }
      Explode();
      return this;
    }

    public void Explode()
    {
      explosionTrigger.SetActive(true);
    }
  }
}
