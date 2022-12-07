using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StalkerShieldScript : MonoBehaviour
{
  [SerializeField]
  private float rotationSpeed;
  private GameObject player;

  private void Awake()
  {
    player = GameObject.FindGameObjectWithTag("Player");
  }

  void Update()
  {
    transform.position = player.transform.position;
    transform.Rotate(new Vector3(0f, 0f, rotationSpeed * Time.deltaTime));
  }

  void OnTriggerEnter2D(Collider2D other)
  {
    float randomNumber = Random.Range(0f, 1f);
    Debug.Log("bruh");
    if (other.gameObject.layer == 16 && randomNumber >= 0.7f)
    {
      other.gameObject.SetActive(false);
    }
  }
}
