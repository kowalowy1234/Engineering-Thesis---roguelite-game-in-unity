using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
  [SerializeField]
  LayerMask blinkLayerMask;

  public float moveSpeed;
  public float maxEnergy;
  public float currentEnergy = 10f;
  public float blinkRange = 3f;
  public float energyRechargeRate = 0f;

  float horizontalMovement;
  float verticalMovement;
  bool isBlinking = false;

  public Animator animator;
  private GameController gameController;
  private Vector3 moveDirection;
  private SpriteRenderer playerSprite;
  private Rigidbody2D rigidBody2D;
  public EnergyBar energyBar;

  private void Start()
  {
    gameController = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();
    moveSpeed = gameController.playerMoveSpeed;
    energyBar = GameObject.FindGameObjectWithTag("HUDEnergybar").GetComponent<EnergyBar>();
    maxEnergy = gameController.playerMaxEnergy;
    currentEnergy = maxEnergy;
    rigidBody2D = GetComponent<Rigidbody2D>();
    playerSprite = gameObject.GetComponent<SpriteRenderer>();
    energyBar.SetMaxEnergy(maxEnergy);
    energyBar.SetEnergy(maxEnergy);

    InvokeRepeating("RechargeEnergy", 1f, 1f);
  }

  private void Update()
  {
    animator.SetFloat("movementSpeed", Mathf.Abs(horizontalMovement));
    GetMoveDir();

    if (Input.GetButtonDown("Jump") && currentEnergy >= 10)
    {
      if (moveDirection != Vector3.zero)
      {
        currentEnergy -= 10f;
        energyBar.SetEnergy(currentEnergy);
        isBlinking = true;
      }
    }
  }

  private void FixedUpdate()
  {
    rigidBody2D.velocity = moveDirection * moveSpeed;

    Vector3 blinkTarget = transform.position + moveDirection * blinkRange;

    RaycastHit2D blinkHitWall = Physics2D.Raycast(transform.position, moveDirection, blinkRange, blinkLayerMask);

    if (blinkHitWall.collider)
    {
      blinkTarget = blinkHitWall.point;
    }

    if (isBlinking)
    {
      rigidBody2D.MovePosition(blinkTarget);
      isBlinking = false;
    }
  }

  private void OnTriggerEnter2D(Collider2D other)
  {
    string tag = other.gameObject.tag;

    switch (tag)
    {
      default:
        break;
    }
  }

  private void OnTriggerExit2D(Collider2D other)
  {
    string tag = other.gameObject.tag;

    switch (tag)
    {
      default:
        break;
    }
  }

  private void GetMoveDir()
  {

    horizontalMovement = Input.GetAxisRaw("Horizontal");
    verticalMovement = Input.GetAxisRaw("Vertical");

    // vector needs to be normalized so the player's movement speed is always the same on main axis and diagonally (length of vector is always 1)
    moveDirection = new Vector3(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")).normalized;
  }

  private void RechargeEnergy()
  {
    if (currentEnergy < maxEnergy)
    {
      currentEnergy += 5f + (5f * energyRechargeRate);
      energyBar.SetEnergy(currentEnergy);
    }
  }
}
