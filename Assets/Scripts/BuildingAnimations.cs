using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingAnimations : MonoBehaviour {
    public  GameObject             animationCell;
    public float                   animationDelay;
    private int                    cellNum;
    private Sprite[]               topo, landFormation, treeSprites;
    private List<Sprite[]>         animations = new List<Sprite[]>();        
    private string[]               animationNames = {"topo", "landFormation"};
    private int                    currAnimation;
    private bool                   animationComplete;
    
    
    // timing
    private float m;
    private float prevM;

    public static BuildingAnimations S;

    void Awake() {
        S = this;
    }
    
    // Start is called before the first frame update
    void Start()
    {
        
        topo = Resources.LoadAll<Sprite>("Topo"); 
        landFormation = Resources.LoadAll<Sprite>("landFormation");
        treeSprites = Resources.LoadAll<Sprite>("TreeSprites");
        animations.Add(landFormation);
        animations.Add(topo);
        animations.Add(treeSprites);
        Reset();
    }

    void FixedUpdate() {
        // timer
        m = Time.time - prevM;
        if (m >= animationDelay) {
            if (GameManager.S.gameStage > 0) {
                AddAnimationCell();
            }
            prevM = Time.time;
        }
        
        // Testing
    }

    public void AddAnimationCell() {
        if (cellNum < animations[currAnimation].Length && !animationComplete) {
            GameObject     go = GameObject.Instantiate(animationCell) as GameObject;
            SpriteRenderer sr = go.GetComponent<SpriteRenderer>();
            sr.sprite = animations[currAnimation][cellNum];
            go.transform.parent = this.transform;
            go.name = cellNum.ToString();
            cellNum++;
        }
        if (cellNum >= animations[currAnimation].Length) {
            animationComplete = true;
            Debug.Log("I'm still true?");
            StartCoroutine("HoldAndClear");
        }

    }

    public IEnumerator HoldAndClear() {
        yield return new WaitForSeconds(20);
        ClearAnimations();
    }


    public void ClearAnimations() {
        // delete all children
        int childs = this.transform.childCount;
        for (int i = 0; i < childs; i++)
        {
            GameObject.Destroy(transform.GetChild(i).gameObject);
        }
    }

    public void PrepStage(int STL, float AD) {
        cellNum = 0;
        currAnimation = STL;
        prevM = Time.time;
        animationDelay = AD;
        animationComplete = false;
        ClearAnimations();
    }

    public void Reset() {
        cellNum = 0;
        m = 0;
        prevM = 0;
        animationDelay = 0.25f;
        currAnimation = 0;
        animationComplete = false;
        ClearAnimations();
    }
}
