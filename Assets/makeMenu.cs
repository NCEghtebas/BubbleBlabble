using UnityEngine;
using System.Collections;

public class makeMenu : MonoBehaviour {
	public Texture2D enemyIcon;
	public Texture2D playerIcon;

		
		void OnGUI () {
			// Make a background box
			//GUI.Box(new Rect(0,0,1000,100), "");
		GUI.backgroundColor = Color.clear;
			
			// Make the first button. If it is pressed, Application.Loadlevel (1) will be executed
			if(GUI.Button(new Rect(20,40,80,20), new GUIContent("New Game", playerIcon))) {
				Application.LoadLevel("test_scene");
			}
			
			// Make the second button.
			if(GUI.Button(new Rect(20,70,80,20),new GUIContent("Options",enemyIcon))) {
				Application.LoadLevel("options");
			}
		}
	}