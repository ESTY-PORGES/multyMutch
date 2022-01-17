using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MatchButton : MonoBehaviour
{
    public Button[] matchButton;
   
    // Start is called before the first frame update
    void Start()
    {
        
    }

    
    public void ClickButton()
    {
       
        Debug.Log("first click");
      
        matchButton[0].interactable = false;
    }
    
}
