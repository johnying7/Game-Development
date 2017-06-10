using UnityEngine;
using System.Collections;

public class explosion : MonoBehaviour {
	
	bool played = false;
	public GameObject explosionEffect;
	AudioSource explodeAudio;
	public movement moveScript;
	public GameObject cube;

	bool startTimer = false;
	float timer = 3; // time in seconds

	// Use this for initialization
	void Start () {
		moveScript = this.GetComponent<movement> ();
		explodeAudio = GetComponent<AudioSource> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.Space) && played == false) {
			cube.SetActive (false);
			played = !played;
			moveScript.enabled = false;
			GetComponent<AudioSource>().Play ();
			explosionEffect.SetActive (true);
			startTimer = true;
			this.GetComponent<Rigidbody> ().isKinematic = true;
		}

		if (startTimer) {
			Timer ();
		}
	}

	void Timer()
	{
		timer -= Time.deltaTime;
		if (timer < 0.0f) {
			startTimer = false;
			explosionEffect.SetActive (false);
		}
	}
}
