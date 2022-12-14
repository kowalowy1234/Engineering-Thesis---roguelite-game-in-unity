using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class InGameMenu : MonoBehaviour
{
  public GameObject container;
  public UIManager UIManager;
  private SaveManager saveManager;

  private void Start()
  {
    saveManager = GameObject.FindGameObjectWithTag("SaveManager").GetComponent<SaveManager>();
  }

  public void Continue()
  {
    container.SetActive(false);
    UIManager.currentlyOpen = null;
    Time.timeScale = 1;
  }

  public void GoToMainMenu()
  {
    saveManager.Save();
    Time.timeScale = 1;
    SceneManager.LoadScene("Main menu");
  }

  public void Quit()
  {
    Application.Quit();
  }
}
