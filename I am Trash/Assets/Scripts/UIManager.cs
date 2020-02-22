using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 
public class UIManager : MonoBehaviour
{
	public void nextLevel(string sceneName){
		Application.LoadLevel(sceneName);
	}
	public void mainMenu(){
		Application.LoadLevel("Main Menu");
	}
	public void ExitGame() {
		Application.Quit();
		UnityEditor.EditorApplication.isPlaying = false;
    }
}
