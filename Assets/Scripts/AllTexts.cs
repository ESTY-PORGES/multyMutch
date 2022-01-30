using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class AllTexts : MonoBehaviour
{
    [SerializeField] private GameManager gameManager;
    [SerializeField] private Text classText;
   
    [SerializeField] private GameObject logo;

    

    void Start()
    {
        gameManager.OnCorrectClick += Correct3;
        gameManager.ClassSelected += EndSelectClass3;
        gameManager.ViewClass += CallCoroutine3;
        gameManager.OnWrongClick += NotCorrect3;
    }

    private void Correct3()
    {

        gameManager.ClassDataSelected.Score = gameManager.ClassDataSelected.Score + 10;
        classText.text = 10 + " + " + gameManager.ClassDataSelected.ClassName;
        Debug.Log("score" + gameManager.ClassDataSelected.Score);
        Debug.Log(gameManager.ClassDataSelected.ClassName);
        StartCoroutine(Feedback3(1));
    }

    private void NotCorrect3()
    {
      StartCoroutine(Feedback3(2));
    }

    private void EndSelectClass3(ClassData classData)
    {
        gameManager.ClassDataSelected = classData;
        classText.text = gameManager.ClassDataSelected.ClassName;
        classText.gameObject.SetActive(false);
        Debug.Log(gameManager.ClassDataSelected);
        gameManager.SetActiveText = false;
        gameManager.TextsetActive?.Invoke();
        StartCoroutine(HideClasses3());
    }

    private void CallCoroutine3()
    {
        StartCoroutine(viewClasses3());
    }

    private IEnumerator viewClasses3()
    {
        yield return new WaitForSeconds(3f);
        //scoreAnim.SetInteger("onScore", 0);
        classText.gameObject.SetActive(false);
        yield return new WaitForSeconds(2f);
        gameManager.SetActiveText = true;
        yield return new WaitForSeconds(0.1f);
        gameManager.TextsetActive?.Invoke();
    }

    private IEnumerator HideClasses3()
    {
        gameManager.SetActiveText = false;
        yield return new WaitForSeconds(2f);
        classText.gameObject.SetActive(true);
    }

    private IEnumerator Feedback3(int ifCorrect)
    {

        yield return new WaitForSeconds(4f);

        if (ifCorrect == 1)
        {
            gameManager.Feedback1.text = "!יפוי";
            gameManager.Feedback2.text = "!הרושק תא";
        }
        else
        {
            gameManager.Feedback1.text = "...מממ";
            gameManager.Feedback2.text = "?רשקה המ";

        }

        gameManager.Feedback1.gameObject.SetActive(true);
        gameManager.Feedback2.gameObject.SetActive(true);
        logo.gameObject.SetActive(true);

        yield return new WaitForSeconds(1f);

        gameManager.Feedback1.gameObject.SetActive(false);
        gameManager.Feedback2.gameObject.SetActive(false);
        logo.gameObject.SetActive(false);

    }
}
