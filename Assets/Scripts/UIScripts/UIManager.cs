using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
  public GameObject inGameMenu;
  public GameObject currentlyOpen;

  void Update()
  {
    if (Input.GetKeyDown(KeyCode.Escape))
    {
      if (currentlyOpen != null)
      {
        currentlyOpen.SetActive(false);
        currentlyOpen = null;
        Time.timeScale = 1;
      }
      else
      {
        currentlyOpen = inGameMenu.GetComponent<InGameMenu>().container;
        currentlyOpen.SetActive(true);
        Time.timeScale = 0;
      }
    }
  }

  public void SetUIAsActive(GameObject UI)
  {
    if (currentlyOpen == null)
    {
      currentlyOpen = UI;
      currentlyOpen.SetActive(true);
      Time.timeScale = 0;
    }
    else
    {
      return;
    }
  }
}
