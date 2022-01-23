using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;


public class CardManager : MonoBehaviour
{
    private bool firstImageSelected = false;
    private string card1;

    [SerializeField] private Image[] sprite1;
    [SerializeField] private Image[] sprite2;

    [SerializeField] private GameManager gameManager;
    [SerializeField] private ClassManager classManager;

    
    public void OnClickCard(PairData pairData)
    {
        if (classManager.selectClass == true)
        {
            if (firstImageSelected == false /*&& pairData.Group == 1*/)
            {
                Debug.Log(pairData.PairName);
                Debug.Log(pairData.Group);
                Debug.Log(pairData.Sprite);
                card1 = pairData.PairName;
                firstImageSelected = true;
                sprite1[pairData.IndexPair].sprite = pairData.Sprite;
            }

            else if (firstImageSelected == true /*&& pairData.Group == 2*/)
            {
                Debug.Log(pairData.PairName);
                Debug.Log(pairData.Group);
                Debug.Log(pairData.Sprite);
                sprite2[pairData.IndexPair].sprite = pairData.Sprite;

                if (pairData.PairName == card1)
                {
                    Debug.Log("correct");

                    gameManager.OnCorrectClick?.Invoke();

                    
                    Color tmp2 = sprite1[pairData.IndexPair].GetComponent<Image>().color;
                    tmp2.a = 0.3f;
                    sprite1[pairData.IndexPair].GetComponent<Image>().color = tmp2;
                    Color tmp3 = sprite2[pairData.IndexPair].GetComponent<Image>().color;
                    tmp3.a = 0.3f;
                    sprite2[pairData.IndexPair].GetComponent<Image>().color = tmp3;

                }

                else
                {

                    gameManager.OnWrongClick?.Invoke();
                    
                    Debug.Log("notCorrect");
               
                }
                firstImageSelected = false;
                classManager.selectClass = false;
            }
        }
        else
        {
            return;
        }

    }
    


















    //[SerializeField] private Text text;
    //[SerializeField] private Text scoreText;

    //[SerializeField] private bool firstImageSelected;

    //[SerializeField] private string card1;
    //[SerializeField] private ClassManager classManager;

    //public void UpdateDisplayUI(PairData pairData)
    //{
    //   if (classManager.SelectClass == true)
    //    {
    //        if (firstImageSelected == false && pairData.Group == 1)
    //        {
    //            Debug.Log(pairData.PairName);
    //            Debug.Log(pairData.Group);
    //            card1 = pairData.PairName;
    //            firstImageSelected = true;
    //        }

    //        if (firstImageSelected == true && pairData.Group == 2)
    //        {
    //            Debug.Log(pairData.PairName);
    //            Debug.Log(pairData.Group);

    //            if (pairData.PairName == card1)
    //            {
    //                Debug.Log("correct");
    //                text.text = "correct";
    //                StartCoroutine(InitializeText());
    //                AddScore();
    //            }

    //            else
    //            {
    //                Debug.Log("notCorrect");
    //                text.text = "notCorrect";
    //                StartCoroutine(InitializeText());
    //            }
    //            firstImageSelected = false;
    //            classManager.SelectClass = false;
    //        }
    //    }
    //    else
    //    {
    //        return;
    //    }




    //}  

    //public void AddScore()
    //{
    //    classManager.scoreofClass++;
    //    scoreText.text = classManager.scoreofClass.ToString();
    //    Debug.Log(classManager.nameofClass + "Your score is " + classManager.scoreofClass);

    //}




    //private IEnumerator InitializeText()
    //{
    //    yield return new WaitForSeconds(2f);
    //    Debug.Log("התכ רחב");
    //    text.text = "התכ רחב";
    //}
}
