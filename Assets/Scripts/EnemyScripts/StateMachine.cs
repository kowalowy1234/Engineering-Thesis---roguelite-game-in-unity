using UnityEngine;

public class StateMachine : MonoBehaviour
{
  public State currentState;

  void Update()
  {
    Run();
  }

  void FixedUpdate()
  {
    RunFixed();
  }

  private void Run()
  {
    State nextState = currentState?.RunCurrentState();

    if (nextState != null)
    {
      NextState(nextState);
    }
  }

  private void RunFixed()
  {
    currentState.RunPhysicsState();
  }

  private void NextState(State nextState)
  {
    currentState = nextState;
  }
}
