using UnityEngine;
using System.Collections;

public class KinectController : MonoBehaviour {
	KinectManager manager;
	uint UserId ;
	Vector3 startpos;
	Transform m_player;
	float oldpos_z;
	// Use this for initialization
	void Start () {
		manager =GameObject.FindGameObjectWithTag("MainCamera").GetComponent<KinectManager>();
		m_player=GameObject.FindGameObjectWithTag("Player").transform;
		oldpos_z = m_player.position.z;
	}
	
	// Update is called once per frame
	void Update () {
		UserId = manager.GetPlayer1ID();
		startpos = manager.GetJointPosition(UserId,(int)KinectWrapper.SkeletonJoint.SPINE);

		//CharacterController controller2 =GameObject.FindGameObjectWithTag("Player").GetComponent<CharacterController>();
		Vector3 newpos = new Vector3(m_player.position.x, m_player.position .y , oldpos_z - startpos.x*100);
		m_player.position = newpos;

	}
}
