using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


public class ScreenFade : MonoBehaviour
{
    private Material currentMat;

    public UnityEvent HasFadedOut;
    public UnityEvent HasFadedIn;
    
    // Start is called before the first frame update
    void Start()
    {
        //currentMat = renderer.material;
        currentMat = GetComponent<Renderer>().material;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartFadeout()
    {
        Debug.Log("Starting Fade.");
        StartCoroutine(FadeOut());
    }

    private IEnumerator FadeOut()
    {
        var alphaVal = currentMat.color.a;

        while (alphaVal < 1)
        {
            Color color = currentMat.color;
            float currentAlpha = color.a;
            currentAlpha = Mathf.Min(currentAlpha + .005f, 1.0f);
            color.a = currentAlpha;
            currentMat.color = color;
            alphaVal = currentAlpha;
            yield return null;
        }

        HasFadedOut?.Invoke();
        StartFadeIn();
        
    }

    private IEnumerator FadeIn(){
        var alphaVal = currentMat.color.a;

        while (alphaVal > 0)
        {
            Color color = currentMat.color;
            float currentAlpha = color.a;
            currentAlpha = currentAlpha - .005f;
            color.a = currentAlpha;
            currentMat.color = color;
            alphaVal = currentAlpha;
            yield return null;
        }

        Debug.Log("We got there.");
        HasFadedIn?.Invoke();
    }

    public void StartFadeIn(){
        StartCoroutine(FadeIn());
    }
}
