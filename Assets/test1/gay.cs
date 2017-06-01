using UnityEngine;
using System.Collections;

public class gay : MonoBehaviour {

	public GameObject s;
	public GameObject d;

	public int maxSpeed=7;
	public int minSpeed=1;
	float speed;
	public int Jumpspeed = 8;
	public int Gravity = 2;
	//private Vector3 MoveDirection = Vector3.zero;
	// Use this for initialization
	void Start () {
//		Time.deltaTime=1;
	}
	
	// Update is called once per frame
	void Update () {
		
		speed = Random.Range (minSpeed, maxSpeed);
		//s.GetComponent<Rigidbody>().AddTorque(Vector3(-50, -50 , -50)*1000, ForceMode.Impulse);
	}

	public void move(){
	
		//MoveDirection.y = Jumpspeed;
		//MoveDirection.y -= Gravity * Time.deltaTime
		//Time.deltaTime=0;
		d.gameObject.transform.Rotate (360*Time.deltaTime,360*Time.deltaTime,360*Time.deltaTime);
		d.gameObject.transform.position += new Vector3 (0, 3, 0)*speed;
		//d.gameObject.transform.Rotate (0,10*Time.deltaTime,5*Time.deltaTime);
		s.gameObject.transform.position += new Vector3 (0, 1, -8)*speed;
		Vector3 pos = transform.position;
		print (speed);

	}


}
