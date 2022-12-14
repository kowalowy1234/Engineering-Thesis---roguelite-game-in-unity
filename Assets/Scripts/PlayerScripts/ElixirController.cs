using UnityEngine;

public class ElixirController : MonoBehaviour
{
  public AudioSource audioSource;
  public AudioClip drinkSound;
  public ElixirTemplate currentElixir;
  private HUDScript hud;
  float cooldownTime;
  float activeTime;
  public int chargesLeft;

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
    hud = GameObject.FindGameObjectWithTag("HUD").GetComponent<HUDScript>();
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
          if (currentElixir.Activate() == true)
          {
            if (audioSource.clip != drinkSound)
            {
              audioSource.clip = drinkSound;
            }
            audioSource.Play();
            currentState = State.iS_ACTIVE;
            activeTime = currentElixir.duration;
            chargesLeft -= 1;
            hud.UpdateElixirCharges(chargesLeft);
          };
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
            currentElixir.Deactivate();
            currentState = State.DEPLETED;
          }
          else
          {
            currentElixir.Deactivate();
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
    currentElixir = newElixir;
    chargesLeft = newElixir.charges;
    currentState = State.READY;
  }

}
