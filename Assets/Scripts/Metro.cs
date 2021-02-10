using System.Collections;
using System.Collections.Generic;
using System.Net.Sockets;
using UnityEditorInternal.Profiling.Memory.Experimental;
using UnityEngine;

public class Metro : MonoBehaviour {
    public AudioSource breath;
    
    private Sprite[]    introImages;

    public SpriteRenderer sr;
    private int m;
    private int prevM;
    
    // Start is called before the first frame update
    void Start() {
        m = 0;
        prevM = 0;
        introImages = Resources.LoadAll<Sprite>("TreeSprites");   
    }

    // Update is called once per frame
    void FixedUpdate() {
        //m = Time.time - prevM;
        m = (int) Time.time;
                

        if (prevM != m) {
            if (m % 2 == 0) {
                sr.sprite = introImages[m % introImages.Length];
                breath.Play();
            }
            prevM = m;
        }

        //sr.color = new Color(sr.color.r, sr.color.g, sr.color.b, m);

    }
}
