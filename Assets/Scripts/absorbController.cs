using UnityEngine;
using System.Collections;

public class absorbController : MonoBehaviour {

	public float m_growFactor = 1.5f ;

	// Use this for initialization
	void Start () {
	
	}

	void OnCollisionEnter2D(Collision2D hit){
		EnemyAI prey = hit.gameObject.GetComponent<EnemyAI> ();
		ObjectSize player_size = this.GetComponent<ObjectSize> ();

		if (prey.GetComponent<ObjectSize>().size < player_size.size) {
			rigidbody.AddTorque(Vector3.up * 10);
						Debug.Log ("Hit");
						Destroy (prey.m_target);
						Destroy (hit.gameObject);

						gameObject.transform.localScale = gameObject.transform.localScale * m_growFactor;
						player_size.setSize (player_size.size * m_growFactor);
				} 
		else {
			gameObject.transform.localScale = gameObject.transform.localScale/m_growFactor;
			player_size.setSize (player_size.size/m_growFactor);
				}

	}

	// Update is called once per frame
	void Update () {
		if (gameObject.GetComponent<ObjectSize> ().size < .5) {
			Destroy (gameObject);
				}

	}
}
