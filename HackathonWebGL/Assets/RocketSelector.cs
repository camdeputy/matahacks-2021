using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketSelector : MonoBehaviour
{
    public List<GameObject> showcaseRocketList = new List<GameObject>();
    public List<GameObject> launchRocketList = new List<GameObject>();
    public string tempRocketName;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("space"))
        {
            SelectAndSetShowcaseRocket(tempRocketName);
            SelectAndSetLaunchRocket(tempRocketName);
        }
    }

    public void SelectAndSetShowcaseRocket(string rocketName){
        for(int i=0; i < showcaseRocketList.Count; i++){
            if(showcaseRocketList[i].name == rocketName) {
                showcaseRocketList[i].SetActive(true);

            }else{
                showcaseRocketList[i].SetActive(false);
            }
        }
    }

    public void SelectAndSetLaunchRocket(string rocketName){
        for(int i=0; i < launchRocketList.Count; i++){
            if(launchRocketList[i].name == rocketName) {
                launchRocketList[i].SetActive(true);
            }else{
                launchRocketList[i].SetActive(false);
            }
        }
    }
}
