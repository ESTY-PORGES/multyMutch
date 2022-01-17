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
    

    private void Start()
    {
       
       
    }
    public void UpdateDisplayUI(ClassData classData)
    {
        nameofClass = classData.ClassName;
        Debug.Log(nameofClass);
        Debug.Log(scoreofClass);
        scoreClass[classData.index]+= scoreofClass;
        scoreofClass = 0;

    }

   


}
