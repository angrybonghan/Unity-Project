using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnamyCon : MonoBehaviour
{
    public float moveSpeed = 0.2f;
    public float raycasDistance = 3f;
    public float traceDistance = 2f;

    private Transform player;


    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {

       

        

        Vector2 direction = player.position - transform.position;

        if (direction.magnitude > raycasDistance)
            return;
        Vector2 directionNomallized = direction.normalized;

        RaycastHit2D[] hits = Physics2D.RaycastAll(transform.position, directionNomallized, raycasDistance);

        Debug.DrawRay(transform.position, directionNomallized * raycasDistance, Color.red);


        foreach (RaycastHit2D rHit in hits)

            if (rHit.collider != null && rHit.collider.CompareTag("Obstacle"))
            {
                Vector3 alternativeDirection = Quaternion.Euler(0f, 0f, -90f) * direction;
                transform.Translate(alternativeDirection * moveSpeed * Time.deltaTime);

            }
            else
            {
                transform.Translate(direction * moveSpeed * Time.deltaTime);






            }

        if (direction.x < 0)
        {
            
            transform.localScale = new Vector3(1f, 1f, 1f);
        }
        else if (direction.x > 0)
        {
           
            transform.localScale = new Vector3(-1f, 1f, 1f);
        }
    }
}
