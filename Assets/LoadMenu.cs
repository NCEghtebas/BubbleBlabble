using UnityEngine;
using System.Collections;

public class LoadMenu : MonoBehaviour {

	// Use this for initialization
	void Start () {
		Invoke ("loadMenu", 5f);
	}
	
	// Update is called once per frame
	void loadMenu(){
				Application.LoadLevel ("menu");
		}
}
