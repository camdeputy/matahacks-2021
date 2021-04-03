using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenFade : MonoBehaviour
{
    private Material currentMat;
    
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
    }
}
