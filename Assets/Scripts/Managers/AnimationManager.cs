using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationManager : MonoBehaviour
{
    [SerializeField] private Animator classButtonAnim;
    [SerializeField] private Animator circleAnim;
    [SerializeField] private Animator giftAnim;
    [SerializeField] private Animator imageAnim;
    [SerializeField] private Animator littleCircleAnim;

    [SerializeField] private GameObject backroundBlue;
    [SerializeField] private GameObject classbuttons;


    [SerializeField] private GameManager gameManager;

    private void Start()
    {
        imageAnim.SetInteger("onImage", 1);
        littleCircleAnim.SetInteger("onCircle", 1);

        gameManager.OnCorrectClick += Correct;
    }
    private void Correct()
    {
        littleCircleAnim.SetInteger("onCircle", 1);
    }

    private void NotCorrect()
    {
        circleAnim.SetInteger("onSpin", 2);
        
    }

    private void GetGift()
    {
        giftAnim.SetInteger("onGift", 1);
    }

    private void SelectAClass()
    {
        littleCircleAnim.SetInteger("onCircle", 0);
        //StartCoroutine(viewClasses());
    }

    private IEnumerator StopAnim1()
    {
        yield return new WaitForSeconds(1f);
        littleCircleAnim.SetInteger("onCircle", 0);
    }

    private IEnumerator StopAnim()
    {
        //yield return new WaitForSeconds(1f);
        circleAnim.SetInteger("onSpin", 0);
        littleCircleAnim.SetInteger("onCircle", 0);

        yield return new WaitForSeconds(1.5f);
        //SelectAClass();

    }

    private IEnumerator viewClasses()
    {
        yield return new WaitForSeconds(1f);
        backroundBlue.gameObject.SetActive(true);
        yield return new WaitForSeconds(1f);
        circleAnim.SetInteger("onSpin", 5);
        yield return new WaitForSeconds(3f);
        classButtonAnim.SetBool("chooseClass", true);
        classbuttons.gameObject.SetActive(true);
    }

    private IEnumerator HideClasses()
    {
        circleAnim.SetInteger("onSpin", 6);

        classButtonAnim.SetBool("chooseClass", false);

        //setActiveText = false;
        littleCircleAnim.SetInteger("onCircle", 1);
        yield return new WaitForSeconds(2f);

        backroundBlue.gameObject.SetActive(false);
    }
}
