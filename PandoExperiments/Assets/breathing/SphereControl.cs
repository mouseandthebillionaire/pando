using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SphereControl : MonoBehaviour {
    private int                  chair1_state, chair2_state; 
    // 0 = stationary, 1 = moving back, 2 = moving forward

    private float                sizeX, sizeY, rotZ;
    
    private float                timeBetweenSpawns;

    private SpriteRenderer       ringSprite;
    public Color                 ringColor;
    public float                 startSpawnTime;
    private float                rotSpeed;
    public GameObject            echo;

    public KeyCode               fKey, bKey;
    

    // Start is called before the first frame update
    void Start() {
        sizeX = 0.25f;
        sizeY = 0.25f;
        rotZ = Random.Range(0, 360);
        transform.localScale = new Vector3(sizeX, sizeY, 1);
        ringSprite = GetComponent<SpriteRenderer>();
        ringSprite.color = ringColor;

    }

    // Update is called once per frame
    void Update() {
        rotZ += rotSpeed;
        
        
        if (Input.GetKey(bKey)) {
            chair1_state = 1;
        }
        else if (Input.GetKey(fKey)) {
            chair1_state = 2;
        }
        else {
            chair1_state = 0;
        }

        Debug.Log(chair1_state);


        if (chair1_state == 1) {
            sizeX += .01f;
            sizeY += .01f;
            rotSpeed += .01f;
        }

        if (chair1_state == 2) {
            sizeX -= .0075f;
            sizeY -= .0075f;
        }

        if (chair1_state == 0) {
            if (sizeX > 0.25f) {
                sizeX -= .0075f;
                sizeY -= .0075f;
                rotSpeed -= .01f;
            }
            else {
                sizeX = 0.25f;
                sizeY = 0.25f;
                rotSpeed = 0;
            }
        }

        transform.localScale = new Vector3(sizeX, sizeY, 1);
        transform.rotation = Quaternion.Euler(0, 0, rotZ);

        if (chair1_state == 1) {
            if (timeBetweenSpawns <= 0) {
                GameObject instance = (GameObject) Instantiate(echo, transform.position, transform.rotation);
                instance.transform.localScale = new Vector3(sizeX, sizeY);
                Debug.Log(sizeX);
                Destroy(instance, 2f);
                timeBetweenSpawns = startSpawnTime;
            }
            else {
                timeBetweenSpawns -= Time.deltaTime;
            }
        }
    }
}
