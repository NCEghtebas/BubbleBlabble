using UnityEngine;
using System.Collections;

public class absorbController : MonoBehaviour {

	public float m_growFactor = 1.5f ;
	Animator anim;
	float angle;

	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator> ();
	}

	IEnumerator eat()
	{
		transform.rotation = Quaternion.AngleAxis(angle, Vector3.up);
		anim.SetBool ("isEating", true);
		yield return new WaitForSeconds (7f);
		anim.SetBool ("isEating", false);
		Debug.Log ("Finished eating");
	}

	void OnCollisionEnter2D(Collision2D hit){
		EnemyAI prey = hit.gameObject.GetComponent<EnemyAI> ();
		ObjectSize player_size = this.GetComponent<ObjectSize> ();
		angle = Vector3.Angle (prey.transform.position, gameObject.transform.position);

		if (prey.GetComponent<ObjectSize>().size < player_size.size) {
			rigidbody.AddTorque(Vector3.up * 10);
			StartCoroutine(eat ());
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
