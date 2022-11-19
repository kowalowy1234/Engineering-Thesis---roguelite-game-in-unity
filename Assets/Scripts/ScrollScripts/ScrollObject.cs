using UnityEngine;

public class ScrollObject : MonoBehaviour
{

  private GameObject player;
  private Vector3 playerPosition;
  private GameController gameController;
  [SerializeField]
  private ScrollTemplate scrollData;

  private void Awake()
  {
    gameObject.GetComponent<SpriteRenderer>().sprite = scrollData.sprite;
    gameController = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();
    player = GameObject.FindGameObjectWithTag("Player");
  }

  void Update()
  {
    playerPosition = player.transform.position;
    float distanceToPlayer = Vector3.Distance(transform.position, playerPosition);
    if (distanceToPlayer < 1 && Input.GetKey(KeyCode.F))
    {
      if (gameController.currentScroll.name != scrollData.name)
      {
        gameController.SwapScroll(scrollData);
        Destroy(gameObject);
      }
    }
  }
}
