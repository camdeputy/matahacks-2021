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
        _firebase.OnGetSuccess += GetOKHandler;
    }
    
    void GetOKHandler(Firebase sender, DataSnapshot snapshot)
    {
        Debug.Log("[OK] Get from key: <" + sender.FullKey + ">");
        Debug.Log("[OK] Raw Json: " + snapshot.RawJson);

        Dictionary<string, object> dict = snapshot.Value<Dictionary<string, object>>();
        List<string> keys = snapshot.Keys;

        if (keys != null)
            foreach (string key in keys)
            {
                Debug.Log(key + " = " + dict[key].ToString());
            }
    }

    [ContextMenu("TestGet()")]
    public void TestGet()
    {
        _firebase.GetValue(FirebaseParam.Empty.OrderByKey().LimitToFirst(2));
    }

    void DebugLog(string str)
    {
        Debug.Log(str);
    }
}
