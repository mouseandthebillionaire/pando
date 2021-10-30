using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Breathing : MonoBehaviour {
    public float[]              stageSizes;
    
    private float               size, ogSize;
    private int                 currStage;
    private int                 chairNum;

    private bool                rocking;
    private float               timePassed;
    private float               delayTime = 4f;
    private float               startTime;
    
    
    

    // Start is called before the first frame update
    void Start() {
        size = 0.1f;
        ogSize = size;
        startTime = 0;
        currStage = 0;
        chairNum = this.transform.GetSiblingIndex();
    }

    void FixedUpdate() {
        timePassed = Time.time - startTime;
        
        if (timePassed >= delayTime) {
            rocking = false;
            startTime = Time.time;
            // took too long, reset the game clock
            GameManager.S.ResetClock();
            AudioControl.S.Reset();
        }
        
        // Start shrinking if not rocking 
        if (!rocking && size >= 0.25f) {
            size -= .001f;
            this.transform.localScale = new Vector3(size, size, this.transform.localScale.z);
        }

        AudioControl.S.backStrum[chairNum].volume = (size - .125f);
    }
    
    
    public IEnumerator Increase() {
        rocking = true;
        startTime = Time.time;
        float increaseSize = Random.Range(0.0075f, 0.0125f);
        float newSize      = size + increaseSize;

        // Advance chair state based on circle size
        // implement if change that moons no longer remain for duration of experience
        // if (newSize >= stageSizes[currStage]) {
        //     AnimationControl.S.chairState++;
        //     Debug.Log(AnimationControl.S.chairState);
        // }
        
        while (size < newSize) {
            size += .005f;
            this.transform.localScale = new Vector3(size, size, this.transform.localScale.z); 
            yield return null;
        }
    }
}
