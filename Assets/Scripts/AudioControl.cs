using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AudioControl : MonoBehaviour
{
    	
    // Get Init Strum
    public AudioSource[]		strum, backStrum;
    public AudioMixerSnapshot[] audioStates;

    public static AudioControl  S;
    
    void Awake() {
        S = this;
        audioStates[0].TransitionTo(0.1f);
    }

    void Start() {
        Reset();
    }

    public void ChairControlledSound(int chairNum, int chairDirection) {
        if (GameManager.S.audioStage >= 0) {
            if (chairDirection == 1) {
                // back
                // play the preliminary guitar note
                strum[chairNum].Play();
            }
        }
        
    }

    public void NextStage(float speed) {
        GameManager.S.audioStage++;
        audioStates[GameManager.S.audioStage].TransitionTo(speed);
        Debug.Log("Loading Stage: " + GameManager.S.audioStage);
    }
    
    public void LoadStage(int stage, float speed) {
        GameManager.S.audioStage = stage;
        audioStates[stage].TransitionTo(speed);
        Debug.Log("Loading Stage: " + GameManager.S.audioStage);
    }

    public void Reset() {
        audioStates[0].TransitionTo(2f);
        GameManager.S.audioStage = 0;


    }
}
