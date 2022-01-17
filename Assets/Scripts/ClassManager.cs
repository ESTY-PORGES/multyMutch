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
    //private ClassData classData1;
    //public string NameofClass => nameofClass;

    //public int ScoreofClass => scoreofClass;

    private void Start()
    {
        cardManager.OnScoreChanged += AddScoreToData;
       
    }
    public void UpdateDisplayUI(ClassData classData)
    {
        nameofClass = classData.ClassName;
        scoreofClass = classData.score;
       
        Debug.Log(nameofClass);
        Debug.Log(scoreofClass);
        scoreClass[classData.index] = scoreofClass;



    }

    private void AddScoreToData(int score/*, ClassData classData*/)
    {
       
        //classData.score = scoreofClass;

    }


}
