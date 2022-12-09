using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Alpha
{
  public class SpawningState : State
  {
    public float spawnDelay = 3f;
    private float lastSpawn;
    public int damageOnChildDeath = 10;
    public int maxChildrenCount = 4;
    private int currentChildrenAmount = 0;

    public Enemy bodyProperties;
    public GameObject body;
    public Animator animator;
    public Transform SpawnPosition;
    public GameObject enemyToSpawn;

    private void Start()
    {
      lastSpawn = spawnDelay;
    }

    public override State RunCurrentState()
    {
      if (lastSpawn <= 0f)
      {
        if (currentChildrenAmount < maxChildrenCount)
        {
          animator.SetTrigger("Spawn");
          lastSpawn = spawnDelay;
        }
      }
      else
      {
        lastSpawn -= Time.deltaTime;
      }
      return this;
    }


    public void SpawnEnemy()
    {
      GameObject child = Instantiate(enemyToSpawn, SpawnPosition.position, Quaternion.identity);
      child.GetComponent<Enemy>().Alpha = body;
      currentChildrenAmount += 1;
    }

    public void OnChildDeath()
    {
      bodyProperties.takeDamage(damageOnChildDeath);
      currentChildrenAmount -= 1;
    }

    public override void RunPhysicsState()
    {
    }
  }
}
