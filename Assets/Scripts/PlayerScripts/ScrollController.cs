using UnityEngine;

public class ScrollController : MonoBehaviour
{
  public ScrollTemplate currentScroll;
  private HUDScript hud;
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
    hud = GameObject.FindGameObjectWithTag("HUD").GetComponent<HUDScript>();
    currentState = State.READY;
  }

  void Update()
  {
    switch (currentState)
    {
      // Ability ready to be activated
      case State.READY:
        if (Input.GetKeyDown(KeyCode.Q))
        {
          if (currentScroll.Activate() == true)
          {
            currentState = State.iS_ACTIVE;
            activeTime = currentScroll.duration;

            string cooldownString = "";
            cooldownString = currentScroll.cooldown.ToString("F0");
            hud.UpdateScrollCooldown(cooldownString);
          }
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
          currentScroll.Deactivate();
          currentState = State.ON_COOLDOWN;
          cooldownTime = currentScroll.cooldown;
        }
        break;

      // Wait for ability's cooldown to go down before using
      case State.ON_COOLDOWN:
        if (cooldownTime > 0)
        {
          cooldownTime -= Time.deltaTime;
          string cooldownString = "";
          cooldownString = cooldownTime.ToString("F0");
          hud.UpdateScrollCooldown(cooldownString);
        }
        else
        {
          currentState = State.READY;
          hud.UpdateScrollCooldown("0");
        }
        break;

      default:
        break;
    }
  }

  public void Swap(ScrollTemplate newScroll)
  {
    Debug.Log("Swapped Scroll to" + newScroll);
    hud.UpdateScrollCooldown("0");
    currentScroll = newScroll;
    currentState = State.READY;
  }
}
