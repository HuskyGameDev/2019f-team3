using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
	public void nextLevel(string sceneName){
        SceneManager.LoadScene(sceneName);
    }
	public void mainMenu(){
		//Application.LoadLevel("Main Menu");
        SceneManager.LoadScene("Manin Menu");
	}
	public void ExitGame() {
		Application.Quit();
		UnityEditor.EditorApplication.isPlaying = false;
    }
}
