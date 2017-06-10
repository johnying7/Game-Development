using UnityEngine;
using System.Collections;

public class CountdownAudioManager : MonoBehaviour {

    public AudioSource countdownSound;

    public AudioClip audioNum;
    public AudioClip audioGo;

	// Use this for initialization
	void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void playNumber()
    {
        //countdownSound.clip = audioNum;
        countdownSound.PlayOneShot(audioNum);
    }

    public void playGo()
    {
        //countdownSound.clip = audioGo;
        countdownSound.PlayOneShot(audioGo);
    }
}
