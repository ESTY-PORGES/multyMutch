using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;


public class CardManager : MonoBehaviour
{
    private bool firstImageSelected = false;

    private bool currectClick = false;

    [SerializeField] private Image[] sprite1;
    [SerializeField] private Image[] sprite2;

    [SerializeField] private GameManager gameManager;
    [SerializeField] private ClassManager classManager;

    [SerializeField] private ParticleSystem particles;

    private int indexButtonClicked1;
    private int indexButtonClicked2;

    public int IndexButtonClicked1 => indexButtonClicked1;
    public int IndexButtonClicked2 => indexButtonClicked2;

    private void Start()
    {
        firstImageSelected = false;

    }

    public void OnClickCard(PairData pairData)
    {
        if (classManager.selectClass == true && firstImageSelected == false)
        {
            currectClick = false;
            firstImageSelected = true;
            StartCoroutine(Flickering(pairData.IndexPair));
            indexButtonClicked1 = pairData.IndexPair;


            if(pairData.Group == 1)
            {
                sprite1[pairData.IndexPair].sprite = pairData.Sprite;
            }
            else 
            {
                sprite2[pairData.IndexPair].sprite = pairData.Sprite;
            }
               
        }

        else if (firstImageSelected == true)
        {
            Debug.Log(pairData.IndexPair);
            indexButtonClicked2 = pairData.IndexPair;

            firstImageSelected = false;
            classManager.selectClass = false;

            if (pairData.Group == 2)
            {
                sprite2[pairData.IndexPair].sprite = pairData.Sprite;
                
            }
            else 
            {
                sprite1[pairData.IndexPair].sprite = pairData.Sprite;
            }
         

            if (indexButtonClicked1 == indexButtonClicked2)
            {
                Debug.Log("correct");
                currectClick = true;

                gameManager.OnCorrectClick?.Invoke();
               
                Color tmp2 = sprite1[pairData.IndexPair].GetComponent<Image>().color;
                tmp2.a = 0.3f;
                sprite1[pairData.IndexPair].GetComponent<Image>().color = tmp2;
                Color tmp3 = sprite2[pairData.IndexPair].GetComponent<Image>().color;
                tmp3.a = 0.3f;
                sprite2[pairData.IndexPair].GetComponent<Image>().color = tmp3;

                if (indexButtonClicked1 == 1)
                {
                    particles.Play();
                    gameManager.OnGift?.Invoke();
                    gameManager.OnCorrectClick?.Invoke();
                }
            }

            else
            {

                gameManager.OnWrongClick?.Invoke();
                currectClick = false;
                Debug.Log("notCorrect");
            }

        }



    }

    private IEnumerator Flickering(int currentIndex)
    {
        while (firstImageSelected == true)
        {
            yield return new WaitForSeconds(0.5f);

            Color tmp1 = sprite1[currentIndex].GetComponent<Image>().color;
            tmp1.a = 0.5f;
            sprite1[currentIndex].GetComponent<Image>().color = tmp1;

            yield return new WaitForSeconds(0.5f);

            tmp1 = sprite1[currentIndex].GetComponent<Image>().color;
            tmp1.a = 1;
            sprite1[currentIndex].GetComponent<Image>().color = tmp1;
        }

        if (currectClick == true)
        {
            Color tmp2 = sprite1[currentIndex].GetComponent<Image>().color;
            tmp2.a = 0.3f;
            sprite1[currentIndex].GetComponent<Image>().color = tmp2;
        }

        else
        {
            Color tmp2 = sprite1[currentIndex].GetComponent<Image>().color;
            tmp2.a = 1;
            sprite1[currentIndex].GetComponent<Image>().color = tmp2;
        }
    }



}
    
       

    
    


















    





