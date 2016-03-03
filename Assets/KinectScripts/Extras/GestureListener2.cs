using UnityEngine;
using System.Collections;

public class GestureListener2 : MonoBehaviour, KinectGestures.GestureListenerInterface {

	private bool progressDisplayed;	
	
	public void UserDetected(uint userId, int userIndex)
	{
		// as an example - detect these user specific gestures
		KinectManager manager = KinectManager.Instance;
		manager.DetectGesture(userId,KinectWrapper.Gestures.Jump);
		manager.DetectGesture(userId,KinectWrapper.Gestures.Squat);
		manager.DetectGesture(userId,KinectWrapper.Gestures.Push);
		manager.DetectGesture(userId, KinectWrapper.Gestures.Pull);
		//		manager.DetectGesture(userId, KinectWrapper.Gestures.SwipeUp);
		//		manager.DetectGesture(userId, KinectWrapper.Gestures.SwipeDown);

	}
	
	public void UserLost(uint userId, int userIndex)
	{

	}
	
	public void GestureInProgress(uint userId, int userIndex, KinectWrapper.Gestures gesture, 
	                              float progress, KinectWrapper.SkeletonJoint joint, Vector3 screenPos)
	{
	
	}
	
	public bool GestureCompleted (uint userId, int userIndex, KinectWrapper.Gestures gesture, 
	                              KinectWrapper.SkeletonJoint joint, Vector3 screenPos)
	{

		
		if (gesture == KinectWrapper.Gestures.SwipeLeft) {
			Application.LoadLevel(1);
		}

		if (gesture == KinectWrapper.Gestures.SwipeRight) {
			Application.LoadLevel(1);
		}
		
		return true;
	}
	
	public bool GestureCancelled (uint userId, int userIndex, KinectWrapper.Gestures gesture, 
	                              KinectWrapper.SkeletonJoint joint)
	{
			progressDisplayed = false;
		
		return true;
	}

}
