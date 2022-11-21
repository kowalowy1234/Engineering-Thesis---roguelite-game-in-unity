using UnityEngine;

[CreateAssetMenu(menuName = "Scrolls/ShieldScroll")]
public class ShieldScrollScript : ScrollTemplate
{
  public GameObject shieldObject;
  private Transform playerPosition;
  private PlayerController playerController;
  private GameObject player;

  public override bool Activate()
  {
    player = GameObject.FindGameObjectWithTag("Player");
    playerPosition = player.transform;
    playerController = player.GetComponent<PlayerController>();
    playerController.invoulnerable = true;

    GameObject shieldInstance = Instantiate(shieldObject, playerPosition.position, Quaternion.identity);
    shieldInstance.transform.parent = playerPosition;
    
    return true;
  }

  public override void Deactivate()
  {
    GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>().invoulnerable = false;
    GameObject shield = GameObject.FindGameObjectWithTag("Shield");
    Destroy(shield);
  }
}
