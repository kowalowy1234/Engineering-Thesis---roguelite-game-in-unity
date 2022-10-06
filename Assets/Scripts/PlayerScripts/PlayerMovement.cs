using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
  [SerializeField]
  LayerMask blinkLayerMask;

  private Vector3 moveDirection;
  public float moveSpeed = 10f;
  public int energy = 10;
  public float blinkRange = 3f;
  float horizontalMovement;
  float verticalMovement;
  bool isBlinking = false;

  public Animator animator;
  private SpriteRenderer playerSprite;
  private Rigidbody2D rigidBody2D;

  private void Awake()
  {
    rigidBody2D = GetComponent<Rigidbody2D>();
    playerSprite = gameObject.GetComponent<SpriteRenderer>();
  }

  private void Update()
  {

    // Debug.DrawRay(transform.position, moveDirection * blinkRange, Color.green);

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
      gameObject.layer = LayerMask.NameToLayer("PlayerDodge");
      rigidBody2D.MovePosition(blinkTarget);
      isBlinking = false;
      gameObject.layer = LayerMask.NameToLayer("Player");
    }
  }

  private void GetMoveDir()
  {

    horizontalMovement = Input.GetAxisRaw("Horizontal");
    verticalMovement = Input.GetAxisRaw("Vertical");


    int moveX = 0;
    int moveY = 0;

    if (horizontalMovement > 0)
    {
      moveX += 1;
    }
    else if (horizontalMovement < 0)
    {
      moveX -= 1;
    }

    if (verticalMovement > 0)
    {
      moveY += 1;
    }
    else if (verticalMovement < 0)
    {
      moveY -= 1;
    }

    // vector needs to be normalized so the player's movement speed is always the same on main axis and diagonally (length of vector is always 1)
    moveDirection = new Vector3(moveX, moveY).normalized;
  }
}
