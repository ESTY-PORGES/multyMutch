using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class CardManager : MonoBehaviour
{
    [SerializeField] private Text text;
    //[SerializeField] private Group group;
    [SerializeField] private bool firstImageSelected;
    //[SerializeField] private int groupInt;

   [SerializeField] private string card1;
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
        yield return new WaitForSeconds(0.5f);
        Debug.Log("your turn");
        text.text = "your turn";
    }
}
