using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float movespeed = 3f;
    private Rigidbody2D rb;
    private bool isMovingRight = true;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Boundary"))
        {
            isMovingRight = !isMovingRight;

        }


    }



    // Update is called once per frame
    void Update()
    {
        if (isMovingRight)
            rb.velocity = new Vector2(movespeed, rb.velocity.y);

        else
            rb.velocity = new Vector2(-movespeed, rb.velocity.y);


    }
}
