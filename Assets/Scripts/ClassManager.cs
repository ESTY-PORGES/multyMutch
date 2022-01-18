using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;


public class ClassManager : MonoBehaviour
{
    public string nameofClass;
    public int scoreofClass;
    public int[] scoreClass;
    public bool ScoreChanged;
    [SerializeField] private CardManager cardManager;
    public int index;
    private bool selectClass = false;

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

   


}
