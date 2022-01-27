using System.Collections;
using UnityEngine.Events;
using UnityEngine.UI;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public UnityAction OnWrongClick;
    public UnityAction OnCorrectClick;
    public UnityAction SelectClass;
    public UnityAction ClassSelected;
    public UnityAction OnGift;
    public UnityAction Movilclass;
    public UnityAction TextsetActive;

    [SerializeField] private Animator classButtonAnim;
    [SerializeField] private Animator circleAnim;
    [SerializeField] private Animator giftAnim;
    [SerializeField] private Animator imageAnim;
    [SerializeField] private Animator littleCircleAnim;
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip[] sounds;

    [SerializeField] private GameObject backroundBlue;
    [SerializeField] private GameObject classbuttons;

    [SerializeField] private GameObject movilllll;
    [SerializeField] private Text classs;
    [SerializeField] private Text scoree;

    [SerializeField] private Text feedback1;
    [SerializeField] private Text feedback2;

    //private string feedback1;
    //private string feedback2;

    public Text Feedback1
    {
        get { return feedback1; }
        //set
        //{
        //    feedback1 = value;
        //}

    }

    public Text Feedback2
    {
        get { return feedback2; }
        //set
        //{
        //    feedback2 = value;
        //}

    }


    public Texture2D cursorTexture;
    public CursorMode cursorMode = CursorMode.Auto;
    public Vector2 hotSpot = Vector2.zero;

    private bool setActiveText;
    private int correctClicks = 0;
    public bool SetActiveText => setActiveText;

  

    #region IEnumerator Start
    private IEnumerator Start()
    {
        //Cursor.SetCursor(cursorTexture, hotSpot, cursorMode);
        audioSource.clip = sounds[2];
        audioSource.Play();
        imageAnim.SetInteger("onImage", 1);
        littleCircleAnim.SetInteger("onCircle", 1);
        yield return new WaitForSeconds(2f);
        SelectAClass();

        OnCorrectClick += Correct;
        //OnClickClass += 
        OnWrongClick += NotCorrect;
        SelectClass += SelectAClass;
        ClassSelected += EndSelectClass;
        //Movilclass += Movil;

        OnGift += GetGift;
       
       
    }

    #endregion

    #region CorrectClicks
    public int CorrectClicks
    {
        get { return correctClicks; }
        set
        {
            correctClicks = value;
            //OnWrongClick?.Invoke(health);
            if (correctClicks >= 8)
            {
               
                Movilclass?.Invoke();

            }

        }
    }
    #endregion

    # region Correct

    private void Correct()
    {
        audioSource.clip = sounds[0];
        audioSource.Play();
        littleCircleAnim.SetInteger("onCircle", 1);
        StartCoroutine(StopAnim());
        StartCoroutine(Feedback(1));
    }
    #endregion


    #region  GetGift
    private void GetGift()
    {
        giftAnim.SetInteger("onGift", 1);
    }
    #endregion

    # region NotCorrect

    private void NotCorrect()
    {
        circleAnim.SetInteger("onSpin", 2);
        audioSource.clip = sounds[1];
        audioSource.Play();
        StartCoroutine(StopAnim());

        StartCoroutine(Feedback(2));
    }
    #endregion

    # region SelectAClass

    private void SelectAClass()
    {
        littleCircleAnim.SetInteger("onCircle", 0);
        StartCoroutine(viewClasses());
    }

    #endregion

    #region EndSelectClass

    private void EndSelectClass()
    {
        StartCoroutine(HideClasses());
        StartCoroutine(StopAnim1());
        setActiveText = false;
        TextsetActive?.Invoke();
    }

    #endregion


    #region IEnumerator StopAnim1
    private IEnumerator StopAnim1()
    {
        yield return new WaitForSeconds(1f);
        littleCircleAnim.SetInteger("onCircle", 0);
    }
    #endregion

    #region IEnumerator StopAnim

    private IEnumerator StopAnim()
    {
        yield return new WaitForSeconds(1f);
        audioSource.clip = sounds[2];
        audioSource.Play();

        //yield return new WaitForSeconds(1f);
        circleAnim.SetInteger("onSpin", 0);
        littleCircleAnim.SetInteger("onCircle", 0);
        
        yield return new WaitForSeconds(1.5f);
        SelectAClass();

    }

    #endregion

    #region IEnumerator viewClasses

    private IEnumerator viewClasses()
    {
       
        yield return new WaitForSeconds(1f);
        backroundBlue.gameObject.SetActive(true);
        yield return new WaitForSeconds(1f);
        circleAnim.SetInteger("onSpin", 5);
        yield return new WaitForSeconds(3f);
        classButtonAnim.SetBool("chooseClass", true);
        classbuttons.gameObject.SetActive(true);
        setActiveText = true;
        yield return new WaitForSeconds(1f);
        TextsetActive?.Invoke();

    }


    #endregion

    # region IEnumerator Feedback

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
    #endregion


    #region IEnumerator HideClasses
    private IEnumerator HideClasses()
    {
        circleAnim.SetInteger("onSpin", 6);

        classButtonAnim.SetBool("chooseClass", false);

        setActiveText = false;
        littleCircleAnim.SetInteger("onCircle", 1);
        yield return new WaitForSeconds(2f);

        backroundBlue.gameObject.SetActive(false);
    }
    #endregion

    #region Movil

    public void Movil(string class1, int score1)
    {
        movilllll.gameObject.SetActive(true);
        scoree.text = score1.ToString();
        classs.text = class1;
    }
    #endregion

   
}
