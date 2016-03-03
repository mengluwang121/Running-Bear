using UnityEngine;
using System.Collections;

public class GoAhead : MonoBehaviour {

	private float MoveSpeed;
	public float MaxSpeed;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		//transform.Translate(Vector3.forward *  0.8f);
		if(Input.GetKey(KeyCode.K))
		{
			//transform.right * Time.deltaTime;
			//this.transform.Translate(Vector3.left);
		//	this.rigidbody.velocity = Vector3.forward ;
			transform.localPosition += new Vector3(0.0f, 0.0f, 0.5f );
		}
	
	}
}
