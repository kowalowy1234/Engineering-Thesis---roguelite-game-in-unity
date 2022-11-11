using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
  private float xDiff;

  public GameObject player;
  private Vector3 playerPosition;
  private Vector3 tempScale;
  private SpriteRenderer spriteRenderer;

  void Start()
  {
    player = GameObject.FindGameObjectWithTag("Player");
    spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
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
      spriteRenderer.flipX = false;
    }
    else
    {
      spriteRenderer.flipX = true;
    }
  }
}
