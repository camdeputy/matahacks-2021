using System;
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

    [SerializeField] private FirebaseDataHandler firebaseDataHandler;
    [SerializeField] private TreeGenerator treeGenerator;
    
    private Dictionary<string, string> _defaultTextValues;
    
    //FIELD NAMES MUST MATCH FIREBASE FIELD NAMES
    private const string NAME = "Name";
    private const string CO2 = "CO2";
    private const string FUEL_TYPE = "Fuel Type";
    private const string KG_CO2 = "KG:CO2";
    private const string PASSENGERS = "Passengers";
    private const string TONS_CO2_PASSENGERS = "Tons of CO2 per passenger";
    private const float TEST_DELAY = 2;


    private void Awake()
    {
        _defaultTextValues = new Dictionary<string, string>
        {
            {NAME, name.text},
            {CO2, co2.text},
            {KG_CO2, kg_co2.text},
            {PASSENGERS, passengers.text},
            {TONS_CO2_PASSENGERS, tons_co2_passenger.text},
            {FUEL_TYPE, fuelType.text}
        };
    }

    public void LaunchRocket(){
        rocket.LaunchRocket();
    }

    public void SelectRocket(string rocketName){
        //This is where all the fetching and setting
        //of data needs to happen.

        rocketSelector.SelectAndSetShowcaseRocket(rocketName);
        rocketSelector.SelectAndSetLaunchRocket(rocketName);
        
        PopulateUI(rocketName);
        //GenerateTrees(rocketName);
    }

    private void PopulateUI(string rocketName)
    {
        name.text = $"{_defaultTextValues[NAME]} {rocketName}";
        
        var co2Value = firebaseDataHandler.GetFieldString(rocketName, CO2);
        co2.text = $"{_defaultTextValues[CO2]} {co2Value}";
        
        var kgCo2Value = firebaseDataHandler.GetFieldString(rocketName, KG_CO2);
        kg_co2.text = $"{_defaultTextValues[KG_CO2]} {kgCo2Value}";
        
        var passengersValue = firebaseDataHandler.GetFieldString(rocketName, PASSENGERS);
        passengers.text = $"{_defaultTextValues[PASSENGERS]} {passengersValue}";
        
        var tonsPerPassengerValue = firebaseDataHandler.GetFieldString(rocketName, TONS_CO2_PASSENGERS);
        tons_co2_passenger.text = $"{_defaultTextValues[TONS_CO2_PASSENGERS]} {tonsPerPassengerValue}";
        
        var fuelTypeValue = firebaseDataHandler.GetFieldString(rocketName, FUEL_TYPE);
        fuelType.text = $"{_defaultTextValues[FUEL_TYPE]} {fuelTypeValue}";
    }

    public void GenerateTrees()
    {
        var tonsOfCo2 = Int32.Parse(firebaseDataHandler.GetFieldString(rocketSelector.currRocket.name, CO2));
        treeGenerator.GenerateTrees(tonsOfCo2);     //Number of trees generated is tonsOfC02 * 50
    }
    
    private void ClearUI()
    {
        name.text = $"{_defaultTextValues[NAME]}";
        co2.text = $"{_defaultTextValues[CO2]}";
        kg_co2.text = $"{_defaultTextValues[KG_CO2]}";
        passengers.text = $"{_defaultTextValues[PASSENGERS]}";
        tons_co2_passenger.text = $"{_defaultTextValues[TONS_CO2_PASSENGERS]}";
        fuelType.text = $"{_defaultTextValues[FUEL_TYPE]}";
    }
    
    [ContextMenu("Test()")]
    private void Test()
    {
        StartCoroutine(TestCoroutine());
    }

    private IEnumerator TestCoroutine()
    {
        //ROCKET NAMES MUST MATCH FIREBASE NAMES
        SelectRocket("Atlas V N22");
        yield return new WaitForSeconds(TEST_DELAY);
        SelectRocket("Falcon 9");
        yield return new WaitForSeconds(TEST_DELAY);
        SelectRocket("SLS");
        yield return new WaitForSeconds(TEST_DELAY);
        SelectRocket("Soyuz FG");
        yield return new WaitForSeconds(TEST_DELAY);
        SelectRocket("Space Shuttle");
        yield return new WaitForSeconds(TEST_DELAY);
        SelectRocket("Starship + Super Heavy");
        yield return new WaitForSeconds(TEST_DELAY);
        SelectRocket("Titan II");
        yield return new WaitForSeconds(TEST_DELAY);
        
        ClearUI();
        treeGenerator.ClearTrees();
    }
}
