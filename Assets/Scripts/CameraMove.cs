using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{

  public Transform playerPosition;
  public float xOffset = 18f;
  public float yOffset = 12f;
  private float diffx;
  private float diffy;

  void Start()
  {
    playerPosition = GameObject.FindGameObjectWithTag("Player").transform;
  }

  void Update()
  {
    diffx = playerPosition.position.x - transform.position.x;
    diffy = playerPosition.position.y - transform.position.y;

    if (Mathf.Ceil(diffx) > xOffset / 2)
    {
      transform.position = new Vector3(transform.position.x + xOffset, transform.position.y, transform.position.z);
    }
    else if (Mathf.Ceil(diffx) < -xOffset - 2)
    {
      transform.position = new Vector3(transform.position.x - xOffset, transform.position.y, transform.position.z);
    }
    else if (Mathf.Ceil(diffy) > yOffset / 2)
    {
      transform.position = new Vector3(transform.position.x, transform.position.y + yOffset, transform.position.z);
    }
    else if (Mathf.Ceil(diffy) < -yOffset / 2)
    {
      transform.position = new Vector3(transform.position.x, transform.position.y - yOffset, transform.position.z);
    }
  }
}
