using System;
using System.Collections;
using System.Collections.Generic;
using Proyecto26;
using SimpleFirebaseUnity;
using UnityEngine;


public class FirebaseManager : MonoBehaviour
{
    private Firebase _firebase;
    
    private const string FIREBASE_DOMAIN = "https://rocket2trees-default-rtdb.firebaseio.com";


    private void Awake()
    {
        _firebase = Firebase.CreateNew(FIREBASE_DOMAIN);
        _firebase.OnGetSuccess += GetDataFromFirebase;
    }
    
    private void GetDataFromFirebase(Firebase sender, DataSnapshot snapshot)
    {
        Dictionary<string, object> dict = snapshot.Value<Dictionary<string, object>>();
        var rockets = snapshot.Keys;
        if (rockets == null)
        {
            Debug.Log($"{nameof(rockets)} is null.");
            return;
        }
            
        foreach (var rocket in rockets)
        {
            Debug.Log($"{nameof(rocket)}={rocket}");
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
                Debug.Log($"{nameof(value.Key)}={value.Key} {nameof(value.Value)}={value.Value}");
            }
        }
    }

    [ContextMenu("TestGet()")]
    public void TestGet()
    {
        _firebase.GetValue(FirebaseParam.Empty.OrderByKey().LimitToFirst(2));
    }
}
