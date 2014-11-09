using UnityEngine;
using System.Collections;

public class TargetAI : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		var t = Time.time;

		Vector3 delta = new Vector3 (Mathf.Sin(t), Mathf.Cos (t),0)*.05F;
		transform.position += delta;
	}
}
