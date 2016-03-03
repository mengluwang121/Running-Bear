using UnityEngine;
using System.Collections;

public class KinectFinish : MonoBehaviour {
	KinectManager manager;
	uint UserId ;
	Transform m_player;
	Vector3 headpos;
	Vector3 lefthand;
	Vector3 righthand;

	
	public  int lflag=0;
	public  int rflag=0;
	//public MonoBehaviour GestureListener;
	// Use this for initialization
	void Start () {
		manager =GameObject.FindGameObjectWithTag("MainCamera").GetComponent<KinectManager>();
	}
	
	// Update is called once per frame
	void Update () {
		UserId = manager.GetPlayer1ID();
		lefthand = manager.GetJointPosition (UserId, (int)KinectWrapper.SkeletonJoint.LEFT_HAND);
		righthand = manager.GetJointPosition (UserId, (int)KinectWrapper.SkeletonJoint.RIGHT_HAND);
		headpos  = manager.GetJointPosition (UserId, (int)KinectWrapper.SkeletonJoint.HEAD);
		//Debug.Log (lefthand.x - righthand.x);
		if (lefthand.y>headpos.y&&righthand.y>headpos.y && Mathf.Abs(lefthand.x-righthand.x)<0.15f) {
			Application .LoadLevel(0);
		}
	}
}
