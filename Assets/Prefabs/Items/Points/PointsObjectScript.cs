using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointsObjectScript : MonoBehaviour
{

  private GameController gameController;

  public int minPoints;
  public int maxPoints;
  int generatedPoints;

  private void Start()
  {
    gameController = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();
    generatedPoints = Mathf.FloorToInt(Random.Range(minPoints, maxPoints) * gameController.bonusPointsModificator);
    gameController.points += generatedPoints;
    Debug.Log("Gained " + generatedPoints + " points");
    Destroy(gameObject);
  }
}
