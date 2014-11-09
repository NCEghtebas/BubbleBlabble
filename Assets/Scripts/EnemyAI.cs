using UnityEngine;
using System.Collections;

public class EnemyAI : MonoBehaviour
{

	public bool isPlayingSound = false;
	public GameObject m_target;
	public float m_speed = 5;
	public Sprite highlighted;
	public Sprite normal;
	Animator anim;

	private float angle;

	public float m_growFactor = 1.5f;

	public IEnumerator playSound ()
	{	
		anim.SetBool("isPlaying",true);
		isPlayingSound = true;
		yield return new WaitForSeconds (2f);
		isPlayingSound = false;
		audio.Play ();
		//Debug.Log ("Play Sound");
		anim.SetBool ("isPlaying", false);
	}

	IEnumerator eat()
	{
//		transform.rotation = Quaternion.AngleAxis(angle, Vector3.up);
		anim.SetBool ("isEating", true);
		yield return new WaitForSeconds (7f);
		anim.SetBool ("isEating", false);
		Debug.Log ("Finished eating");
	}


	void OnCollisionEnter2D(Collision2D hit){
		EnemyAI prey = hit.gameObject.GetComponent<EnemyAI> ();
		ObjectSize enemy_size = gameObject.GetComponent<ObjectSize> ();
//		angle = Vector3.Angle (prey.transform.position, gameObject.transform.position);
		
		if (prey.GetComponent<ObjectSize>().size < enemy_size.size) {
			Debug.Log ("Hit");
			StartCoroutine(eat ());

			Destroy (prey.m_target);
			Destroy (hit.gameObject);
			
			gameObject.transform.localScale = gameObject.transform.localScale * m_growFactor;
			enemy_size.setSize (enemy_size.size * m_growFactor);
		} 

		else {
			Destroy (gameObject);
		}
		
	}

	// Use this for initialization
	void Start ()
	{
		anim = GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update ()
	{
		moveToTarget ();
	}
	void moveToTarget ()
	{
		Vector2 dif = m_target.transform.position - transform.position;
		if ((dif).magnitude > 1) {
			rigidbody2D.AddForce (dif * m_speed);
		}
	}
}
