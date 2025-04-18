using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using TMPro;
public class HomeworkManager : MonoBehaviour
{
    public static HomeworkManager instance;
    public int totalHomework = 3;
    private int collected = 0;
    public GameObject Door; // ��Ż�� ó���� ��Ȱ��ȭ
    public TextMeshProUGUI homeworkText;
    void Awake()
    {
        instance = this;
        Door.SetActive(false); // ������ �� ���ܳ���
        UpdateHomeworkUI();
    }


    public void CollectHomework()
    {
        collected++;


        UpdateHomeworkUI();


        if (collected >= totalHomework)
        {
            Door.SetActive(true);
        }

    }
    void UpdateHomeworkUI()
    {
        homeworkText.text = "������: " + collected + " / " + totalHomework;
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