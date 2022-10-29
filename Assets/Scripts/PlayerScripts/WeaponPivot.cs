using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponPivot : MonoBehaviour
{

  bool faceLeft = false;

  public GameObject parentPlayer;
  private Camera mainCamera;

  private void Start()
  {
    mainCamera = Camera.main;
  }

  private void FixedUpdate()
  {
    // Flip sprite accordingly
    Vector3 diff = mainCamera.ScreenToWorldPoint(Input.mousePosition) - transform.position;

    if (diff.x >= 0 && faceLeft == true)
    {
      parentPlayer.GetComponent<SpriteRenderer>().flipX = false;
      faceLeft = false;
    }
    else if (diff.x < 0 && faceLeft == false)
    {
      parentPlayer.GetComponent<SpriteRenderer>().flipX = true;
      faceLeft = true;
    }

    // rotation logic of weapon pivot
    diff.Normalize();

    float rotZ = Mathf.Atan2(diff.y, diff.x) * Mathf.Rad2Deg;

    transform.rotation = Quaternion.Euler(0f, 0f, rotZ);

    if (rotZ < -90 || rotZ > 90)
    {
      if (parentPlayer.transform.eulerAngles.y == 0)
      {
        transform.localRotation = Quaternion.Euler(180, 0, -rotZ);
      }
    }
  }
}
