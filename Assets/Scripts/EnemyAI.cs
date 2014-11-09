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

	public float m_growFactor = 1.5f;

	IEnumerator playSound ()
	{	
		isPlayingSound = true;
		StartCoroutine (pulse());
		yield return new WaitForSeconds (3f);
		audio.Play ();
		isPlayingSound = false;
		Debug.Log ("Play Sound");
	}

	IEnumerator pulse()
	{
		if (Srenderer.sprite == normal) {
						Srenderer.sprite = highlighted;
				}
		else {
						Srenderer.sprite = normal;
				}
		yield return new WaitForSeconds (.5f);
		Debug.Log ("Change sprite");
		if (isPlayingSound) {
						StartCoroutine (pulse());
				}

	}

	void OnCollisionEnter2D(Collision2D hit){
		EnemyAI prey = hit.gameObject.GetComponent<EnemyAI> ();
		ObjectSize enemy_size = gameObject.GetComponent<ObjectSize> ();
		
		if (prey.GetComponent<ObjectSize>().size < enemy_size.size) {
			Debug.Log ("Hit");
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
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (!isPlayingSound) {
			StartCoroutine (playSound());
		}
		if (Srenderer.sprite == highlighted) {
			Srenderer.sprite = normal;
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
