using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class CardManager : MonoBehaviour
{
    [SerializeField] private Text bonusName;

    private string card1;
    public void UpdateDisplayUI(PairData pairData)
    {
        Debug.Log(pairData.PairName);

        if (card1 == null)
        {
            card1 = pairData.PairName;
        }

        else
        {
            if (pairData.PairName == card1)
            {
                Debug.Log("correct");

            }
            else
            {
                Debug.Log("notCorrect");
            }

            card1 = null;
        }

    }
}
