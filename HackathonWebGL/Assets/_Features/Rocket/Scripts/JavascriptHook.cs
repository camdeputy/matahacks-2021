using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class JavascriptHook : MonoBehaviour
{
    public Rocket rocket;
    public RocketSelector rocketSelector;
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
       
    }

    public void LaunchRocket(){
        rocket.LaunchRocket();
    }

    public void SelectRocket(string rocketName){
        //This is where all the fethcing and setting
        //of data needs to happen.

        rocketSelector.SelectAndSetShowcaseRocket(rocketName);
        rocketSelector.SelectAndSetLaunchRocket(rocketName);
    }
}
