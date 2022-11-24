using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class DeathScreenText : MonoBehaviour
{
  public Text text;
  void Update()
  {
    if (transform.localScale.x > 1f)
    {
      StartCoroutine(LoadSolitude());
    }
    else
    {
      transform.localScale *= 1f + 0.2f * Time.deltaTime;
    }
  }

  private IEnumerator LoadSolitude()
  {
    yield return new WaitForSeconds(1f);
    SceneManager.LoadScene("Solitude");
  }
}
