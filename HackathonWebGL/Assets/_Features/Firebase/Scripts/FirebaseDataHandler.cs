using System;
using System.Collections;
using System.Collections.Generic;
using SimpleFirebaseUnity;
using UnityEngine;


public class FirebaseDataHandler : MonoBehaviour
{
    private Firebase _firebase;
    private Dictionary<string, Dictionary<string, string>> _rocketData;
    
    private const string FIREBASE_DOMAIN = "https://rocket2trees-default-rtdb.firebaseio.com";
    private const string ERROR_MESSAGE = "ERROR";


    private void Awake()
    {
        _firebase = Firebase.CreateNew(FIREBASE_DOMAIN);
        _firebase.OnGetSuccess += InitializeData;
        
        GetDataFromFirebase();
    }
    
    private void InitializeData(Firebase sender, DataSnapshot snapshot)
    {
        _rocketData = new Dictionary<string, Dictionary<string, string>>();
        Dictionary<string, object> dict = snapshot.Value<Dictionary<string, object>>();
        var rockets = snapshot.Keys;
        if (rockets == null)
        {
            Debug.Log($"{nameof(rockets)} is null.");
            return;
        }
            
        foreach (var rocket in rockets)
        {
            _rocketData.Add(rocket, new Dictionary<string, string>());
            if (!dict.ContainsKey(rocket))
            {
                Debug.Log($"{rocket} is not a valid key");
                continue;
            }

            var rocketValues = (Dictionary<string, object>) dict[rocket];
            if (rocketValues == null)
            {
                Debug.Log($"{nameof(rocketValues)} is null.");
                continue;
            }
                
            foreach (var value in rocketValues)
            {
                _rocketData[rocket].Add(value.Key, value.Value.ToString());
            }
        }
    }

    private void GetDataFromFirebase()
    {
        _firebase.GetValue(FirebaseParam.Empty.OrderByKey().LimitToFirst(2));
    }

    public string GetFieldString(string rocket, string field)
    {
        if (!_rocketData.ContainsKey(rocket))
        {
            Debug.Log($"{rocket} is not a valid key");
            return ERROR_MESSAGE;
        }

        if (!_rocketData[rocket].ContainsKey(field))
        {
            Debug.Log($"{field} is not a valid key for {rocket}");
            return ERROR_MESSAGE;
        }

        return _rocketData[rocket][field];
    }

    [ContextMenu("PrintData()")]
    private void PrintData()
    {
        foreach (var rocket in _rocketData.Keys)
        {
            Debug.Log($"{rocket}");
            foreach (var pair in _rocketData[rocket])
            {
                Debug.Log($"{pair.Key}:{pair.Value}");
            }
        }
    }
}
