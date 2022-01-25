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
    public UnityAction OnGift;


    [SerializeField] private Animator circleAnim;
    [SerializeField] private Animator giftAnim;
    [SerializeField] private Animator imageAnim;
    [SerializeField] private Animator littleCircleAnim;
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip[] sounds;

    [SerializeField] private GameObject backroundBlue;
    [SerializeField] private GameObject classbuttons;

    public Texture2D cursorTexture;
    public CursorMode cursorMode = CursorMode.Auto;
    public Vector2 hotSpot = Vector2.zero;

    private bool setActiveText;

    public bool SetActiveText => setActiveText;


    private IEnumerator Start()
    {
        Cursor.SetCursor(cursorTexture, hotSpot, cursorMode);
        audioSource.clip = sounds[2];
        audioSource.Play();
        imageAnim.SetInteger("onImage", 1);
        littleCircleAnim.SetInteger("onCircle", 1);
        yield return new WaitForSeconds(2f);
        SelectAClass();

        OnCorrectClick += Correct;
        OnWrongClick += NotCorrect;
        SelectClass += SelectAClass;
        ClassSelected += EndSelectClass;
        OnGift += GetGift;
       
       
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

        littleCircleAnim.SetInteger("onCircle", 1);

        StartCoroutine(StopAnim());
    }

    private void GetGift()
    {
        giftAnim.SetInteger("onGift", 1);
       
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
        littleCircleAnim.SetInteger("onCircle", 0);
        circleAnim.SetInteger("onSpin", 5);
        backroundBlue.gameObject.SetActive(true);
        classbuttons.gameObject.SetActive(true);
        setActiveText = true;
    }

    private void EndSelectClass()
    {
        circleAnim.SetInteger("onSpin", 6);
        backroundBlue.gameObject.SetActive(false);
        classbuttons.gameObject.SetActive(false);
        setActiveText = false;
        littleCircleAnim.SetInteger("onCircle", 1);
        StartCoroutine(StopAnim1());
    }



    private IEnumerator StopAnim1()
    {
        yield return new WaitForSeconds(1f);
        littleCircleAnim.SetInteger("onCircle", 0);
    }



    private IEnumerator StopAnim()
    {
        yield return new WaitForSeconds(1f);
        audioSource.clip = sounds[2];
        audioSource.Play();
        yield return new WaitForSeconds(3f);
        circleAnim.SetInteger("onSpin", 0);
        littleCircleAnim.SetInteger("onCircle", 0);
        
        yield return new WaitForSeconds(1f);
        SelectAClass();

    }

}
