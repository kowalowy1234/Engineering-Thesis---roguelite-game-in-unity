using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
  [SerializeField]
  LayerMask blinkLayerMask;

  public float moveSpeed = 10f;
  public int energy = 10;
  public float blinkRange = 3f;
  float horizontalMovement;
  float verticalMovement;
  bool isBlinking = false;

  public Animator animator;
  private SpriteRenderer playerSprite;
  private Rigidbody2D rigidBody2D;
  private Vector3 moveDirection;

  private void Awake()
  {
    rigidBody2D = GetComponent<Rigidbody2D>();
  }

  private void Start()
  {
    playerSprite = gameObject.GetComponent<SpriteRenderer>();
  }


  private void Update()
  {

    Debug.DrawRay(transform.position, moveDirection * blinkRange, Color.green);

    animator.SetFloat("movementSpeed", Mathf.Abs(horizontalMovement));
    GetMoveDir();

    if (Input.GetButtonDown("Jump") && energy >= 10)
    {
      isBlinking = true;
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

  private void GetMoveDir()
  {
    horizontalMovement = Input.GetAxisRaw("Horizontal");
    verticalMovement = Input.GetAxisRaw("Vertical");

    float moveX = 0f;
    float moveY = 0f;

    if (horizontalMovement > 0)
    {
      moveX += 1f;
    }
    else if (horizontalMovement < 0)
    {
      moveX -= 1f;
    }

    if (verticalMovement > 0)
    {
      moveY += 1f;
    }
    else if (verticalMovement < 0)
    {
      moveY -= 1f;
    }

    // vector needs to be normalized so the player's movement speed is alwaus the same (length of vector is always 1)
    moveDirection = new Vector3(moveX, moveY).normalized;
  }
}
