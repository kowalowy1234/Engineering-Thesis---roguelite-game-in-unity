using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
  public static GameController instance;
  public WeaponTemplate currentWeapon;
  public WeaponScript weaponController;

  void Start()
  {

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

  public void SwapScroll()
  {

  }

  public void SwapElixir()
  {

  }
}
