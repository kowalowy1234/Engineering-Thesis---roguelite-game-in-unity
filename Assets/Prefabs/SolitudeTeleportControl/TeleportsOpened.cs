using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportsOpened : MonoBehaviour
{

  public List<SaveManager.TeleportOpenedPair> teleportsOpenedList = new List<SaveManager.TeleportOpenedPair>();
  private SaveManager saveManager;

  private void Awake()
  {
    saveManager = GameObject.FindGameObjectWithTag("SaveManager").GetComponent<SaveManager>();
    teleportsOpenedList = saveManager.teleportsOpenedList;
  }

  public void OpenTeleport(string dungeonName)
  {
    foreach (SaveManager.TeleportOpenedPair pair in saveManager.teleportsOpenedList)
    {
      if (dungeonName == pair.dungeonName)
      {
        pair.isOpened = true;
        break;
      }
    }
  }
}
