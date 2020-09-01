using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeFade : MonoBehaviour {

    public static TreeFade    S;

    public bool    ready;
    
    private Sprite[] frames;
    public GameObject frame;
    private int frameCount = 0;
    private int fadeTime = 100;
    

    void Awake() {
        S = this;
    }
    
    // Start is called before the first frame update
    void Start() {
        frames = Resources.LoadAll<Sprite>("TreeSprites");        
        ready = true;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space)) {
            //AdvanceAnimation();
        }
    }

    public IEnumerator AdvanceAnimation() {
        if (ready) {
            ready = false;
            GameObject go = GameObject.Instantiate(frame) as GameObject;

            Vector3 pos = new Vector3(0, 0, 0);
            go.transform.position = pos;
            SpriteRenderer sr    = go.GetComponent<SpriteRenderer>();
            int            fader = 0;
            sr.color = new Color(1, 1, 1, 0);
            sr.sprite = frames[frameCount];

            StartCoroutine(Fade(sr));
            Debug.Log(frameCount);

            yield return new WaitForSeconds(1);
            frameCount++;
        }

    }

    private IEnumerator Fade(SpriteRenderer _sr) {
        float lerpAmount=0;
        float fadeSpeed = .003f;
        while(lerpAmount<1)
        {
            Color c =_sr.color;
            c.a=Mathf.Lerp(0,1,lerpAmount);
            _sr.color=c;
            lerpAmount+=fadeSpeed;
            yield return null;
        }

        ready = true;
    }
}
