using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EscapedText : MonoBehaviour
{
  public GameObject Credits;
  public void DeactivateAndShowCredits()
  {
    Credits.SetActive(true);
    gameObject.SetActive(false);
  }
}
