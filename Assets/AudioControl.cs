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
    }

    public void Reset() {
        audioStates[0].TransitionTo(0.5f);
        GameManager.S.audioStage = 0;


    }
}
