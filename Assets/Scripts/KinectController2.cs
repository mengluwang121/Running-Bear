using UnityEngine;
using System.Collections;

public class KinectController2 : MonoBehaviour {
	KinectManager manager;
	uint UserId ;
	Transform m_player;
	Vector3 headpos;
	Vector3 spinepos;

	public  int lflag=0;
	public  int rflag=0;

	// Use this for initialization
	void Start () {
		manager =GameObject.FindGameObjectWithTag("MainCamera").GetComponent<KinectManager>();
		m_player=GameObject.FindGameObjectWithTag("Player").transform;

	}
	
	// Update is called once per frame
	void Update () {
		UserId = manager.GetPlayer1ID();
		spinepos = manager.GetJointPosition (UserId, (int)KinectWrapper.SkeletonJoint.SPINE);
		headpos  = manager.GetJointPosition (UserId, (int)KinectWrapper.SkeletonJoint.HEAD);

		if (headpos.x * 100 - spinepos.x * 100 <- 10.0f) {

			lflag=1;
			Vector3 movement2 = new Vector3(0.0f, 0.0f, 0.5f);
			CharacterController controller2 =GameObject.FindGameObjectWithTag("Player").GetComponent<CharacterController>();
			controller2.Move(movement2);
		}

		if (headpos.x * 100 - spinepos.x * 100 > 10.0f) {

			rflag=1;
			Vector3 movement3 = new Vector3(0.0f, 0.0f, -0.5f);
			CharacterController controller3 =GameObject.FindGameObjectWithTag("Player").GetComponent<CharacterController>();
			controller3.Move(movement3);
		}

	}
}
