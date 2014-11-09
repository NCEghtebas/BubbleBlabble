using UnityEngine;
using System.Collections;

public class seaBoardMove : MonoBehaviour {

	public float m_speed =10;
	public float m_dragspeed =5;
	public GameObject m_target;

	// Use this for initialization
	void Start () {
	
	}

	void moveToTarget ()
	{
		float upKey = MidiJack.GetKey (65);
		rigidbody2D.AddForce(-rigidbody2D.velocity.normalized * m_dragspeed);
		Vector2 dif = m_target.transform.position - transform.position;
		if ((dif).magnitude > 1) {
			rigidbody2D.AddForce (dif.normalized * m_speed * upKey *10);
		}
	}

	// Update is called once per frame
	//65,67,69,71
	void Update () {
		moveToTarget ();
	}
	void testingMove(){
		float upKey = MidiJack.GetKey (65);
		float downKey= MidiJack.GetKey (67);
		float leftKey = MidiJack.GetKey (69);
		float rightKey = MidiJack.GetKey (71);
		rigidbody2D.AddForce(-rigidbody2D.velocity.normalized * m_dragspeed);
		if (upKey>0.1){
			rigidbody2D.AddForce(transform.up.normalized * m_speed * upKey * 10);
		}
		if (downKey>0.1) {
			rigidbody2D.AddForce(-transform.up.normalized * m_speed * downKey * 10);
		}
		if (leftKey>0.1) {
			rigidbody2D.AddForce(-transform.right.normalized * m_speed * leftKey * 10);
		}
		if (rightKey>0.1) {
			rigidbody2D.AddForce(transform.right.normalized * m_speed * rightKey * 10);
		}
	}
}
