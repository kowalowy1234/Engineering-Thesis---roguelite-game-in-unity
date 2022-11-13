using UnityEngine;
using UnityEngine.SceneManagement;

public class DungeonGenerator : MonoBehaviour
{
  public float lastRoomSpawn;
  public int minRooms = 5;
  public Vector3 lastRoomPosition;
  public GameObject boss;
  private bool spawnedFinish = false;

  void Update()
  {
    if (Time.timeSinceLevelLoad - lastRoomSpawn > 1 && !spawnedFinish)
    {
      SpawnBossOrPortal();
      DestroySpawners();
    }
  }

  private void SpawnBossOrPortal()
  {
    GameObject[] rooms = GameObject.FindGameObjectsWithTag("Room");

    if (rooms.Length <= minRooms)
    {
      SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    Instantiate(boss, lastRoomPosition, Quaternion.identity);
    spawnedFinish = true;
  }

  private void DestroySpawners()
  {
    GameObject[] roomSpawners = GameObject.FindGameObjectsWithTag("RoomSpawner");
    foreach (var spawner in roomSpawners)
    {
      Destroy(spawner);
    }
  }
}
