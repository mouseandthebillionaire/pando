using UnityEngine;
using UnityEditor;
using System.Collections;
 
public class animAdvance : MonoBehaviour {
  public float animationSpeed = 1;
  private int currentKeyFrame = 0;
  private Animator animator;
  private AnimatorStateInfo asi;
  
  void Start() {
    animator = GetComponent<Animator>();
    asi = animator.GetCurrentAnimatorStateInfo(0);

  }
 
  void Update() {
    // this stops the animation
    animator.speed = 0;
 
    if(Input.GetKey(KeyCode.DownArrow))
    {
      nextKeyFrame();
    }
  }
 
  void nextKeyFrame()
  {
  
    // this allows the animation to advance
    animator.speed = 1;
    animator.playbackTime += 1;

  }
}