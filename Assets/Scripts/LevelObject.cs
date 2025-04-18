using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class LevelObject : MonoBehaviour
{
    public string Next;

    public void MoveToNextLevel()
    {
        SceneManager.LoadScene(Next);
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
