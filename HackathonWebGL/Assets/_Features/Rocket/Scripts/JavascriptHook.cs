using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JavascriptHook : MonoBehaviour
{

    public Rocket rocket; 

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space)){
            Debug.Log("Launching baby.");
            LaunchRocket();
        }
    }

    public void LaunchRocket(){
        rocket.LaunchRocket();
    }
}
