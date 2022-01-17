using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.Events;


public class CardManager : MonoBehaviour
{


    [SerializeField] private Text text;
    [SerializeField] private Text scoreText;
  
    [SerializeField] private bool firstImageSelected;
  
    [SerializeField] private string card1;
    [SerializeField] private ClassManager classManager;
 

    private void Start()
    {
       
    }
    public void UpdateDisplayUI(PairData pairData)
    {
       

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
                AddScore();
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

    public void AddScore()
    {
        classManager.scoreofClass++;
        scoreText.text = classManager.scoreofClass.ToString();
        Debug.Log(classManager.nameofClass + "Your score is " + classManager.scoreofClass);
       
       
    }

    


    private IEnumerator InitializeText()
    {
        yield return new WaitForSeconds(2f);
        Debug.Log("your turn");
        text.text = "your turn";
    }
}
