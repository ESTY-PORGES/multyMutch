using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ClassManager : MonoBehaviour
{
    [SerializeField] private GameManager gameManager;

    [SerializeField] private Text classText;
    //[SerializeField] private Text scoreText;
    public bool selectClass = false;
    private ClassData classDataSelected;
    private bool scoreUp = false;
    [SerializeField] private Animator scoreAnim;

    [SerializeField] private ClassData[] allclassData;

    private List<ClassData> classDataList = new List<ClassData>();

    private void Start()
    {
        gameManager.OnCorrectClick += AddScore;
        
        gameManager.TextsetActive += SetActiveClassText;

        for (int i = 0; i < allclassData.Length; i++)
        {
            allclassData[i].Score = 0;
        }

    }
    

    public void SetActiveClassText()
    {
        StartCoroutine(SetActiveClassText2());
       
    }

    private IEnumerator SetActiveClassText2()
    {
        yield return new WaitForSeconds(3f);
        if (gameManager.SetActiveText == true)
        {
            scoreAnim.SetInteger("onScore", 0);
            classText.gameObject.SetActive(false);
        }
        else
        {
            classText.gameObject.SetActive(true);
        }
    }

    public void OnClickClass(ClassData classData)
    {
        classDataSelected = classData;
        selectClass = true;
        classText.text = classData.ClassName.ToString();
        classText.gameObject.SetActive(false);
        Debug.Log(classData.ClassName);

        gameManager.ClassSelected?.Invoke();

    }



    public void AddScore()
    {

         //for (int i = 0; i < classDataList.Count; i++)
         //{
         //     if (classDataList[i].ClassName == classDataSelected.ClassName) 
         //     {
         //           scoreUp = true;
         //           Debug.Log("+++++++++");

         //     }
         //}

         //if (scoreUp == false)
         //{
         //       Debug.Log("Reset");
         //       classDataSelected.Score = 0;
         //}

         classDataSelected.Score = classDataSelected.Score + 10;
         classText.text = /*classDataSelected.Score.ToString()*/ 10  + " + " + classDataSelected.ClassName ;
         scoreAnim.SetInteger("onScore", 1);
         Debug.Log("score" + classDataSelected.Score);
         Debug.Log(classDataSelected.ClassName );

         classDataList.Add(classDataSelected);
         scoreUp = false;
    }

    public void LeadingClass()
    {
        gameManager.Feedback1.gameObject.SetActive(false);
        gameManager.Feedback2.gameObject.SetActive(false);
        int max = classDataList[0].Score;
        string maxName = classDataList[0].ClassName;

        for (int i = 0; i < classDataList.Count; i++)
        {
            //if (classDataList[i].Score == max)
            //{
            //    max = 100;
            //    maxName = "2 Winners";
            //}

            if (classDataList[i].Score >= max)
            {
                max = classDataList[i].Score;
                maxName = classDataList[i].ClassName;
            }

        }

        //Debug.Log(maxName + max);
        Debug.Log(maxName + " score" + max);

        gameManager.Movil(maxName, max);



    }

}
