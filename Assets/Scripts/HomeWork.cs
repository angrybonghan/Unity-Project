using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HomeWork : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            HomeworkManager.instance.CollectHomework();
            Destroy(gameObject);
        }
        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }
    }

}