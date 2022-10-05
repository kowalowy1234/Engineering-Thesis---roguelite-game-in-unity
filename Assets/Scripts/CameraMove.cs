using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{

  public Transform playerPosition;
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

    if (Mathf.Ceil(diffx) > 9f)
    {
      transform.position = new Vector3(transform.position.x + 18f, transform.position.y, transform.position.z);
    }
    else if (Mathf.Ceil(diffx) < -9f)
    {
      transform.position = new Vector3(transform.position.x - 18f, transform.position.y, transform.position.z);
    }
    else if (Mathf.Ceil(diffy) > 6f)
    {
      transform.position = new Vector3(transform.position.x, transform.position.y + 12f, transform.position.z);
    }
    else if (Mathf.Ceil(diffy) < -6f)
    {
      transform.position = new Vector3(transform.position.x, transform.position.y - 12f, transform.position.z);
    }
  }
}
