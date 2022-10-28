using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
  public static GameController instance;
  public WeaponTemplate currentWeapon;
  private WeaponScript weaponController;
  public ScrollTemplate currentScroll;
  private ScrollController scrollController;
  public ElixirTemplate currentElixir;
  private ElixirController elixirController;
  public GameObject player;
  // Passive boss trophy goes here (not yet implemented)
  public int currentTrophy;

  void Start()
  {
    player = GameObject.FindGameObjectWithTag("Player");
    scrollController = player.GetComponent<ScrollController>();
    elixirController = player.GetComponent<ElixirController>();
    weaponController = GameObject.FindGameObjectWithTag("WeaponController").GetComponent<WeaponScript>();

    if (instance == null)
    {
      instance = this;
      DontDestroyOnLoad(gameObject);
    }
    else if (instance != null)
    {
      Destroy(gameObject);
    }
  }

  void Update()
  {
    if (Input.GetKey(KeyCode.B))
    {
      SceneManager.LoadScene("Solitude");
    }
    if (Input.GetKey(KeyCode.M))
    {
      SceneManager.LoadScene("Main menu");
    }
    if (Input.GetKey(KeyCode.T))
    {
      SceneManager.LoadScene("TestingScene");
    }

    if (player == null)
    {
      player = GameObject.FindGameObjectWithTag("Player");
      scrollController = player.GetComponent<ScrollController>();
      elixirController = player.GetComponent<ElixirController>();
    }
    if (weaponController == null)
    {
      weaponController = GameObject.FindGameObjectWithTag("WeaponController").GetComponent<WeaponScript>();
    }
  }

  public void SwapWeapon(WeaponTemplate newWeapon)
  {
    currentWeapon = newWeapon;
    weaponController.Swap(newWeapon);
  }

  public void SwapScroll(ScrollTemplate newScroll)
  {
    currentScroll = newScroll;
    scrollController.Swap(newScroll);
  }

  public void SwapElixir(ElixirTemplate newElixir)
  {
    currentElixir = newElixir;
    elixirController.Swap(newElixir);
  }
}
