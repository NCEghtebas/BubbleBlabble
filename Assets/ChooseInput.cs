using UnityEngine;
using System.Collections;

public class ChooseInput : MonoBehaviour {
		
		void OnGUI () {
			// Make a background box
			GUI.Box(new Rect(10,10,100,90), "Choose Input Method");
			
			// Make the first button. If it is pressed, Application.Loadlevel (1) will be executed
			if(GUI.Button(new Rect(20,40,80,20), "SeaBoard")) {
				//Application.LoadLevel(1);
			}
			
			// Make the second button.
			if(GUI.Button(new Rect(20,70,80,20), "Keyboard")) {
				//Application.LoadLevel(2);
			}
		}
	}
