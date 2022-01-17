using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class CardManager : MonoBehaviour
{
    [SerializeField] private Text text;
    [SerializeField] private Group group;


    private string card1;
    public void UpdateDisplayUI(PairData pairData)
    {
        Debug.Log(pairData.PairName);
        
        if (group == Group.Group1)
        {

        }

        if (card1 == null)
        {
            card1 = pairData.PairName;
        }

        else
        {
            if (pairData.PairName == card1)
            {
                Debug.Log("correct");
                text.text = "correct";
            }
            else
            {
                Debug.Log("notCorrect");
                text.text = "notCorrect";
            }

            card1 = null;
        }

    }
}
