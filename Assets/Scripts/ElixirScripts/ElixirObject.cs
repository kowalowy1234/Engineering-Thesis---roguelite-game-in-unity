using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElixirObject : MonoBehaviour
{

  private GameObject player;
  private Vector3 playerPosition;
  private GameController gameController;
  [SerializeField]
  private ElixirTemplate elixirData;

  private void Awake()
  {
    gameObject.GetComponent<SpriteRenderer>().sprite = elixirData.sprite;
    gameController = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();
    player = GameObject.FindGameObjectWithTag("Player");
  }

  void Update()
  {
    playerPosition = player.transform.position;
    float distanceToPlayer = Vector3.Distance(transform.position, playerPosition);
    if (distanceToPlayer < 1 && Input.GetKey(KeyCode.F))
    {
      if (gameController.currentElixir.name != elixirData.name)
      {
        gameController.SwapElixir(elixirData);
        Destroy(gameObject);
      }
    }
  }
}
