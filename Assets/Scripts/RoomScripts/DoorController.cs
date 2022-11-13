using UnityEngine;

public class DoorController : MonoBehaviour
{

  public LayerMask layerMask;
  [SerializeField]
  private bool blocked = false;
  private bool isOpen = false;

  private void Start() {
    Debug.Log(gameObject.layer);
  }

  private void Update()
  {
    checkIfHitWall();
  }

  public void openDoor()
  {
    if (blocked == false)
    {
      isOpen = true;
      gameObject.GetComponent<SpriteRenderer>().color = Color.green;
    }
  }

  public void closeDoor()
  {
    isOpen = false;
    gameObject.GetComponent<SpriteRenderer>().color = Color.red;
  }

  public void checkIfHitWall()
  {
    RaycastHit2D hitWall = Physics2D.Raycast(transform.position, transform.right * (-3), 0.9f, layerMask);

    if (hitWall.collider)
    {
      closeDoor();
      blocked = true;
    }
    else
    {
      openDoor();
      blocked = false;
    }
  }

  private void OnCollisionEnter2D(Collision2D other)
  {
    if (other.gameObject.tag.Equals("Player") && isOpen == true)
    {
      other.transform.position = other.transform.position + transform.right * (-3);
    }
  }
}
