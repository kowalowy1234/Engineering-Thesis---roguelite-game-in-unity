using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpinScript : MonoBehaviour
{
  public float spinSpeed;
  public int spinDirection;

  // Update is called once per frame
  void Update()
  {
    transform.Rotate(new Vector3(0f, 0f, spinSpeed * (float)spinDirection * Time.deltaTime));
  }
}
