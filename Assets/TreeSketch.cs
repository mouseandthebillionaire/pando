using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeSketch : MonoBehaviour {
    public SpriteRenderer   treeSketch;

    private float o = 0;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate() {
        o += 0.01f;
        treeSketch.color = new Color(1f, 1f, 1f, o);
    }
}
