using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnRoom : MonoBehaviour
{
  public int dir;

  public Rooms rooms;

  private bool spawned = false;

  void Start()
  {
    rooms = GameObject.FindGameObjectWithTag("Rooms").GetComponent<Rooms>();
    Invoke("chooseSpawnRoom", 0.2f);
  }

  void chooseSpawnRoom()
  {
    if (spawned == false)
    {
      if (dir == 1)
      {
        // Spawn top room variation
        int randIndex = Random.Range(0, rooms.TR.Length);
        Instantiate(rooms.TR[randIndex], transform.position, Quaternion.identity);
      }
      else if (dir == 2)
      {
        // Spawn right room variation
        int randIndex = Random.Range(0, rooms.RR.Length);
        Instantiate(rooms.RR[randIndex], transform.position, Quaternion.identity);
      }
      else if (dir == 3)
      {
        // Spawn bottom room variation
        int randIndex = Random.Range(0, rooms.BR.Length);
        Instantiate(rooms.BR[randIndex], transform.position, Quaternion.identity);
      }
      else if (dir == 4)
      {
        // Spawn left room variation
        int randIndex = Random.Range(0, rooms.LR.Length);
        Instantiate(rooms.LR[randIndex], transform.position, Quaternion.identity);
      }
      spawned = true;
    }
  }

  private void OnTriggerEnter2D(Collider2D other)
  {
    if (other.CompareTag("RoomSpawner"))
    {
      Debug.Log("Destroyed");
      Destroy(gameObject);
    }
  }

}
