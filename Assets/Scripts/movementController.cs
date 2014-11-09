using UnityEngine;
using System.Collections;

public class movementController : MonoBehaviour
{	
		public float m_speed =10;
		public float m_dragspeed =5;
		public GameObject m_target;

		
		// Use this for initialization
		void Start ()
		{
			
		}

		void findNewTarget(){
			EnemyAI[] enemyList= FindObjectsOfType<EnemyAI> ();
			float closestDis = Mathf.Infinity;
			GameObject closest = null;
			foreach (EnemyAI enemyScript in enemyList) {
						float disToEnemy = (enemyScript.transform.position - gameObject.transform.position).magnitude;
						if (disToEnemy < closestDis) {
								closest = enemyScript.gameObject;
								closestDis = disToEnemy;
						}
			}
			if (closest == null) {
				Debug.Log ("No enemies left");
			} else {
				m_target=closest;		
			}
		}

		void moveToTarget ()
		{
			if (m_target==null){
				findNewTarget();
			}
			rigidbody2D.AddForce(-rigidbody2D.velocity.normalized * m_dragspeed);
			bool upKey = Input.GetKey ("w");
			if (upKey){
				Vector2 dif = m_target.transform.position - transform.position;
				if ((dif).magnitude > 1) {
					rigidbody2D.AddForce (dif.normalized * m_speed);
				}
			}
		}
		// Update is called once per frame
		void Update ()
		{
			moveToTarget ();
		}

		void testingMove(){
				bool upKey = Input.GetKey ("w");
				bool downKey = Input.GetKey ("s");
				bool leftKey = Input.GetKey ("a");
				bool rightKey = Input.GetKey ("d");
		
				rigidbody2D.AddForce (-rigidbody2D.velocity.normalized * m_dragspeed);
				if (upKey) {
						rigidbody2D.AddForce (transform.up.normalized * m_speed);
				}
				if (downKey) {
						rigidbody2D.AddForce (-transform.up.normalized * m_speed);
				}
				if (leftKey) {
						rigidbody2D.AddForce (-transform.right.normalized * m_speed);
				}
				if (rightKey) {
						rigidbody2D.AddForce (transform.right.normalized * m_speed);
				}
		}
}
