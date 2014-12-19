using UnityEngine;
using System.Collections;
using Leap;

public class MoveSlides : MonoBehaviour {
  private const float RATE = 0.0005f;

  void Update () {
    Frame frame = App.LeapController.Frame();
    HandList hands = frame.Hands;
    Hand firstHand = hands[0];
    Vector position = firstHand.PalmVelocity;
    transform.Translate(position.x * RATE, 0, 0);
  }
}

