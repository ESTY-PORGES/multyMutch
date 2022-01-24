using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainManager : MonoBehaviour
{
    [SerializeField] private Animator circleBigAnim;
    // Start is called before the first frame update
    private IEnumerator Start()
    {
        yield return new WaitForSeconds(0.1f);
        circleBigAnim.SetInteger("onRotate", 1);
        yield return new WaitForSeconds(7);
        circleBigAnim.SetInteger("onRotate", 0);
    }

    public void PlayGame()
    {
        SceneManager.LoadScene(1);
    }
}
