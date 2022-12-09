using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlphaScript : MonoBehaviour
{

  public Alpha.SpawningState spawningState;

  public void SpawnEnemy()
  {
    spawningState.SpawnEnemy();
  }

  public void DealDamageToParent()
  {
    spawningState.OnChildDeath();
  }
}
