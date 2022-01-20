using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ClassManager : MonoBehaviour
{
    [SerializeField] private Text classText;
    //[SerializeField] private Text scoreText;
    public bool selectClass = false;
    private ClassData classDataSelected;
    private bool scoreUp = false;

    private List<ClassData> classDataList = new List<ClassData>();

    private void Start()
    {

    }

    public void OnClickClass(ClassData classData)
    {
        classDataSelected = classData;
        selectClass = true;
        classText.text = classData.ClassName.ToString();
        Debug.Log(classData.ClassName);
    }

    public void AddScore()
    {

         for (int i = 0; i < classDataList.Count; i++)
         {
              if (classDataList[i].ClassName == classDataSelected.ClassName) 
              {
                    scoreUp = true;
                    Debug.Log("+++++++++");

              }
         }

         if (scoreUp == false)
         {
                Debug.Log("Reset");
                classDataSelected.Score = 0;
         }

         classDataSelected.Score= classDataSelected.Score + 10;
         classText.text = classDataSelected.Score.ToString();
         Debug.Log("score" + classDataSelected.Score);
         Debug.Log(classDataSelected.ClassName );

         classDataList.Add(classDataSelected);
         scoreUp = false;
    }

    public void LeadingClass()
    {
        int max = classDataList[0].Score;
        string maxName = classDataList[0].ClassName;

        for (int i = 0; i < classDataList.Count; i++)
        {
            if (classDataList[i].Score >= max)
            {
                max = classDataList[i].Score;
                maxName = classDataList[i].ClassName;
            }

        }

        //Debug.Log(maxName + max);
        Debug.Log(maxName + " score"  + max);
    }

}
