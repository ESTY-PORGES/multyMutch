using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;


public class CardManager : MonoBehaviour
{
    private bool firstImageSelected = false;
    private string card1;
    [SerializeField] private Image[] sprite1;
    [SerializeField] private Image[] sprite2;
    //private SpriteRenderer spriteR;

    [SerializeField] private Animator circleAnim;
    [SerializeField] private ClassManager classManager;
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip[] sounds;

    private void Start()
    {
        audioSource.clip = sounds[2];
        audioSource.Play();
        //spriteR = gameObject.GetComponent<SpriteRenderer>();
    }


    public void OnClickCard(PairData pairData)
    {
      
      
        if (classManager.selectClass == true)
        {
            if (firstImageSelected == false && pairData.Group == 1)
            {
                Debug.Log(pairData.PairName);
                Debug.Log(pairData.Group);
                Debug.Log(pairData.Sprite);
                card1 = pairData.PairName;
                firstImageSelected = true;
                sprite1[pairData.IndexPair].sprite = pairData.Sprite;
            }

            if (firstImageSelected == true && pairData.Group == 2)
            {
                Debug.Log(pairData.PairName);
                Debug.Log(pairData.Group);
                Debug.Log(pairData.Sprite);
                sprite2[pairData.IndexPair].sprite = pairData.Sprite;

                if (pairData.PairName == card1)
                {
                    Debug.Log("correct");

                    classManager.AddScore();
                    audioSource.clip = sounds[0];
                    audioSource.Play();

                    Color tmp2 = sprite1[pairData.IndexPair].GetComponent<Image>().color;
                    tmp2.a = 0.3f;
                    sprite1[pairData.IndexPair].GetComponent<Image>().color = tmp2;
                    Color tmp3 = sprite2[pairData.IndexPair].GetComponent<Image>().color;
                    tmp3.a = 0.3f;
                    sprite2[pairData.IndexPair].GetComponent<Image>().color = tmp3;


                    //tmp.a = 0f;
                    /*.GetComponent<SpriteRenderer>().color = tmp;*/
                    //sprite1[0].GetComponent<SpriteRenderer>().color += new Color(0, 0, 0, 0);
                    //text.text = "correct";
                    circleAnim.SetInteger("onSpin", 1);
                    StartCoroutine(StopAnim());
                    //AddScore();
                }

                else
                {
                    circleAnim.SetInteger("onSpin", 2);
                    Debug.Log("notCorrect");
                    audioSource.clip = sounds[1];
                    audioSource.Play();
                    StartCoroutine(StopAnim());

                    //text.text = "notCorrect";
                    //StartCoroutine(InitializeText());
                }
                firstImageSelected = false;
                classManager.selectClass = false;
            }
        }
        else
        {
            return;
        }

      

    }
    private IEnumerator StopAnim()
    {
        yield return new WaitForSeconds(1f);
        audioSource.clip = sounds[2];
        audioSource.Play();
        yield return new WaitForSeconds(1f);
        circleAnim.SetInteger("onSpin", 0);
      
    }


















    //[SerializeField] private Text text;
    //[SerializeField] private Text scoreText;

    //[SerializeField] private bool firstImageSelected;

    //[SerializeField] private string card1;
    //[SerializeField] private ClassManager classManager;

    //public void UpdateDisplayUI(PairData pairData)
    //{
    //   if (classManager.SelectClass == true)
    //    {
    //        if (firstImageSelected == false && pairData.Group == 1)
    //        {
    //            Debug.Log(pairData.PairName);
    //            Debug.Log(pairData.Group);
    //            card1 = pairData.PairName;
    //            firstImageSelected = true;
    //        }

    //        if (firstImageSelected == true && pairData.Group == 2)
    //        {
    //            Debug.Log(pairData.PairName);
    //            Debug.Log(pairData.Group);

    //            if (pairData.PairName == card1)
    //            {
    //                Debug.Log("correct");
    //                text.text = "correct";
    //                StartCoroutine(InitializeText());
    //                AddScore();
    //            }

    //            else
    //            {
    //                Debug.Log("notCorrect");
    //                text.text = "notCorrect";
    //                StartCoroutine(InitializeText());
    //            }
    //            firstImageSelected = false;
    //            classManager.SelectClass = false;
    //        }
    //    }
    //    else
    //    {
    //        return;
    //    }




    //}  

    //public void AddScore()
    //{
    //    classManager.scoreofClass++;
    //    scoreText.text = classManager.scoreofClass.ToString();
    //    Debug.Log(classManager.nameofClass + "Your score is " + classManager.scoreofClass);

    //}




    //private IEnumerator InitializeText()
    //{
    //    yield return new WaitForSeconds(2f);
    //    Debug.Log("התכ רחב");
    //    text.text = "התכ רחב";
    //}
}
