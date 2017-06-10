using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class GameChooser : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void startBreakout()
    {
        SceneManager.LoadScene("Breakout");
    }

    public void startButtonMasher()
    {
        SceneManager.LoadScene("ButtonMasher");
    }
}
