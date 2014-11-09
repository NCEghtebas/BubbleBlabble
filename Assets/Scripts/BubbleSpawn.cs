using UnityEngine;
using System.Collections;

public class BubbleSpawn : MonoBehaviour {
	public GameObject bubble;

	// Use this for initialization
	void Start () {
		for (int i = -7; i<7; i+=1) {
			for(int j = -7; j<7; j+=1){
						Vector3 position = new Vector3(3*(i+Random.value), 3*(j+Random.value), 4);
						Quaternion rotation = new Quaternion(Random.value, Random.value, 0, 0);
						

						Instantiate (bubble, position, rotation);
			}
				}
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
