using UnityEngine;
using System.Collections;
using System;

public class SimpleGestureListener : MonoBehaviour, KinectGestures.GestureListenerInterface
{
	 public  int lflag=0;
	 public  int rflag=0;
	public int jflag=0;
	// GUI Text to display the gesture messages.
	public GUIText GestureInfo;
	
	// private bool to track if progress message has been displayed
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
		if(GestureInfo != null)
		{
			GestureInfo.guiText.text = "SwipeLeft, SwipeRight, Jump, Push or Pull.";
		}
	}
	
	public void UserLost(uint userId, int userIndex)
	{
		if(GestureInfo != null)
		{
			GestureInfo.guiText.text = string.Empty;
		}
	}

	public void GestureInProgress(uint userId, int userIndex, KinectWrapper.Gestures gesture, 
		float progress, KinectWrapper.SkeletonJoint joint, Vector3 screenPos)
	{
		//GestureInfo.guiText.text = string.Format("{0} Progress: {1:F1}%", gesture, (progress * 100));
		if(gesture == KinectWrapper.Gestures.Click && progress > 0.3f)
		{
			string sGestureText = string.Format ("{0} {1:F1}% complete", gesture, progress * 100);
			if(GestureInfo != null)
				GestureInfo.guiText.text = sGestureText;
			
			progressDisplayed = true;
		}		
		else if((gesture == KinectWrapper.Gestures.ZoomOut || gesture == KinectWrapper.Gestures.ZoomIn) && progress > 0.5f)
		{
			string sGestureText = string.Format ("{0} detected, zoom={1:F1}%", gesture, screenPos.z * 100);
			if(GestureInfo != null)
				GestureInfo.guiText.text = sGestureText;
			
			progressDisplayed = true;
		}
		else if(gesture == KinectWrapper.Gestures.Wheel && progress > 0.5f)
		{
			string sGestureText = string.Format ("{0} detected, angle={1:F1} deg", gesture, screenPos.z);
			if(GestureInfo != null)
				GestureInfo.guiText.text = sGestureText;
			
			progressDisplayed = true;
		}
	}

	public bool GestureCompleted (uint userId, int userIndex, KinectWrapper.Gestures gesture, 
		KinectWrapper.SkeletonJoint joint, Vector3 screenPos)
	{
		string sGestureText = gesture + " detected";
		if(gesture == KinectWrapper.Gestures.Click)
			sGestureText += string.Format(" at ({0:F1}, {1:F1})", screenPos.x, screenPos.y);

		if (gesture == KinectWrapper.Gestures.SwipeLeft) {
			lflag=1;
		Vector3 movement2 = new Vector3(0.0f, 0.0f, 10.0f);
		CharacterController controller2 =GameObject.FindGameObjectWithTag("Player").GetComponent<CharacterController>();
		controller2.Move(movement2);
				}

		if (gesture == KinectWrapper.Gestures.SwipeRight) {
			rflag=1;
			Vector3 movement2 = new Vector3(0.0f, 0.0f, -10.0f);
			CharacterController controller2 =GameObject.FindGameObjectWithTag("Player").GetComponent<CharacterController>();
			controller2.Move(movement2);
		}

		if (gesture == KinectWrapper.Gestures.Jump||gesture == KinectWrapper.Gestures.Squat) {
			jflag=1;
		}

		if(GestureInfo != null)
			GestureInfo.guiText.text = sGestureText;
		
		progressDisplayed = false;
		
		return true;
	}

	public bool GestureCancelled (uint userId, int userIndex, KinectWrapper.Gestures gesture, 
		KinectWrapper.SkeletonJoint joint)
	{
		if(progressDisplayed)
		{
			// clear the progress info
			if(GestureInfo != null)
				GestureInfo.guiText.text = String.Empty;
			
			progressDisplayed = false;
		}
		
		return true;
	}
	
}
