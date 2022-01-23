using System.Collections;
using System.Collections.Generic;
using UnityEngine.Events;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public UnityAction OnWrongClick;
    public UnityAction OnCorrectClick;
    public UnityAction SelectClass;
    public UnityAction ClassSelected;


    [SerializeField] private Animator circleAnim;
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip[] sounds;

    [SerializeField] private GameObject backroundBlue;
    [SerializeField] private GameObject classbuttons;


    private void Start()
    {
        SelectAClass();

        OnCorrectClick += Correct;
        OnWrongClick += NotCorrect;
        SelectClass += SelectAClass;
        ClassSelected += EndSelectClass;


        audioSource.clip = sounds[2];
        audioSource.Play();
    }

    private void Correct()
    {
        audioSource.clip = sounds[0];
        audioSource.Play();

        //Color tmp2 = sprite1[pairData.IndexPair].GetComponent<Image>().color;
        //tmp2.a = 0.3f;
        //sprite1[pairData.IndexPair].GetComponent<Image>().color = tmp2;
        //Color tmp3 = sprite2[pairData.IndexPair].GetComponent<Image>().color;
        //tmp3.a = 0.3f;
        //sprite2[pairData.IndexPair].GetComponent<Image>().color = tmp3;

        circleAnim.SetInteger("onSpin", 1);
        StartCoroutine(StopAnim());
    }

    private void NotCorrect()
    {
        circleAnim.SetInteger("onSpin", 2);
        audioSource.clip = sounds[1];
        audioSource.Play();
        StartCoroutine(StopAnim());
    }

    private void SelectAClass()
    {
        circleAnim.SetInteger("onSpin", 5);
        backroundBlue.gameObject.SetActive(true);
        classbuttons.gameObject.SetActive(true);
    }

    private void EndSelectClass()
    {
        circleAnim.SetInteger("onSpin", 6);
        backroundBlue.gameObject.SetActive(false);
        classbuttons.gameObject.SetActive(false);
    }







    private IEnumerator StopAnim()
    {
        yield return new WaitForSeconds(1f);
        audioSource.clip = sounds[2];
        audioSource.Play();
        yield return new WaitForSeconds(1f);
        circleAnim.SetInteger("onSpin", 0);

        yield return new WaitForSeconds(1f);
        SelectAClass();

    }

}
