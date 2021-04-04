using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Rocket : MonoBehaviour
{
    public Transform rocket;
    public float distance;
    public float totalTimeToComplete;
    private Transform _startPosition;
    public UnityEvent rocketHasLanded;
    
    // Start is called before the first frame update
    void Start()
    {
        _startPosition = rocket;
        //LaunchRocket();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public void LaunchRocket()
    {
        StartCoroutine(MovingRocket(totalTimeToComplete, rocket));
    }

    private IEnumerator MovingRocket(float time, Transform rocket)
    {
        Vector3 startingPos  = rocket.position;
        Vector3 finalPos = rocket.position + (rocket.forward * distance);
        float elapsedTime = 0;
         
        while (elapsedTime < time)
        {
            rocket.position = Vector3.Lerp(startingPos, finalPos, (elapsedTime / time));
            elapsedTime += Time.deltaTime;
            yield return null;
        }
        
        rocketHasLanded?.Invoke();
    }

    public void ResetRocket()
    {
        rocket.position = _startPosition.position;
    }
}
