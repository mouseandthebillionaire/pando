using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChairCommunication: MonoBehaviour
{
    void OnMessageArrived(string msg) {
        string[] incomingValues = msg.Split(' ');
        float pitch = float.Parse(incomingValues[0]);

        if (pitch > -30f) {
            //TreeFade.S.StartCoroutine("AdvanceAnimation");
            Debug.Log("Doing it");
        }
    }
    
}
