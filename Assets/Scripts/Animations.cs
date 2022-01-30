using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Animations : MonoBehaviour
{
    [SerializeField] private GameManager gameManager;
  
    [SerializeField] private Animator scoreAnim;
    [SerializeField] private Animator imageAnim;
    [SerializeField] private Animator littleCircleAnim;
    [SerializeField] private Animator giftAnim;
    [SerializeField] private Animator classButtonAnim;
    [SerializeField] private Animator circleAnim;

    [SerializeField] private GameObject backroundBlue;
    [SerializeField] private GameObject classbuttons;
    private IEnumerator Start()
    {
       gameManager.OnCorrectClick += Correct2;
       gameManager.ClassSelected += EndSelectClass2;
       gameManager.OnGift += GetGift;
       gameManager.ViewClass += CallCoroutine;
       gameManager.OnWrongClick += NotCorrect2;
       imageAnim.SetInteger("onImage", 1);
       littleCircleAnim.SetInteger("onCircle", 1);
       yield return new WaitForSeconds(2f);
       StartCoroutine(viewClasses());
       StartCoroutine(StopAnim1());
    }

   
    private void Correct2()
    {
        scoreAnim.SetInteger("onScore", 1);
        littleCircleAnim.SetInteger("onCircle", 1);
        StartCoroutine(StopAnim());
    }

    private void NotCorrect2()
    {
        circleAnim.SetInteger("onSpin", 2);
        
        StartCoroutine(StopAnim());

        
    }

    private void EndSelectClass2(ClassData classData)
    {
        StartCoroutine(StopAnim());
        StartCoroutine(HideClasses());
    }

    private void GetGift()
    {
        giftAnim.SetInteger("onGift", 1);
    }

    private void CallCoroutine()
    {
        StartCoroutine(viewClasses());
    }

    private IEnumerator viewClasses()
    {

        yield return new WaitForSeconds(1f);
        backroundBlue.gameObject.SetActive(true);
        yield return new WaitForSeconds(1f);
        circleAnim.SetInteger("onSpin", 5);
        yield return new WaitForSeconds(2.5f);
        classButtonAnim.SetBool("chooseClass", true);
        classbuttons.gameObject.SetActive(true);
      

    }
    private IEnumerator HideClasses()
    {

        circleAnim.SetInteger("onSpin", 6);
        classButtonAnim.SetBool("chooseClass", false);
        yield return new WaitForSeconds(2f);
        backroundBlue.gameObject.SetActive(false);
    }


    private IEnumerator StopAnim()
    {
        yield return new WaitForSeconds(1f);
        littleCircleAnim.SetInteger("onCircle", 0);
        yield return new WaitForSeconds(2f);
        scoreAnim.SetInteger("onScore", 0);
        yield return new WaitForSeconds(1.5f);
        //StartCoroutine(viewClasses());
    }
    private IEnumerator StopAnim1()
    {
        yield return new WaitForSeconds(2f);
        littleCircleAnim.SetInteger("onCircle", 0);
    }
}
