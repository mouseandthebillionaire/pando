using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Breathing : MonoBehaviour {
    private float                size, ogSize, maxSize;
    
    private bool                rocking;
    private float               timePassed;
    private float               delayTime = 2f;
    private float               startTime;
    
    
    

    // Start is called before the first frame update
    void Start() {
        size = 0.1f;
        ogSize = size;
        startTime = 0;
        maxSize = 2f;
    }

    void FixedUpdate() {
        timePassed = Time.time - startTime;
        
        if (timePassed >= delayTime && size >= 0.25f) {
            size -= .001f;
            this.transform.localScale = new Vector3(size, size, this.transform.localScale.z);
        }

        AudioControl.S.backStrum[transform.GetSiblingIndex()].volume = (size - .25f);

    }
    
    
    public IEnumerator Increase() {
        startTime = Time.time;
        float increaseSize = Random.Range(0.025f, 0.075f);
        float newSize      = size + increaseSize;

        if (newSize >= maxSize) {
            AnimationControl.S.chairState++;
        }
        while (size < newSize) {
            size += .005f;
            this.transform.localScale = new Vector3(size, size, this.transform.localScale.z); 
            yield return null;
        }
    }
}
