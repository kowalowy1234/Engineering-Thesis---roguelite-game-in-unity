using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
  public GameObject player;
  private Vector3 playerPosition;

  private float xDiff;
  private Vector3 tempScale;

  void Start()
  {
    player = GameObject.FindGameObjectWithTag("Player");
    tempScale = transform.localScale;
  }

  void Update()
  {
    playerPosition = player.transform.position;
    xDiff = playerPosition.x - transform.position.x;

    flipObject(xDiff);
  }

  void flipObject(float xDiff)
  {
    if (xDiff >= 0)
    {
      tempScale.x = -1;
      transform.localScale = tempScale;
    }
    else
    {
      tempScale.x = 1;
      transform.localScale = tempScale;
    }
  }
}
