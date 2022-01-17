using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.Events;


public class CardManager : MonoBehaviour
{

    public UnityAction<int/*, ClassData*/> OnScoreChanged;

    [SerializeField] private Text text;
    [SerializeField] private Text scoreText;
    //[SerializeField] private Group group;
    [SerializeField] private bool firstImageSelected;
    //[SerializeField] private int classInt;

    [SerializeField] private string card1;
    [SerializeField] private ClassManager classManager;
    //[SerializeField] private ClassData classData2;

    private void Start()
    {
       
    }
    public void UpdateDisplayUI(PairData pairData/*, ClassData classData*/)
    {
       

        //Debug.Log(classManager.NameofClass);
        //Debug.Log(classManager.ScoreofClass);

        if (firstImageSelected == false && pairData.Group == 1)
        {
            Debug.Log(pairData.PairName);
            Debug.Log(pairData.Group);
            card1 = pairData.PairName;
            firstImageSelected = true;
        }

        if (firstImageSelected == true && pairData.Group == 2)
        {
            Debug.Log(pairData.PairName);
            Debug.Log(pairData.Group);

            if (pairData.PairName == card1)
            {
                Debug.Log("correct");
                text.text = "correct";
                StartCoroutine(InitializeText());
                AddScore(/*classData*/);
            }

            else
            {
                Debug.Log("notCorrect");
                text.text = "notCorrect";
                StartCoroutine(InitializeText());
            }
            firstImageSelected = false;
        }


    }  

    public void AddScore(/*ClassData classData*/)
    {
        classManager.scoreofClass++;
        scoreText.text = classManager.scoreofClass.ToString();
        Debug.Log(classManager.nameofClass + "Your score is " + classManager.scoreofClass);
        OnScoreChanged?.Invoke(classManager.scoreofClass/*, classData*/);
        //classManager.ScoreChanged = true;
    }

    //    if (card1 == null)
    //    {
    //        card1 = pairData.PairName;

    //    }

    //    else
    //    {
    //        if (pairData.PairName == card1)
    //        {
    //            Debug.Log("correct");
    //            text.text = "correct";
    //        }
    //        else
    //        {
    //            Debug.Log("notCorrect");
    //            text.text = "notCorrect";
    //        }

    //        card1 = null;
    //    }

    //}


    private IEnumerator InitializeText()
    {
        yield return new WaitForSeconds(2f);
        Debug.Log("your turn");
        text.text = "your turn";
    }
}
