using UnityEngine;

public class StartRoomDestroyer : MonoBehaviour
{
  private void OnTriggerEnter2D(Collider2D other)
  {
    if (other.CompareTag("RoomSpawner") || other.CompareTag("Blocker"))
    {
      Destroy(other.gameObject);
    }
  }
}
