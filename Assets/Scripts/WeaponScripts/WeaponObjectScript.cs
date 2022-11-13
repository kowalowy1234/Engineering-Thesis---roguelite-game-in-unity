using UnityEngine;

public class WeaponObjectScript : MonoBehaviour
{
  private GameObject player;
  private Vector3 playerPosition;
  private GameController gameController;
  [SerializeField]
  private WeaponTemplate weaponData;

  private void Awake()
  {
    gameObject.GetComponent<SpriteRenderer>().sprite = weaponData.sprite;
    gameController = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();
    player = GameObject.FindGameObjectWithTag("Player");
  }

  void Update()
  {
    playerPosition = player.transform.position;
    float distanceToPlayer = Vector3.Distance(transform.position, playerPosition);
    if (distanceToPlayer < 1 && Input.GetKey(KeyCode.F))
    {
      if (gameController.currentWeapon.name != weaponData.name)
      {
        gameController.SwapWeapon(weaponData);
        Destroy(gameObject);
      }
    }
  }
}
