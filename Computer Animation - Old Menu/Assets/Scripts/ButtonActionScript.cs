using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonActionScript : MonoBehaviour {

	public void MENU_ACTION_GOtoPage(string sceneName)
    {
        Application.LoadLevel(sceneName);
    }

}
