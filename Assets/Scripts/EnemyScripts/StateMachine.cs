using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateMachine : MonoBehaviour
{
  public State currentState;

  void Update()
  {
    Run();
  }

  private void Run()
  {
    State nextState = currentState?.RunCurrentState();

    if (nextState != null)
    {
      NextState(nextState);
    }
  }

  private void NextState(State nextState)
  {
    currentState = nextState;
  }
}
