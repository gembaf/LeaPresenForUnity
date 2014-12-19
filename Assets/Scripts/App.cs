using UnityEngine;
using System.Collections;
using Leap;

public class App : MonoBehaviour {
  public static SlideManager SlideManager;
  public static Controller LeapController;

  void Awake() {
    SlideManager = new SlideManager();
    LeapController = new Controller();
  }

  void Update() {
    if ( Input.GetKeyDown("right") ) {
      SlideManager.Next();
    } else if ( Input.GetKeyDown("left") ) {
      SlideManager.Prev();
    }
  }
}

