using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
  public float lastRoomSpawn;
  public Vector3 lastRoomPosition;
  public GameObject boss;
  private bool spawnedFinish = false;

  void Start()
  {

  }

  void Update()
  {
    if (Time.time - lastRoomSpawn > 1 && !spawnedFinish)
    {
      SpawnBossOrPortal();
      DestroySpawners();
    }
  }

  private void SpawnBossOrPortal()
  {
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
