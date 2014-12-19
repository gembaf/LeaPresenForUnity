using UnityEngine;
using System.Collections;
using Leap;
using System;

public class GestureListener : MonoBehaviour {
  private const float INTERVAL = 0.75f;
  private float gestureIntervalTimer = INTERVAL;
  private bool gesturedFlag = false;

  void Update () {
    if ( gesturedFlag && IsGestureInterval() ) { return; }
    gestureIntervalTimer = INTERVAL; gesturedFlag = false;

    Frame frame = App.LeapController.Frame();
    foreach ( Gesture gesture in frame.Gestures() ) {
      if ( gesturedFlag ) { break; }
      gesturedFlag = true;
      switch ( gesture.Type ) {
        case Gesture.GestureType.TYPE_SWIPE:
          SwipeAction(gesture);
          break;
      }
    }
  }

  private bool IsGestureInterval() {
    gestureIntervalTimer -= Time.deltaTime;
    return gestureIntervalTimer > 0;
  }

  private void SwipeAction(Gesture gesture) {
    SwipeGesture swipe = new SwipeGesture(gesture);
    if ( swipe.Direction.x > 0 ) {
      App.SlideManager.Prev();
    } else {
      App.SlideManager.Next();
    }
  }
}

