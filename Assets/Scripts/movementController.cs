using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class movementController : MonoBehaviour
{	
		public float m_speed =10;
		public float m_dragspeed =5;
		public GameObject m_target;

	private Dictionary<string,int> midiNum=new Dictionary<string,int>();
	private Dictionary<int,string> midiStr=new Dictionary<int, string>();
		// Use this for initialization
		void Start ()
		{
		
		midiNum.Add ("G#", 68);
		midiNum.Add ("Ab" , 68);
		midiNum.Add ("A" , 69);
		midiNum.Add ("A#", 70);
		midiNum.Add ("Bb", 70);
		midiNum.Add ("B", 71);
		midiNum.Add ("C", 72);
		midiNum.Add ("C#", 73);
		midiNum.Add ("Db", 73);
		midiNum.Add ("D", 74);
		midiNum.Add ("D#", 75);
		midiNum.Add ("Eb", 75);
		midiNum.Add ("E", 76);
		midiNum.Add ("F", 77);
		midiNum.Add ("F#", 78);
		midiNum.Add ("Gb", 78);
		midiNum.Add ("G", 79);
		
		midiStr.Add ( 68, "Ab");
		midiStr.Add ( 69, "A");
		midiStr.Add ( 70, "Bb");
		midiStr.Add ( 71, "B");
		midiStr.Add ( 72, "C");
		midiStr.Add ( 73, "Db");
		midiStr.Add ( 74, "D");
		midiStr.Add ( 75, "Eb");
		midiStr.Add ( 76, "E");
		midiStr.Add ( 77, "F");
		midiStr.Add ( 78, "Gb");
		midiStr.Add ( 79, "G");
		}

	private int calcKey(){
		char[] u = {'_'};
		char[] x = {'x'};
		char[] p = {'+'};
		char[] m = {'-'};
		string audioName= m_target.GetComponent<AudioSource>().clip.name;
		//Debug.Log (audioName);
		string step1 = audioName.Split (u) [1];
		//Debug.Log(step1);
		string noteName = (step1.Split (x) [0]);
		
		string[] notes = null;
		if (noteName.Contains ("+")) {
			notes= noteName.Split(p);
		} else if (noteName.Contains ("-")) {
			notes=noteName.Split (m);	
		}
		
		//		string[] combinedNotes= noteName.Split (p);
		//		Debug.Log (notes);
		Debug.Log (midiNum [noteName]);
		return midiNum[noteName];
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
		calcKey ();
			rigidbody2D.AddForce(-rigidbody2D.velocity.normalized * m_dragspeed);
			string s = new string (midiStr [calcKey ()] [0], 1);
//			Debug.Log ("Print Me!"+ midiStr[calcKey()][0]);
			bool upKey = Input.GetKey (s.ToLower());
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
		if (m_target==null){
			findNewTarget();
		}
		EnemyAI closestEnemy = m_target.GetComponent<EnemyAI> ();
			if (!closestEnemy.isPlayingSound) {
				StartCoroutine ( closestEnemy.playSound());
			}
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
