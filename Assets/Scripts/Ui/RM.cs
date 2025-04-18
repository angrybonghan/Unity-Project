using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class RM : MonoBehaviour
{

    public void Rese(string sceneName)
    {
        SceneManager.LoadScene(sceneName);

        Time.timeScale = 1f;
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
