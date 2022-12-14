using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopObject : MonoBehaviour
{
  public UIManager UIManager;
  public GameObject Shop;
  private GameObject player;
  private Vector3 playerPosition;

  void Start()
  {
    GameObject.FindGameObjectWithTag("SaveManager").GetComponent<SaveManager>().Save();
    player = GameObject.FindGameObjectWithTag("Player");
  }

  void Update()
  {
    playerPosition = player.transform.position;

    if (Vector3.Distance(transform.position, playerPosition) < 1f)
    {
      if (Input.GetKeyDown(KeyCode.F))
      {
        UIManager.SetUIAsActive(Shop);
      }
    }
  }
}
