using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
  [Header("General")]
  public static GameController instance;
  public GameObject player;
  public PlayerController playerController;
  public SaveManager saveManager;

  [Header("Weapon")]
  public WeaponTemplate currentWeapon;
  private WeaponScript weaponController;

  [Header("Scroll")]
  public ScrollTemplate currentScroll;
  private ScrollController scrollController;

  [Header("Elixir")]
  public ElixirTemplate currentElixir;
  private ElixirController elixirController;

  [Header("Trophy")]
  public TrophyTemplate currentTrophy;
  public TrophyTemplate carriedTrophy;
  public TrophyTemplate defaultTrophy;

  [Header("Points")]
  public int points;
  public float bonusPointsModificator = 1f;
  public float maxBonusModificator = 3f;

  [Header("Statistics")]
  public float baseMaxHp = 10f;
  public float baseMs = 7f;
  public float baseMaxEnergy = 10f;
  public float playerMaxHealth = 10f;
  public float itemMaxHealthBonus = 0f;
  public float playerMaxEnergy = 10f;
  public float playerMoveSpeed = 7f;

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
    playerController = player.GetComponent<PlayerController>();
    scrollController = player.GetComponent<ScrollController>();
    elixirController = player.GetComponent<ElixirController>();
    weaponController = GameObject.FindGameObjectWithTag("WeaponController").GetComponent<WeaponScript>();

    currentElixir = saveManager.currentElixir;
    currentScroll = saveManager.currentScroll;
    currentWeapon = saveManager.currentWeapon;
    currentTrophy = saveManager.currentTrophy;
    carriedTrophy = saveManager.carriedTrophy;

    points = saveManager.points;
    bonusPointsModificator = saveManager.bonusPointsModificator;
    playerMaxHealth = saveManager.playerMaxHealth;
    itemMaxHealthBonus = saveManager.itemMaxHealthBonus;
    playerMaxEnergy = saveManager.playerMaxEnergy;
    playerMoveSpeed = saveManager.playerMoveSpeed;
  }

  void Update()
  {
    // if (Input.GetKey(KeyCode.B) && Application.isEditor)
    if (Input.GetKey(KeyCode.B))
    {
      SceneManager.LoadScene("Solitude");
    }
    // if (Input.GetKey(KeyCode.M) && Application.isEditor)
    if (Input.GetKey(KeyCode.M))
    {
      SaveGame();
      SceneManager.LoadScene("Main menu");
    }
    // if (Input.GetKey(KeyCode.T) && Application.isEditor)
    if (Input.GetKey(KeyCode.T))
    {
      SceneManager.LoadScene("TestingScene");
    }

    if (player == null && SceneManager.GetActiveScene().name != "Main menu" && SceneManager.GetActiveScene().name != "DeathScreen" && SceneManager.GetActiveScene().name != "SettingsScreen")
    {
      player = GameObject.FindGameObjectWithTag("Player");
      scrollController = player.GetComponent<ScrollController>();
      elixirController = player.GetComponent<ElixirController>();
      playerController = player.GetComponent<PlayerController>();
    }
    if (weaponController == null && SceneManager.GetActiveScene().name != "Main menu")
    {
      weaponController = GameObject.FindGameObjectWithTag("WeaponController").GetComponent<WeaponScript>();
    }
  }

  public void SwapWeapon(WeaponTemplate newWeapon)
  {
    HUDScript hud = GameObject.FindGameObjectWithTag("HUD").GetComponent<HUDScript>();
    hud.UpdateWeaponSprite(newWeapon.sprite);
    hud.UpdateWeaponInfo(newWeapon.name, newWeapon.description);
    currentWeapon = newWeapon;
    weaponController.Swap(newWeapon);
    saveManager.currentWeapon = newWeapon;
  }

  public void SwapScroll(ScrollTemplate newScroll)
  {
    HUDScript hud = GameObject.FindGameObjectWithTag("HUD").GetComponent<HUDScript>();
    hud.UpdateScrollSprite(newScroll.sprite);
    hud.UpdateScrollInfo(newScroll.name, newScroll.description);
    currentScroll = newScroll;
    scrollController.Swap(newScroll);
    saveManager.currentScroll = newScroll;
  }

  public void SwapElixir(ElixirTemplate newElixir)
  {
    HUDScript hud = GameObject.FindGameObjectWithTag("HUD").GetComponent<HUDScript>();
    hud.UpdateElixirSprite(newElixir.sprite);
    hud.UpdateElixirCharges(newElixir.charges);
    hud.UpdateElixirInfo(newElixir.name, newElixir.description);
    currentElixir = newElixir;
    elixirController.Swap(newElixir);
    saveManager.currentElixir = newElixir;
  }

  public void PickUpTrophy(TrophyTemplate newTrophy)
  {
    carriedTrophy = newTrophy;
    playerController.CarriedTrophy = newTrophy;
    playerController.CarriedTrophySprite.GetComponent<SpriteRenderer>().sprite = newTrophy.TrophySprite;
  }

  public void EquipNewTrophy(TrophyTemplate newTrophy)
  {
    PickUpTrophy(defaultTrophy);
    currentTrophy = newTrophy;
    playerController.EquipNewTrophy(newTrophy);
    GameObject.FindGameObjectWithTag("HUD").GetComponent<HUDScript>().UpdateTrophyInfo(newTrophy.TrophySprite, newTrophy.name, newTrophy.TrophyDescription);
  }

  public void SellTrophy()
  {
    carriedTrophy = null;
  }

  public void PlayerDied()
  {
    points -= (int)(Mathf.Round(points) * 0.4f);
    bonusPointsModificator = 1f;
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
    points += Mathf.FloorToInt(pointsToAdd * bonusPointsModificator);
    GameObject.FindGameObjectWithTag("HUD").GetComponent<HUDScript>().UpdatePoints(points, bonusPointsModificator);
  }

  public void RemovePoints(int pointsToRemove)
  {
    points -= pointsToRemove;
    GameObject.FindGameObjectWithTag("HUD").GetComponent<HUDScript>().UpdatePoints(points, bonusPointsModificator);
  }

  public void Sell(int pointsToAdd)
  {
    points += pointsToAdd;
    GameObject.FindGameObjectWithTag("HUD").GetComponent<HUDScript>().UpdatePoints(points, bonusPointsModificator);
  }

  private void OnApplicationQuit()
  {
    SaveGame();
  }

  public void SaveGame()
  {
    saveManager.currentElixir = currentElixir;
    saveManager.currentScroll = currentScroll;
    saveManager.currentTrophy = currentTrophy;
    saveManager.carriedTrophy = carriedTrophy;
    saveManager.points = points;
    saveManager.bonusPointsModificator = bonusPointsModificator;
    saveManager.playerMaxHealth = playerMaxHealth;
    saveManager.itemMaxHealthBonus = itemMaxHealthBonus;
    saveManager.playerMaxEnergy = playerMaxEnergy;
    saveManager.playerMoveSpeed = playerMoveSpeed;

    saveManager.Save();
  }
}
