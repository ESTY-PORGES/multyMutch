using System.Collections;
using UnityEngine.Events;
using UnityEngine.UI;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public UnityAction OnWrongClick;
    public UnityAction OnCorrectClick;
    public UnityAction SelectClass;
    public UnityAction<ClassData> ClassSelected;
    public UnityAction OnGift;
    public UnityAction Movilclass;
    public UnityAction TextsetActive;
    public UnityAction ViewClass;

    [SerializeField] private GameObject movilllll;
    [SerializeField] private Text classs;
    [SerializeField] private Text scoree;
    [SerializeField] private Text classText;

    [SerializeField] private Text feedback1;
    [SerializeField] private Text feedback2;
   
    public Texture2D cursorTexture;
    public CursorMode cursorMode = CursorMode.Auto;
    public Vector2 hotSpot = Vector2.zero;

    private bool setActiveText;
    private int correctClicks = 0;
    public bool SetActiveText
    {
        get { return setActiveText; }
        set
        {
            setActiveText = value;
        }
    }

   
    private ClassData classDataSelected;
    public ClassData ClassDataSelected
    {
        get { return classDataSelected; }
        set
        {
            classDataSelected = value;
        }

    }



    public Text Feedback1
    {
        get { return feedback1; }
        set
        {
            feedback1 = value;
        }

    }

    public Text Feedback2
    {
        get { return feedback2; }
        set
        {
            feedback2 = value;
        }

    }

    
    public int CorrectClicks
    {
        get { return correctClicks; }
        set
        {
            correctClicks = value;
          
            if (correctClicks >= 8)
            {
               
                Movilclass?.Invoke();

            }

        }
    }
    
  
    public void Movil(string class1, int score1)
    {
        movilllll.gameObject.SetActive(true);
        scoree.text = score1.ToString();
        classs.text = class1;
    }
   

   
}
