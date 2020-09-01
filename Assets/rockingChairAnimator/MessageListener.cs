using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class MessageListener : MonoBehaviour
{
    void OnMessageArrived(string msg) {
        string[] incomingValues = msg.Split(' ');
        float pitch = float.Parse(incomingValues[0]);

        if (pitch > -30f) {
            TreeFade.S.StartCoroutine("AdvanceAnimation");
        }
    }
    
}
