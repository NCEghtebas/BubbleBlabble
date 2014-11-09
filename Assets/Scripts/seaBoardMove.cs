using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class seaBoardMove : MonoBehaviour {

	public float m_speed =10;
	public float m_dragspeed =5;
	public GameObject m_target;

	private Dictionary<string,int> midiNum=new Dictionary<string,int>();

	// Use this for initialization
	void Start () {
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
	}

	//board 58-84
	//us 68-87
	//	07_Ab+C+Eb+Gx4_90bpm
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
		Debug.Log (notes);

		return midiNum[noteName];
	}

	void moveToTarget ()
	{
		rigidbody2D.AddForce(-rigidbody2D.velocity.normalized * m_dragspeed);
		float upKey = MidiJack.GetKey (calcKey ());
		if (upKey>.1){
			Vector2 dif = m_target.transform.position - transform.position;
			if ((dif).magnitude > 1) {
				rigidbody2D.AddForce (dif.normalized * m_speed * upKey *10);
			}
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
