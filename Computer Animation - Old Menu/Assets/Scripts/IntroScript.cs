using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class IntroScript : MonoBehaviour {
	void Update () {
        if (Input.GetKeyDown("space"))
        {
            SceneManager.LoadScene("Main Menu", LoadSceneMode.Single);
        }
    }
}
