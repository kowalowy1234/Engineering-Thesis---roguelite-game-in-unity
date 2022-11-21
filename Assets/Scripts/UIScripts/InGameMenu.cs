using UnityEngine;
using UnityEngine.SceneManagement;

public class InGameMenu : MonoBehaviour
{
  public GameObject container;
  private SaveManager saveManager;

  private void Start()
  {
    saveManager = GameObject.FindGameObjectWithTag("SaveManager").GetComponent<SaveManager>();
  }

  private void Update()
  {
    if (Input.GetKeyDown(KeyCode.Escape))
    {
      if (container.activeSelf)
      {
        container.SetActive(false);
        Time.timeScale = 1;
      }
      else
      {
        container.SetActive(true);
        Time.timeScale = 0;
      }
    }
  }

  public void Continue()
  {
    container.SetActive(false);
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
