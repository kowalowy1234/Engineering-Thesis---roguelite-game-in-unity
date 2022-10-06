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
      int randIndex;
      switch (dir)
      {
        case 1:
          // Spawn top room variation
          randIndex = Random.Range(0, rooms.TR.Length);
          Instantiate(rooms.TR[randIndex], transform.position, Quaternion.identity);
          break;

        case 2:
          // Spawn right room variation
          randIndex = Random.Range(0, rooms.RR.Length);
          Instantiate(rooms.RR[randIndex], transform.position, Quaternion.identity);
          break;

        case 3:
          // Spawn bottom room variation
          randIndex = Random.Range(0, rooms.BR.Length);
          Instantiate(rooms.BR[randIndex], transform.position, Quaternion.identity);
          break;

        case 4:
          // Spawn left room variation
          randIndex = Random.Range(0, rooms.LR.Length);
          Instantiate(rooms.LR[randIndex], transform.position, Quaternion.identity);
          break;

      }
      spawned = true;
    }
  }

  private void OnTriggerEnter2D(Collider2D other)
  {
    if (other.CompareTag("RoomSpawner"))
    {
      Destroy(gameObject);
    }
  }

}
