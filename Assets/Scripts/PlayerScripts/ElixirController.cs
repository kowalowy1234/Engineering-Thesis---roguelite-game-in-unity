using UnityEngine;

public class ElixirController : MonoBehaviour
{

  public ElixirTemplate currentElixir;
  float cooldownTime;
  float activeTime;
  int chargesLeft;

  enum State
  {
    DEPLETED,
    iS_ACTIVE,
    READY
  }

  State currentState = State.READY;

  void Start()
  {
    currentElixir = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>().currentElixir;
    chargesLeft = currentElixir.charges;
    if (chargesLeft == 0)
    {
      currentState = State.DEPLETED;
    }
  }

  void Update()
  {
    switch (currentState)
    {
      // Ability ready to be activated
      case State.READY:
        if (Input.GetKeyDown(KeyCode.E))
        {
          currentElixir.Activate();
          currentState = State.iS_ACTIVE;
          activeTime = currentElixir.duration;
          chargesLeft -= 1;
          Debug.Log("Charges left: " + chargesLeft);
        }
        break;

      // Ability is being executed
      case State.iS_ACTIVE:
        if (activeTime > 0)
        {
          activeTime -= Time.deltaTime;
        }
        else
        {
          if (chargesLeft == 0)
          {
            currentState = State.DEPLETED;
          }
          else
          {
            currentState = State.READY;
          }
        }
        break;

      default:
        break;
    }
  }

  public void Swap(ElixirTemplate newElixir)
  {
    Debug.Log("Swapped Elixir to" + newElixir);
    currentElixir = newElixir;
    chargesLeft = newElixir.charges;
    currentState = State.READY;
  }

}
