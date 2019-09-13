using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SceneFader : MonoBehaviour
{
    public Image faderImage; //the Image we use for the FadeIn & FadeOut
    public AnimationCurve fadeCurve;

    private void Start()
    {
        StartCoroutine(FadeIn());//this starts the FadeIn() Function when the scene starts
    }

    public void FadeTo(string scene)
    {
        StartCoroutine(FadeOut(scene));
    }

    IEnumerator FadeIn()
    {
        float time = 1f;

        while (time > 0f)
        {
            time -= Time.deltaTime;
            float alpha = fadeCurve.Evaluate(time);
            faderImage.color = new Color(0f, 0f, 0f, alpha);//we set the image color and alpha
            yield return 0f; // wait one frame then continue (skip to next frame)

            // when we call this it create a time veritable, while the time is larger then 
            // zero we decreace the time a bit each frame until it reaches zero
        }
    }
    IEnumerator FadeOut(string scene)
    {
        float time = 0f;

        while (time < 1f)
        {
            time += Time.deltaTime * 3;
            float alpha = fadeCurve.Evaluate(time);
            faderImage.color = new Color(0f, 0f, 0f, alpha);//we set the image color and alpha
            yield return 0f; // wait one frame then continue (skip to next frame)

            // when we call this it create a time veritable, while the time is larger then 
            // zero we decreace the time a bit each frame until it reaches zero
        }
        SceneManager.LoadScene(scene);//This loads the scene we want after we fade out
    }


}
