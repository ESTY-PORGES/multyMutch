using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField] private Text classs;
    [SerializeField] private Text scoree;

    [SerializeField] private Text feedback1;
    [SerializeField] private Text feedback2;

    [SerializeField] private GameObject movilllll;

    [SerializeField] private GameManager gameManager;

    private void Correct()
    {
        //littleCircleAnim.SetInteger("onCircle", 1);
        //StartCoroutine(StopAnim());

        //StartCoroutine(Feedback(1));
    }

    private IEnumerator Feedback(int ifCorrect)
    {

        yield return new WaitForSeconds(4f);

        if (ifCorrect == 1)
        {
            feedback1.text = "!יפוי";
            feedback2.text = "!הרושק תא";
        }
        else
        {
            feedback1.text = "...מממ";
            feedback2.text = "?רשקה המ";

        }

        feedback1.gameObject.SetActive(true);
        feedback2.gameObject.SetActive(true);

        yield return new WaitForSeconds(3.6f);

        feedback1.gameObject.SetActive(false);
        feedback2.gameObject.SetActive(false);

    }

    public void Movil(string class1, int score1)
    {
        movilllll.gameObject.SetActive(true);
        scoree.text = score1.ToString();
        classs.text = class1;
    }

    public void LeadingClass()
    {
        feedback1.gameObject.SetActive(false);
        feedback1.gameObject.SetActive(false);
        //int max = classDataList[0].Score;
        //string maxName = classDataList[0].ClassName;

        //for (int i = 0; i < classDataList.Count; i++)
        //{
        //    //if (classDataList[i].Score == max)
        //    //{
        //    //    max = 100;
        //    //    maxName = "2 Winners";
        //    //}

        //    if (classDataList[i].Score >= max)
        //    {
        //        max = classDataList[i].Score;
        //        maxName = classDataList[i].ClassName;
        //    }

        //}

        ////Debug.Log(maxName + max);
        //Debug.Log(maxName + " score" + max);

        //gameManager.Movil(maxName, max);

    }

}
