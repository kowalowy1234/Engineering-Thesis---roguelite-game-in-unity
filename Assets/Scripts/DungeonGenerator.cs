using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DungeonGenerator : MonoBehaviour
{
  public float lastRoomSpawn;
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