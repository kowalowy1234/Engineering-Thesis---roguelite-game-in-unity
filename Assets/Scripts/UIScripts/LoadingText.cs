using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoadingText : MonoBehaviour
{
  public Text text;
  public float animationDelay = 1f;
  private int currentIndex = 0;
  public List<string> textStages = new List<string>();

  void Start()
  {
    InvokeRepeating("ChangeText", 0f, animationDelay);
  }

  private void ChangeText()
  {
    text.text = textStages[currentIndex];

    if (currentIndex + 1 == textStages.Count)
    {
      currentIndex = 0;
    }
    else
    {
      currentIndex += 1;
    }
  }
}
