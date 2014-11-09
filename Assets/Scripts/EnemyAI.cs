using UnityEngine;
using System.Collections;

public class EnemyAI : MonoBehaviour
{

	private bool isPlayingSound = false;
	public GameObject m_target;
	public float m_speed = 5;
	public Sprite highlighted;
	public Sprite normal;
	private SpriteRenderer Srenderer;
	Animator anim;

	public float m_growFactor = 1.5f;

	IEnumerator playSound ()
	{	
		anim.SetBool("isPlaying",true);
		yield return new WaitForSeconds (3f);
		audio.Play ();
		Debug.Log ("Play Sound");
		anim.SetBool ("isPlaying", false);
	}

	IEnumerator eat()
	{
		anim.SetBool ("isEating", true);
		yield return new WaitForSeconds (3f);
		anim.SetBool ("isEating", false);
	}


	void OnCollisionEnter2D(Collision2D hit){
		EnemyAI prey = hit.gameObject.GetComponent<EnemyAI> ();
		ObjectSize enemy_size = gameObject.GetComponent<ObjectSize> ();
		
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
		Srenderer = GetComponent<SpriteRenderer> ();
		anim = GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (!isPlayingSound) {
			StartCoroutine (playSound());
		}
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
