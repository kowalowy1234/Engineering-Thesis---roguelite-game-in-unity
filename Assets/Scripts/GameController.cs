using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
  public static GameController instance;
  public SaveManager saveManager;
  public WeaponTemplate currentWeapon;
  private WeaponScript weaponController;
  public ScrollTemplate currentScroll;
  private ScrollController scrollController;
  public ElixirTemplate currentElixir;
  private ElixirController elixirController;
  public GameObject player;
  // Passive boss trophy goes here (not yet implemented)
  public int currentTrophy;
  public int points;
  public float bonusPointsModificator = 1f;
  public float maxBonusModificator = 3f;
  public float playerMaxHealth = 10f;
  public float playerMaxEnergy = 10f;

  void Awake()
  {
    if (instance == null)
    {
      instance = this;
      DontDestroyOnLoad(gameObject);
    }
    else if (instance != null)
    {
      Destroy(gameObject);
    }

    saveManager = GameObject.FindGameObjectWithTag("SaveManager").GetComponent<SaveManager>();
    player = GameObject.FindGameObjectWithTag("Player");
    scrollController = player.GetComponent<ScrollController>();
    elixirController = player.GetComponent<ElixirController>();
    weaponController = GameObject.FindGameObjectWithTag("WeaponController").GetComponent<WeaponScript>();


    currentElixir = saveManager.currentElixir;
    currentScroll = saveManager.currentScroll;
    currentWeapon = saveManager.currentWeapon;
    bonusPointsModificator = saveManager.bonusPointsModificator;
    playerMaxHealth = saveManager.playerMaxHealth;
    playerMaxEnergy = saveManager.playerMaxEnergy;
  }

  void Update()
  {
    if (Input.GetKey(KeyCode.B))
    {
      SceneManager.LoadScene("Solitude");
    }
    if (Input.GetKey(KeyCode.M))
    {
      SaveGame();
      SceneManager.LoadScene("Main menu");
    }
    if (Input.GetKey(KeyCode.T))
    {
      SceneManager.LoadScene("TestingScene");
    }

    if (player == null && SceneManager.GetActiveScene().name != "Main menu")
    {
      Debug.Log("hello");
      player = GameObject.FindGameObjectWithTag("Player");
      scrollController = player.GetComponent<ScrollController>();
      elixirController = player.GetComponent<ElixirController>();
    }
    if (weaponController == null && SceneManager.GetActiveScene().name != "Main menu")
    {
      weaponController = GameObject.FindGameObjectWithTag("WeaponController").GetComponent<WeaponScript>();
    }
  }

  public void SwapWeapon(WeaponTemplate newWeapon)
  {
    currentWeapon = newWeapon;
    weaponController.Swap(newWeapon);
    saveManager.currentWeapon = newWeapon;
  }

  public void SwapScroll(ScrollTemplate newScroll)
  {
    currentScroll = newScroll;
    scrollController.Swap(newScroll);
    saveManager.currentScroll = newScroll;
  }

  public void SwapElixir(ElixirTemplate newElixir)
  {
    currentElixir = newElixir;
    elixirController.Swap(newElixir);
    saveManager.currentElixir = newElixir;
  }

  public void ModifyBonusPoints(float value)
  {
    if (bonusPointsModificator + value > maxBonusModificator)
    {
      bonusPointsModificator = maxBonusModificator;
    }
    else
    {
      bonusPointsModificator += value;
    }

    saveManager.bonusPointsModificator = bonusPointsModificator;
  }

  public void ResetBonusPoints()
  {
    bonusPointsModificator = 0f;
    saveManager.bonusPointsModificator = bonusPointsModificator;
  }

  private void OnApplicationQuit()
  {
    SaveGame();
  }

  private void SaveGame()
  {
    saveManager.currentElixir = currentElixir;
    saveManager.currentScroll = currentScroll;
    saveManager.currentTrophy = currentTrophy;
    saveManager.points = points;
    saveManager.bonusPointsModificator = bonusPointsModificator;
    saveManager.playerMaxHealth = playerMaxHealth;
    saveManager.playerMaxEnergy = playerMaxEnergy;

    saveManager.Save();
  }
}
