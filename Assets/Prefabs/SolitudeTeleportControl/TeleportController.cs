using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportController : MonoBehaviour
{
  private string dungeonName;

  public TrophyTemplate requiredTrophy;
  public SpriteRenderer spriteRenderer;
  public GameObject interactionPrompt;
  public GameObject teleport;
  private GameController gameController;
  private TeleportsOpened teleportsOpened;
  private GameObject player;


  private void Start()
  {
    gameController = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();
    player = GameObject.FindGameObjectWithTag("Player");
    teleportsOpened = GameObject.FindGameObjectWithTag("TeleportsOpened").GetComponent<TeleportsOpened>();
    spriteRenderer.sprite = requiredTrophy.TrophySprite;
    dungeonName = teleport.GetComponent<Teleporter>().sceneName;

    foreach (SaveManager.TeleportOpenedPair pair in teleportsOpened.teleportsOpenedList)
    {
      if (pair.dungeonName == dungeonName)
      {
        if (pair.isOpened)
        {
          teleport.SetActive(true);
          gameObject.SetActive(false);
        }
        else
        {
          teleport.SetActive(false);
        }
        break;
      }
    }
  }

  private void Update()
  {
    if (Vector2.Distance(transform.position, player.transform.position) <= 0.5f)
    {
      if (Input.GetKeyUp(KeyCode.F) && gameController.carriedTrophy.name == requiredTrophy.name)
      {
        UnlockPortal();
      }
    }
  }

  private void UnlockPortal()
  {
    teleport.SetActive(true);
    gameController.PickUpTrophy(gameController.defaultTrophy);

    foreach (SaveManager.TeleportOpenedPair pair in teleportsOpened.teleportsOpenedList)
    {
      if (pair.dungeonName == dungeonName)
      {
        teleportsOpened.OpenTeleport(dungeonName);
        break;
      }
    }
    gameObject.SetActive(false);
  }
}
