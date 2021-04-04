using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraZoom : MonoBehaviour
{
    private Transform _startPosition;
    public float speed = 1.0f;
    public Transform target;
    public float threshold;

    // Start is called before the first frame update
    void Start()
    {
        _startPosition = transform;
    }

    // Update is called once per frame
    void Update()
    {
        var distance = Vector3.Distance(transform.position, target.position);
        Debug.Log(distance);
    }

    public void StartZoomIn()
    {
        StartCoroutine(ZoomIn());
    }

    private IEnumerator ZoomIn()
    {
        var distance = Vector3.Distance(transform.position, target.position);
        
        while (distance > threshold)
        {
            float step =  speed * Time.deltaTime; 
            transform.position = Vector3.MoveTowards(transform.position, target.position, step);
            distance = Vector3.Distance(transform.position, target.position);
            yield return null;
        }
    }
}
