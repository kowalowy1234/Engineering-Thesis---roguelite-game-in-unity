using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishTeleporter : MonoBehaviour
{
  private float distanceToPlayer;
  public int dungeonNumber;
  public string sceneName;

  public GameObject SelectionWindow;
  public UIManager UIManager;
  private GameObject player;
  private Vector3 playerPosition;
  // Start is called before the first frame update

  void Start()
  {
    player = GameObject.FindGameObjectWithTag("Player");
    UIManager = GameObject.FindGameObjectWithTag("UIManager").GetComponent<UIManager>();
    SelectionWindow = Instantiate(SelectionWindow);
    SelectionWindow.GetComponent<SelectionWindow>().dungeonNumber = dungeonNumber;
    SelectionWindow.GetComponent<SelectionWindow>().sceneName = sceneName;
  }

  // Update is called once per frame
  void Update()
  {
    playerPosition = player.transform.position;
    distanceToPlayer = Vector3.Distance(playerPosition, transform.position);

    if (distanceToPlayer <= 1.5f)
    {
      if (Input.GetKeyUp(KeyCode.F))
      {
        UIManager.SetUIAsActive(SelectionWindow);
      }
    }
  }
}

