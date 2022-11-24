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
    points = saveManager.points;
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

    if (player == null && SceneManager.GetActiveScene().name != "Main menu" && SceneManager.GetActiveScene().name != "DeathScreen")
    {
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
    GameObject.FindGameObjectWithTag("HUD").GetComponent<HUDScript>().UpdateWeaponSprite(newWeapon.sprite);
    currentWeapon = newWeapon;
    weaponController.Swap(newWeapon);
    saveManager.currentWeapon = newWeapon;
  }

  public void SwapScroll(ScrollTemplate newScroll)
  {
    GameObject.FindGameObjectWithTag("HUD").GetComponent<HUDScript>().UpdateScrollSprite(newScroll.sprite);
    currentScroll = newScroll;
    scrollController.Swap(newScroll);
    saveManager.currentScroll = newScroll;
  }

  public void SwapElixir(ElixirTemplate newElixir)
  {
    GameObject.FindGameObjectWithTag("HUD").GetComponent<HUDScript>().UpdateElixirSprite(newElixir.sprite);
    GameObject.FindGameObjectWithTag("HUD").GetComponent<HUDScript>().UpdateElixirCharges(newElixir.charges);
    currentElixir = newElixir;
    elixirController.Swap(newElixir);
    saveManager.currentElixir = newElixir;
  }

  public void PlayerDied()
  {
    points -= (int)(Mathf.Round(points) * 0.4f);
    bonusPointsModificator = 1f;
    Debug.Log(points);
    SceneManager.LoadScene("DeathScreen");
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
    GameObject.FindGameObjectWithTag("HUD").GetComponent<HUDScript>().UpdatePoints(points, bonusPointsModificator);
  }

  public void ResetBonusPoints()
  {
    bonusPointsModificator = 1f;
    saveManager.bonusPointsModificator = bonusPointsModificator;
    GameObject.FindGameObjectWithTag("HUD").GetComponent<HUDScript>().UpdatePoints(points, bonusPointsModificator);
  }

  public void AddPoints(int pointsToAdd)
  {
    points += pointsToAdd;
    GameObject.FindGameObjectWithTag("HUD").GetComponent<HUDScript>().UpdatePoints(points, bonusPointsModificator);
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
