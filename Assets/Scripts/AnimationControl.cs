using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class AnimationControl : MonoBehaviour {


	public int				inputMode, animationMode;
	public int chairState; // 0 = neither finished with stage, 1 = one finished, 2 = both finished


	private int				currChair = 2;          // which chair last pinged us? initialize as "no" chair
	public int[,]			chairs = new int[3, 1]; // chairs[2] is "no" chair
	
	// Game Stage GameObjects
	public GameObject[]		gameStages;	
	
	// Moon animation objects
	public GameObject[]	    moons;

	// Attached animation scripts
	private BlockingIn 		blockingIn;

	public static AnimationControl    S;

	void Awake() {
		S = this;
	}

	void Start() {
		// Reset
		Reset();
	}

	// Try ABANDONING this for a stage-based strategy
	// public void GetChairInput(int chairNum, int chairDirection) {
	// 	// which Animation Mode are we in?
	// 	switch(inputMode) {
	// 		case 0:
	// 			// Advance no Matter What
	// 			SimpleAdvancement();
	// 			return;
	// 		case 1:
	// 			// Advance only if Alternating
	// 			AlternateAdvancement(chairNum);
	// 			return;
	// 		case 2:
	// 			// Advance only if in Unison
	// 			StartCoroutine(UnisonAdvancement(chairNum, chairDirection));
	// 			return;
	// 		case 3:
	// 			// Advance only if in Union but Opposite
	// 			return;
	// 	}
	//
	// }

	// Stage-based strategy
	
	// Chair input controls guitar plucks
	public void GetChairInput(int chairNum, int chairDirection) {
		// Moon animation last the entirety of the experience
		Breathing b = moons[chairNum].GetComponent<Breathing>();
		b.StartCoroutine("Increase");
		
		// switch (GameManager.S.gameStage) {
		// 	case 0:
		// 		// Animate the moons via the Breathing Script
		// 		// Breathing script advances the Stage when complete
		// 		Breathing b = moons[chairNum].GetComponent<Breathing>();
		// 		b.StartCoroutine("Increase");
		// 		// both chairs have filled in their sky
		// 		if (chairState >= 2) {
		// 			SetTheStage(1);
		// 		}
		// 		return;
		// 	case 1:
		// 		// Show the full tree image for X seconds
		// 		return;
		// }
	}

	public void LaunchStage(int stage) {
		
	}

	public void SetTheStage(int nextGameStage) {
		chairState = 0;
		
		for (int i = 0; i < gameStages.Length; i++) {
			if (i == nextGameStage) gameStages[i].SetActive(true);
			else gameStages[i].SetActive(false);
		}
		
		AudioControl.S.NextStage(2f);

	}
	


	void Animate() {
			switch (animationMode) {
				case 0:
					// "Breathing" style animation (increasing size of images over time
					return;
				case 1:
					// Blocking in of images
					blockingIn.StartCoroutine("AdvanceAnimation");
					return;
				case 2:
					// ???
					return;
				case 3:
					// ???sp
					return;
			}
		}

		void SimpleAdvancement() {
			Animate();
		}

		void AlternateAdvancement(int chairTrig) {
			// New chair?
			if (chairTrig != currChair) {
				currChair = chairTrig;
				Animate();
			}
		}

		IEnumerator UnisonAdvancement(int thisChair, int chairDir) {
			chairs[thisChair, 0] = chairDir;

			// New chair?
			if (thisChair != currChair) {
				// is it going the same direction as the last chair?
				if (chairs[thisChair, 0] == chairs[currChair, 0]) {
					Animate();
				}
			}

			// this chair is now the current chair
			currChair = thisChair;

			// we wait for a few seconds
			yield return new WaitForSeconds(0.5f);
			// before we reset it's direction
			chairs[thisChair, 0] = 2;
			
	}

		void Reset() {
			// Reset Chairs
			for (int i = 0; i < 3; i++) {
				// Initialize all chairs as Resting
				chairs[i, 0] = 2;
			}
			
			// Reset Chair States
			chairState = 0; // 0 = no chair has finished their current task

			// start in simple advancemwnt mode
			inputMode = 0;

			// start in breathing animation mode
			animationMode = 0;

			// Load in the animation scripts
			blockingIn = gameObject.GetComponent<BlockingIn>();
		}
}
