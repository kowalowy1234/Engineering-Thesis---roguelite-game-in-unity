using UnityEngine;
using UnityEngine.SceneManagement;

public class DungeonGenerator : MonoBehaviour
{
  public System.DateTime lastRoomSpawn;
  public int minRooms = 5;
  public Vector3 lastRoomPosition;
  public GameObject boss;
  public bool spawnedFinish = false;
  private GameObject player;

  private void Start()
  {
    player = GameObject.FindGameObjectWithTag("Player");
    player.GetComponent<PlayerMovement>().enabled = false;
  }

  void Update()
  {
    if ((int)(System.DateTime.Now - lastRoomSpawn).TotalSeconds >= 1 && !spawnedFinish)
    {
      SpawnBossOrPortal();
      DestroySpawners();
      player.GetComponent<PlayerMovement>().enabled = true;
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
