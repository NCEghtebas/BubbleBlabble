using UnityEngine;
using System.Collections;

public class movementController : MonoBehaviour
{	
		public float m_speed =10;
		public float m_dragspeed =5;
	
		
		// Use this for initialization
		void Start ()
		{
			
		}
	
		// Update is called once per frame
		void Update ()
		{
			bool upKey = Input.GetKey ("w");
			bool downKey= Input.GetKey ("s");
			bool leftKey = Input.GetKey ("a");
			bool rightKey = Input.GetKey ("d");

			rigidbody2D.AddForce(-rigidbody2D.velocity.normalized * m_dragspeed);
			if (upKey){
				rigidbody2D.AddForce(transform.up.normalized * m_speed);
			}
			if (downKey) {
				rigidbody2D.AddForce(-transform.up.normalized * m_speed);
			}
			if (leftKey) {
				rigidbody2D.AddForce(-transform.right.normalized * m_speed);
			}
			if (rightKey) {
				rigidbody2D.AddForce(transform.right.normalized * m_speed);
			}
				
		}
}
