using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    private Rigidbody2D _rigidB;
    [SerializeField]
    private float _jumpForce = 15.0f;
    private BoxCollider2D _boxCollider2D;
    [SerializeField]
    private float _speed = 4.0f;
    [SerializeField]
    private LayerMask _platformLayerMask; //gestione del Layer "ground/platform"
    private PlayerAnimation _anim; //PlayerAnimation.cs
    private SpriteRenderer _spriteRenderer;

    // Start is called before the first frame update
    void Start()
    {
        _rigidB = GetComponent<Rigidbody2D>();
        _boxCollider2D = GetComponent<BoxCollider2D>();
        _anim = GetComponent<PlayerAnimation>(); // rceuper l'oggetto PlayerAnimation.cs
        _spriteRenderer = GetComponentInChildren<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        Movments();
        Attack();
    }


    private void Movments()
    {
        float horizontalInput = Input.GetAxisRaw("Horizontal");

        _rigidB.velocity = new Vector2(horizontalInput * _speed, _rigidB.velocity.y);

        //jump
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded())
        {
            _rigidB.velocity = Vector2.up * _jumpForce;
        }
        _anim.jumpAnimation(isGrounded());

        _anim.moveAnimation(horizontalInput); //metodo di PlayerAnimation.cs per gestire l'animazione corsa/idle

        flipSprite(horizontalInput, _spriteRenderer); //gira lo spite a seconda della direzione in cui mi muovo
    }

    private void Attack()
    {
       if(Input.GetMouseButtonDown(0) && isGrounded())
        {
            _anim.attackAnimation();
        }
    }


    private bool isGrounded()
    {
        //prendo il ray cast del giocatore 
        RaycastHit2D rayCastHit =  Physics2D.BoxCast(_boxCollider2D.bounds.center, 
            _boxCollider2D.bounds.size, 0f, Vector2.down,1f, _platformLayerMask);
        Debug.DrawRay(_boxCollider2D.bounds.center, Vector2.down, Color.green);
        return rayCastHit.collider != null;

    }

    public void flipSprite(float direction, SpriteRenderer spriteRender)
    {
        if (direction < 0) //guardo a sinistra
        {
            spriteRender.flipX = true;

        }
        else if(direction > 0)
        {
            spriteRender.flipX = false;
        
        }
    }

}
