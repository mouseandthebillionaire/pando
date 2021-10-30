using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChairCommunication: MonoBehaviour {
    public int chairNum;
    public KeyCode[] keyDirection = {KeyCode.A, KeyCode.S};
    
    public float[] pitchThreshold = {8f, 1f}; // 0 = forward | 1 = back
    private float[] medianPitch = {-77f, -74f};
    
    public float pitch;
    public int direction = 2; // 0 = forward | 1 = back | 2 = none;

    public bool acceptingFront = true;
    public bool acceptingBack = true;


    void Update() {
        for(int i=0; i < keyDirection.Length; i++){
            if (Input.GetKeyDown(keyDirection[i])) {
                AnimationControl.S.GetChairInput(chairNum, i);
                AudioControl.S.ChairControlledSound(chairNum, i);
            }
        }
    }
    
    void OnMessageArrived(string msg) {
        string[] incomingValues = msg.Split(' ');
        pitch = float.Parse(incomingValues[0]);

        if (acceptingBack) {
            if (pitch < pitchThreshold[1]) {
                direction = 1;
                acceptingBack = false;
                acceptingFront = true;
                // Tell Controller to Do Something
                AnimationControl.S.GetChairInput(chairNum, direction);
                AudioControl.S.ChairControlledSound(chairNum, direction);
            }
        }

        if (acceptingFront) {
            if (pitch > pitchThreshold[0]) {
                direction = 0;
                acceptingBack = true;
                acceptingFront = false;
                // Tell Controller to Do Something
                AnimationControl.S.GetChairInput(chairNum, direction);
            }
        }

        if (pitch <= pitchThreshold[0] && pitch >= pitchThreshold[1]) {
            // we're stationary
            acceptingFront = true;
            acceptingBack = true;
            direction = 2;
        }
    }
    
}
