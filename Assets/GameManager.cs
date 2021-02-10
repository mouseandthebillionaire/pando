using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {
    public int gameStage;
    public int audioStage;
    
    public static GameManager S;

    void Awake() {
        S = this;
    }
    
    
    
    // Start is called before the first frame update
    void Start() {
        ResetGame();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ResetGame() {
        gameStage = 0;
        audioStage = 0;
    }
}
