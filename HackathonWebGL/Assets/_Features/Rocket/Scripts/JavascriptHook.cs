using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class JavascriptHook : MonoBehaviour
{
    public Rocket rocket;
    public TextMeshProUGUI name;
    public TextMeshProUGUI co2;
    public TextMeshProUGUI kg_co2;
    public TextMeshProUGUI passengers;
    public TextMeshProUGUI tons_co2_passenger;
    public TextMeshProUGUI fuelType;

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

    public void SelectRocket(string rocketName){
        name.text = "Rocket Name: " + rocketName;
    }
}
