using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneManagerAux : MonoBehaviour
{
    public string[] scene;
    public Image fadeout;

    private void Start()
    {
        fadeout.CrossFadeAlpha(0, 0.5f, false);
    }

    public void FadeOut(int s)
    {
        fadeout.CrossFadeAlpha(1, 0.5f, false);
        StartCoroutine(ChangeScene(scene[s]));
    }

    IEnumerator ChangeScene(string scene)
    {
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene(scene);
    }
}
