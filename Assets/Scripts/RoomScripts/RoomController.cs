using System.Collections.Generic;
using UnityEngine;

public class RoomController : MonoBehaviour
{
  public List<GameObject> doors = new List<GameObject>();
  public List<GameObject> enemies = new List<GameObject>();

  private void OnTriggerEnter2D(Collider2D other)
  {
    Physics2D.IgnoreCollision(gameObject.GetComponent<Collider2D>(), other);
    if (other.CompareTag("Player"))
    {
      if (enemies.Count != 0)
      {
        CloseDoors();
      }
    }
    else if (other.CompareTag("Enemy"))
    {
      enemies.Add(other.gameObject);
      other.transform.SetParent(transform);
    }
    else if (other.CompareTag("Door"))
    {
      doors.Add(other.gameObject);
    }
  }

  public void Kill(GameObject enemy)
  {
    enemies.Remove(enemy);
    if (enemies.Count == 0)
    {
      OpenDoors();
      gameObject.SetActive(false);
    }
  }

  private void OpenDoors()
  {
    foreach (GameObject doorController in doors)
    {
      doorController.GetComponent<DoorController>().openDoor();
    }
  }

  private void CloseDoors()
  {
    foreach (GameObject doorController in doors)
    {
      doorController.GetComponent<DoorController>().closeDoor();
    }
  }
}
