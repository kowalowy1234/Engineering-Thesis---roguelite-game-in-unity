using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartRoomDestroyer : MonoBehaviour
{
  private void OnTriggerEnter2D(Collider2D other)
  {
    if (other.CompareTag("RoomSpawner"))
    {
      Destroy(other.gameObject);
    }
  }
}
