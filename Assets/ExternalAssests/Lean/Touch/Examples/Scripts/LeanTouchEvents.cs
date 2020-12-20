using UnityEngine;
using System.Collections.Generic;
using UnityEngine.Events;

namespace Lean.Touch
{
	/// <summary>This component will hook into every LeanTouch event, and spam the console with the information.</summary>
	[HelpURL(LeanTouch.HelpUrlPrefix + "LeanTouchEvents")]
	[AddComponentMenu(LeanTouch.ComponentPathPrefix + "Touch Events")]
	public class LeanTouchEvents : MonoBehaviour
	{
		public float SwipeThreshold;
		public UnityEvent jump;
		
		protected virtual void OnEnable()
		{
			// Hook into the events we need
			LeanTouch.OnFingerDown   += HandleFingerDown;
			LeanTouch.OnFingerUpdate += HandleFingerUpdate;
			LeanTouch.OnFingerUp     += HandleFingerUp;
			LeanTouch.OnFingerTap    += HandleFingerTap;
			LeanTouch.OnFingerSwipe  += HandleFingerSwipe;
			LeanTouch.OnGesture      += HandleGesture;
		}

		protected virtual void OnDisable()
		{
			// Unhook the events
			LeanTouch.OnFingerDown   -= HandleFingerDown;
			LeanTouch.OnFingerUpdate -= HandleFingerUpdate;
			LeanTouch.OnFingerUp     -= HandleFingerUp;
			LeanTouch.OnFingerTap    -= HandleFingerTap;
			LeanTouch.OnFingerSwipe  -= HandleFingerSwipe;
			LeanTouch.OnGesture      -= HandleGesture;
		}

		public void HandleFingerDown(LeanFinger finger)
		{
		
		}

		public void HandleFingerUpdate(LeanFinger finger)
		{	
			if ((finger.ScreenPosition.y - finger.StartScreenPosition.y)> SwipeThreshold)
			{
				jump.Invoke();
			}
		}

		public void HandleFingerUp(LeanFinger finger)
		{
			//Debug.Log("Finger " + finger.Index + " finished touching the screen");
		}

		public void HandleFingerTap(LeanFinger finger)
		{
			//Debug.Log("Finger " + finger.Index + " tapped the screen");
		}

		public void HandleFingerSwipe(LeanFinger finger)
		{
				
		}

		public void HandleGesture(List<LeanFinger> fingers)
		{
		
		}
	}
}