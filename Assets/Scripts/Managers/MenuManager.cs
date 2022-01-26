using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

    
    public class MenuManager : MonoBehaviour
{
    [SerializeField] private Animator playAnim;

    private IEnumerator Start()
    {
        yield return new WaitForSeconds(0.1f);
        playAnim.SetInteger("onPlay", 1);
        yield return new WaitForSeconds(7);
        playAnim.SetInteger("onPlay", 0);
    }

    public void PlayGame()
    {
        SceneManager.LoadScene(1);
    }

}
