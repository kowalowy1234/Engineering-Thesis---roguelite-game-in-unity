using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MoveAndFinish : MonoBehaviour
{
  public float y = 900f;
  public float moveSpeed = 1f;
  public RectTransform rectTransform;

  // Update is called once per frame
  void Update()
  {
    Debug.Log(rectTransform.position.y);
    if (rectTransform.position.y >= y)
    {
      SceneManager.LoadScene("Main menu");
    }

    if (Input.GetKeyUp(KeyCode.Escape))
    {
      SceneManager.LoadScene("Main menu");
    }

    rectTransform.position = new Vector3(rectTransform.position.x, rectTransform.position.y + moveSpeed * Time.deltaTime, 0f);
  }
}
