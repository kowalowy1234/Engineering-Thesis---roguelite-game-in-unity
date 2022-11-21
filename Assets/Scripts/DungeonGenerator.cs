using UnityEngine;
using UnityEngine.SceneManagement;

public class DungeonGenerator : MonoBehaviour
{
  public bool spawnedFinish = false;
  public int minRooms = 5;

  public GameObject loadingScreen;
  public Vector3 lastRoomPosition;
  public System.DateTime lastRoomSpawn;
  public GameObject boss;
  private GameObject player;

  private void Awake()
  {
    loadingScreen.SetActive(true);
  }

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
      loadingScreen.SetActive(false);
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
