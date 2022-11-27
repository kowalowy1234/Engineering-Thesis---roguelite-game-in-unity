using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SelectionWindow : MonoBehaviour
{
  public int dungeonNumber;
  public string sceneName;

  private ProgressManager progressManager;

  private void Start()
  {
    progressManager = GameObject.FindGameObjectWithTag("ProgressManager").GetComponent<ProgressManager>();
  }

  public void GoToSolitude()
  {
    if (!progressManager.DungeonCompleted(dungeonNumber))
    {
      progressManager.CompleteLevel(dungeonNumber);
    }

    SceneManager.LoadScene("Solitude");
  }

  public void ReloadLevel()
  {
    if (!progressManager.DungeonCompleted(dungeonNumber))
    {
      progressManager.CompleteLevel(dungeonNumber);
    }

    SceneManager.LoadScene(sceneName);
  }
}
