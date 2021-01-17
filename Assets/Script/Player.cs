using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    private Rigidbody2D _rigidB;


    // Start is called before the first frame update
    void Start()
    {
        _rigidB = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        float horizontalInput = Input.GetAxisRaw("Horizontal");

        _rigidB.velocity = new Vector2(horizontalInput, _rigidB.velocity.y);
    }
}
