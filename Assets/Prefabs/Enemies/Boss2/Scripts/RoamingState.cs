using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Stalker
{
  public class RoamingState : State
  {

    public List<Transform> roamTransforms;
    public List<Vector3> roamPositions;
    public GameObject nextPositionIndicator;
    public Transform body;
    private int currentPositionIndex = 0;
    private int randomIndex = 0;
    private bool canMove = true;

    void Start()
    {
      foreach (Transform transform in roamTransforms)
      {
        roamPositions.Add(transform.position);
      }
    }

    public override State RunCurrentState()
    {
      if (body.position == roamPositions[currentPositionIndex] && canMove)
      {
        while (randomIndex == currentPositionIndex)
        {
          randomIndex = Random.Range(0, roamPositions.Count);
        }
        currentPositionIndex = randomIndex;
        StartCoroutine(WaitBeforeMove());
      }

      return this;
    }

    public override void RunPhysicsState()
    {
    }

    private IEnumerator WaitBeforeMove()
    {
      canMove = false;
      nextPositionIndicator.transform.position = roamPositions[currentPositionIndex];


      yield return new WaitForSeconds(Random.Range(2f, 2.8f));
      nextPositionIndicator.SetActive(true);
      yield return new WaitForSeconds(0.2f);
      nextPositionIndicator.SetActive(false);
      body.position = roamPositions[currentPositionIndex];
      canMove = true;
    }
  }
}
