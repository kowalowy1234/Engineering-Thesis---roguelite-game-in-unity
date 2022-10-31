using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
  public GameObject gameController;
  public GameObject saveManager;
  public Button continueButton;

  void Start()
  {
    gameController = GameObject.FindGameObjectWithTag("GameController");
    saveManager = GameObject.FindGameObjectWithTag("SaveManager");

    if (SaveSystem.CanContinueGame() == true)
    {
      continueButton.interactable = true;
    }
    else
    {
      Destroy(saveManager);
    }
  }

  public void StartNewGame()
  {
    SaveSystem.StartNewGame();

    if (gameController != null)
    {
      Destroy(gameController);
    }
    if (saveManager != null)
    {
      Destroy(saveManager);
    }

    SceneManager.LoadScene("Solitude");
  }

  public void ContinueGame()
  {
    SceneManager.LoadScene("Solitude");
  }

  public void Quit()
  {
    Application.Quit();
  }

}
