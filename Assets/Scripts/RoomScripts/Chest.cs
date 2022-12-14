using UnityEngine;

public class Chest : MonoBehaviour
{
  public GameObject[] lootPool;
  private GameObject player;
  private Vector3 playerPosition;
  private Animator animator;
  private float distanceToPlayer;
  private bool inactive = false;
  public AudioSource audioSource;

  void Start()
  {
    player = GameObject.FindGameObjectWithTag("Player");
    animator = gameObject.GetComponent<Animator>();
  }

  void Update()
  {
    playerPosition = player.transform.position;
    distanceToPlayer = Vector3.Distance(transform.position, playerPosition);

    if (distanceToPlayer < 1.5f && Input.GetKeyUp(KeyCode.F) && !inactive)
    {
      animator.SetBool("isOpen", true);
    }
  }

  public void SpawnLoot()
  {
    animator.SetBool("isOpen", false);
    GameObject item = lootPool[Random.Range(0, lootPool.Length)];
    if (item.name == "Points")
    {
      audioSource.Play();
    }
    Instantiate(item, transform.position, Quaternion.Euler(item.transform.eulerAngles));
    inactive = true;
  }
}
