using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldScript : MonoBehaviour
{
  [SerializeField]
  private float rotationSpeed;

  // Update is called once per frame
  void Update()
  {
    transform.Rotate(new Vector3(0f, 0f, rotationSpeed * Time.deltaTime));
  }

  void OnTriggerEnter(Collider other)
  {
    if (other.gameObject.layer == 16)
    {
      other.gameObject.SetActive(false);
    }
  }
}
