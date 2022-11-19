using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomGenerator : MonoBehaviour
{
  private int boundUp;
  private int boundDown;
  private int boundRight;
  private int boundLeft;
  public float enemySpawnRate = 0.7f;
  public float chestSpawnRate = 0.1f;
  public int maxEnemies = 5;
  public int maxChests = 3;

  public List<GameObject> enemies = new List<GameObject>();
  public GameObject chest;
  public GameObject roomController;
  [SerializeField]
  private List<Vector3> positions;
  private DungeonGenerator dungeonGenerator;

  private void Start()
  {
    dungeonGenerator = GameObject.FindGameObjectWithTag("DungeonGenerator").GetComponent<DungeonGenerator>();
    boundRight = (int)transform.position.x + 7;
    boundLeft = (int)transform.position.x - 7;

    boundUp = (int)transform.position.y + 4;
    boundDown = (int)transform.position.y - 4;

    for (int i = boundLeft; i <= boundRight; i++)
    {
      for (int j = boundDown; j <= boundUp; j++)
      {
        positions.Add(new Vector3(i, j, 0f));
      }
    }
  }

  private void Update()
  {
    if (dungeonGenerator.spawnedFinish == true || dungeonGenerator == null)
    {
      if (dungeonGenerator.lastRoomPosition != transform.position)
      {
        GenerateRoom();
      }
      Instantiate(roomController, transform.position, Quaternion.identity);
      gameObject.SetActive(false);
    }
  }

  private void GenerateRoom()
  {
    SpawnEnemy();

    for (int i = 0; i < maxEnemies - 1; i++)
    {
      float shouldSpawn = Random.Range(0f, 1f);
      if (shouldSpawn < enemySpawnRate)
      {
        SpawnEnemy();
      }
    }

    if (positions.Count > 0)
    {
      SpawnChest();
    }
    Destroy(gameObject);
  }

  private void SpawnEnemy()
  {
    int positionIndex = Random.Range(0, positions.Count);
    int enemyIndex = Random.Range(0, enemies.Count);
    Vector3 position = positions[positionIndex];
    GameObject enemy = enemies[enemyIndex];
    Instantiate(enemy, position, Quaternion.identity);
    positions.RemoveAt(positionIndex);
  }

  private void SpawnChest()
  {
    float spawnChest = Random.Range(0f, 1f);

    if (spawnChest < chestSpawnRate)
    {
      int positionIndex = Random.Range(0, positions.Count);
      Vector3 position = positions[positionIndex];
      Instantiate(chest, position, Quaternion.identity);
    }
  }
}
