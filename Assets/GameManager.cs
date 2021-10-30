using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {
    public int gameStage;
    public int audioStage;
    public int numStages = 3;

    public GameObject title;

    private bool[] stageLoaded = new bool[4];
    
    public float[] timeRocking = new float[2];
    public float[] eventThresholds;

    public static GameManager S;

    void Awake() {
        S = this;
    }
    
    
    
    // Start is called before the first frame update
    void Start() {
        ResetGame();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) {
            ResetGame();
        }
        
        for (int i = 0; i < timeRocking.Length; i++) {
            timeRocking[i] += Time.deltaTime;
        }

        if (timeRocking[0] > eventThresholds[0] && timeRocking[0] < eventThresholds[1] &&
            timeRocking[1] > eventThresholds[0] && timeRocking[1] < eventThresholds[1]) {
            int stageToLoad = 1;
            if (!stageLoaded[stageToLoad]) {
                LoadNextStage(stageToLoad, 0.25f);
                AudioControl.S.LoadStage(stageToLoad, 1f);
            }
        }
        
        if (timeRocking[0] > eventThresholds[1] && timeRocking[0] < eventThresholds[2] &&
            timeRocking[1] > eventThresholds[1] && timeRocking[1] < eventThresholds[2]) {
            int stageToLoad = 2;
            if (!stageLoaded[stageToLoad]) {
                LoadNextStage(stageToLoad, 1f);
                AudioControl.S.LoadStage(stageToLoad, 1f);
            }
        }
        
        if (timeRocking[0] > eventThresholds[2] && timeRocking[0] < eventThresholds[3] &&
            timeRocking[1] > eventThresholds[2] && timeRocking[1] < eventThresholds[3]) {
            int stageToLoad = 3;
            if (!stageLoaded[stageToLoad]) {
                LoadNextStage(stageToLoad, 2f);
                AudioControl.S.LoadStage(stageToLoad, 60f);
            }
        }
        
        if (timeRocking[0] > eventThresholds[3] && timeRocking[1] > eventThresholds[3]) {
            //SceneManager.LoadScene("Title");
            AudioControl.S.LoadStage(4, 0.1f);
            title.SetActive(true);
        }
        
        // for (int i = 0; i < eventThresholds.Length; i++) {
        //     if (timeRocking[0] > eventThresholds[i] &&
        //         timeRocking[0] < eventThresholds[i + 1] &&
        //         timeRocking[1] > eventThresholds[i] &&
        //         timeRocking[1] < eventThresholds[i + 1])
        //     {
        //         if (!stageLoaded[i]) {
        //             if (i < 3) LoadNextStage(i);
        //             else SceneManager.LoadScene("Title");
        //         }
        //
        //     }
        // }
    }

    public void LoadNextStage(int STL, float AD) {
        gameStage = STL;
        Debug.Log("Stage:" + gameStage); 
        BuildingAnimations.S.PrepStage(STL-1, AD);
        // if(STL == 2) {
        //     Debug.Log("this should be the insect stage");
        //     BuildingAnimations.S.animationDelay = 2f;
        //     AudioControl.S.NextStage(.005f);
        // }
        // else AudioControl.S.NextStage(1f);
        stageLoaded[STL] = true;
    }

    public void ResetClock() {
        Debug.Log("Clock Reset");
        for (int i = 0; i < timeRocking.Length; i++) {
            timeRocking[i] = 0;
        }
        for (int i = 0; i < numStages; i++) {
            stageLoaded[i] = false;
        }
        gameStage = 0;
        BuildingAnimations.S.Reset();
    }


    public void ResetGame() {
        for (int i = 0; i < numStages; i++) {
            stageLoaded[i] = false;
        }
        gameStage = 0;
        audioStage = 0;
        timeRocking[0] = 0;
        timeRocking[1] = 0;
        AudioControl.S.Reset();
        title.SetActive(false);
    }
}
