using UnityEngine;

public class ScrollController : MonoBehaviour
{
  public ScrollTemplate currentScroll;
  float cooldownTime;
  float activeTime;

  enum State
  {
    ON_COOLDOWN,
    iS_ACTIVE,
    READY
  }

  State currentState = State.READY;

  void Start()
  {
    currentScroll = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>().currentScroll;
  }

  void Update()
  {
    switch (currentState)
    {
      // Ability ready to be activated
      case State.READY:
        if (Input.GetKeyDown(KeyCode.Q))
        {
          currentScroll.Activate();
          currentState = State.iS_ACTIVE;
          activeTime = currentScroll.duration;
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
          currentState = State.ON_COOLDOWN;
          cooldownTime = currentScroll.cooldown;
        }
        break;

      // Wait for ability's cooldown to go down before using
      case State.ON_COOLDOWN:
        if (cooldownTime > 0)
        {
          cooldownTime -= Time.deltaTime;
        }
        else
        {
          currentState = State.READY;
        }
        break;

      default:
        break;
    }
  }

  public void Swap(ScrollTemplate newScroll)
  {
    Debug.Log("Swapped Scroll to" + newScroll);
    currentScroll = newScroll;
    currentState = State.READY;
  }
}
