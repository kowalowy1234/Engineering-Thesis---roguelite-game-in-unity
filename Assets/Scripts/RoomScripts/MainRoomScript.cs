using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainRoomScript : MonoBehaviour
{

  public GameObject player;

  void Awake()
  {
    Instantiate(player, transform.position, Quaternion.identity);
  }
}
