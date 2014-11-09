using UnityEngine;
using System.Collections;

public class accessKeys : MonoBehaviour {

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		Debug.Log(MidiJack.GetKey (53));

	}
}
