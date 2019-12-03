using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using Image = UnityEngine.UI.Image;

public class LineLayer : MonoBehaviour {

    public GameObject layer;
    public Sprite[] layerImages;
    public Image[] layers;
    private int activeLayer;
    
    // Start is called before the first frame update
    void Start() {
        
        layers = new Image[layerImages.Length];
        
        for (int i = 0; i < layerImages.Length; i++) {
            GameObject go = GameObject.Instantiate(layer) as GameObject;
            Image img = go.GetComponent<Image>();
            img.sprite = layerImages[i];
            img.fillAmount = 0f;
            if (i % 2 == 0) {
                img.fillOrigin = 0;
            }
            else {
                img.fillOrigin = 1;
            }
            go.transform.parent = this.transform;
            RectTransform rt = go.GetComponent<RectTransform>();
            rt.offsetMin = new Vector2(0, -768f);
            rt.offsetMax = new Vector2(1024, 0f);
            rt.anchoredPosition3D = Vector3.zero;

            layers[i] = img;

        }

        activeLayer = layerImages.Length - 1;
    }

    // Update is called once per frame
    void Update(){
        if (Input.GetKeyDown(KeyCode.Space)) {
            if (layers[activeLayer].fillAmount < 1f) {
                layers[activeLayer].fillAmount += .1f;
            }
            else {
                activeLayer--;
            }
        }
        
    }
    
    
    
}
