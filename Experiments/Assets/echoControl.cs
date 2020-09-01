using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class echoControl : MonoBehaviour {
    private float timeBetweenSpawns;
    public float startSpawnTime;

    public GameObject echo;
   

    // Update is called once per frame
    void Update(){
        if (timeBetweenSpawns <= 0) {
            GameObject instance = (GameObject)Instantiate(echo, transform.position, Quaternion.identity);
            instance.transform.localScale = transform.localScale;
            Debug.Log(transform.localScale);
            Destroy(instance, 2f);
            timeBetweenSpawns = startSpawnTime;
        } else {
            timeBetweenSpawns -= Time.deltaTime;
        }
        
    }
}
