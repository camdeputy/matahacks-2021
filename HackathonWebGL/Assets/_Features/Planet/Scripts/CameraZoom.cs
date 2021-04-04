using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


public class CameraZoom : MonoBehaviour
{
    public Vector3 _startPosition;
    public float speed = 1.0f;
    public Transform target;
    public float threshold;
    public UnityEvent HasReturned;



    // Start is called before the first frame update
    void Start()
    {
        _startPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        var distance = Vector3.Distance(transform.position, target.position);
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

    private IEnumerator ZoomOut(){        
        while (transform.position != _startPosition)
        {
            float step =  speed * Time.deltaTime; 
            transform.position = Vector3.MoveTowards(transform.position, _startPosition, step);
            yield return null;
        }

        HasReturned?.Invoke();
    }

    public void StartZoomOut(){
        StartCoroutine(ZoomOut());
    }
}
