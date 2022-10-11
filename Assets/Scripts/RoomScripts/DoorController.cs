using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorController : MonoBehaviour
{

  public bool isOpen = false;
  public LayerMask layerMask;
  private bool blocked = false;

  private void Update()
  {
    checkIfHitWall();
    if (isOpen == true)
    {
      gameObject.GetComponent<BoxCollider2D>().enabled = false;
      gameObject.GetComponent<SpriteRenderer>().color = Color.green;
    }
    else
    {
      gameObject.GetComponent<BoxCollider2D>().enabled = true;
      gameObject.GetComponent<SpriteRenderer>().color = Color.red;
    }
  }

  public void openDoor()
  {
    if (blocked == false)
    {
      isOpen = true;
    }
  }

  public void closeDoor()
  {
    isOpen = false;
  }

  public void checkIfHitWall()
  {
    RaycastHit2D hitWall1 = Physics2D.Raycast(transform.position, new Vector2(-1, 0), 0.9f, layerMask);
    RaycastHit2D hitWall2 = Physics2D.Raycast(transform.position, new Vector2(1, 0), 0.9f, layerMask);
    RaycastHit2D hitWall3 = Physics2D.Raycast(transform.position, new Vector2(0, -1), 0.9f, layerMask);
    RaycastHit2D hitWall4 = Physics2D.Raycast(transform.position, new Vector2(0, 1), 0.9f, layerMask);

    if (hitWall1.collider || hitWall2.collider || hitWall3.collider || hitWall4.collider)
    {
      closeDoor();
      blocked = true;
    }
  }

}
