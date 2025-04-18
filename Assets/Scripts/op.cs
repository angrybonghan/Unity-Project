using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class op : MonoBehaviour
{
    public static op Instance;

    public AudioSource bgmSource;
    public AudioSource sfxSource;

    public AudioClip clickSound;
    public AudioClip jumpSound;
    public AudioClip uiOpenClip;
    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // ¾À ³Ñ¾î°¡µµ À¯ÁöµÊ
        }
        else
        {
            Destroy(gameObject);
        }
    }
    public void PlayUIOpen()
    {
        if (uiOpenClip != null && sfxSource != null)
        {
            AudioSource.PlayClipAtPoint(uiOpenClip, Camera.main.transform.position);
        }
    }
    public void PlayClick()
    {
        sfxSource.PlayOneShot(clickSound);
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
