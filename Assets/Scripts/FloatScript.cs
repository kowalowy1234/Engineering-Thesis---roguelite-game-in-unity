using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatScript : MonoBehaviour
{
  public float speed = 1f;
  public List<Transform> roamTransforms;
  public List<Vector3> roamPositions;
  private int currentPositionIndex = 0;
  private int randomIndex = 0;

  void Start()
  {
    foreach (Transform transform in roamTransforms)
    {
      roamPositions.Add(transform.position);
    }
  }

  void Update()
  {
    if (transform.position == roamPositions[currentPositionIndex])
    {
      while (randomIndex == currentPositionIndex)
      {
        randomIndex = Random.Range(0, roamPositions.Count);
      }
      currentPositionIndex = randomIndex;
    }

    transform.position = Vector3.MoveTowards(transform.position, roamPositions[currentPositionIndex], speed);
  }
}
