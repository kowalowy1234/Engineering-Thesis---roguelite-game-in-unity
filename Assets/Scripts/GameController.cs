using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
  public static GameController instance;
  // private bool isDungeon;
  // public float lastRoomSpawn;
  // public Vector3 lastRoomPosition;
  // public GameObject boss;
  // private bool spawnedFinish = false;

  void Awake()
  {
    if (instance == null)
    {
      instance = this;
      DontDestroyOnLoad(gameObject);
    }
    else if (instance != null)
    {
      Destroy(gameObject);
    }
  }

  void Update()
  {
    // isDungeon = SceneManager.GetActiveScene().name.StartsWith("Dungeon");
    // if (Time.time - lastRoomSpawn > 1 && !spawnedFinish)
    // {
    //   SpawnBossOrPortal();
    //   DestroySpawners();
    // }
  }

  // private void SpawnBossOrPortal()
  // {
  //   Instantiate(boss, lastRoomPosition, Quaternion.identity);
  //   spawnedFinish = true;
  // }

  // private void DestroySpawners()
  // {
  //   GameObject[] roomSpawners = GameObject.FindGameObjectsWithTag("RoomSpawner");
  //   foreach (var spawner in roomSpawners)
  //   {
  //     Destroy(spawner);
  //   }
  // }
}
