using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;


public class ClassManager : MonoBehaviour
{
    public string nameofClass;
    public int scoreofClass;
    public int[] scoreClass;
    //public bool ScoreChanged;
    [SerializeField] private CardManager cardManager;
    public int index;
    private bool selectClass = false;
    List<int> num = new List<int>() { 1, 30, 5, 6 };

    private void Start()
    {
        int max = num[0];
        for (int i = 0; i < num.Count; i++)
        {
            if (num[i] >= max)
            {
                max = num[i];
                
            }

        }
        Debug.Log(max);
    }

    public bool SelectClass
    {
        get { return selectClass; }
        set
        {
            selectClass = value;
        }
    }




    public void UpdateDisplayUI(ClassData classData)
    {
        SelectClass = true;
        nameofClass = classData.ClassName;
        Debug.Log(nameofClass);
        Debug.Log(scoreofClass);
        scoreClass[classData.index]+= scoreofClass;
        scoreofClass = 0;

    }

    public void WinClass(ClassData classData)
    {
        int max = scoreClass[0];
        for(int i = 0; i < scoreClass.Length; i++)
        {
            if (scoreClass[i] >= max)
            {
                max = scoreClass[classData.index];
              
            }
               
        }
        Debug.Log(max);
    }

   


}
