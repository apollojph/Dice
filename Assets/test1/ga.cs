using UnityEngine;
using System.Collections;

public class ga : MonoBehaviour {

	public GameObject s;
	int getpoint=0;
	int i=Random.Range(0,6);

	// Use this for initialization
	void Start () {
	
		//getpoint = i + 1;
	}
	
	// Update is called once per frame
	void Update () {
	
		for(int i=0;i<6;i++){
			//ArrayList [i] = i;
			getpoint = i + 1;
		}
		/*if (getpoint = 1) {
			s.transform.position += new Vector3 (0, 0, -5);
			Vector3 pos = transform.position;
		}
		if (getpoint = 2) {
			s.transform.position += new Vector3 (0, 0, -10);
			Vector3 pos = transform.position;
		}
		if (getpoint = 3) {
			s.transform.position += new Vector3 (0, 0, -15);
			Vector3 pos = transform.position;
		}
		if (getpoint = 4) {
			s.transform.position += new Vector3 (0, 0, -20);
			Vector3 pos = transform.position;
		}
		if (getpoint = 5) {
			s.transform.position += new Vector3 (0, 0, -25);
			Vector3 pos = transform.position;
		}
		if (getpoint = 6) {
			s.transform.position += new Vector3 (0, 0, -30);
			Vector3 pos = transform.position;
		}*/
		}
	
}
