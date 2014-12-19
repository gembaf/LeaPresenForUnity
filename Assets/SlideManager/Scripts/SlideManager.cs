using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SlideManager {
  private List<SlideList> slideManager = new List<SlideList>();
  private int currentIndex;

  public SlideManager() {
    slideManager.Add(new SlideList("./Contents", new Vector3(0, 0, 0)));
    currentIndex = 0;
  }

  public void SetMainPosition() {
    CurrentSlideList().SetMainPosition();
  }

  public void Next() {
    CurrentSlideList().Next();
  }

  public void Prev() {
    CurrentSlideList().Prev();
  }

  private SlideList CurrentSlideList() {
    return slideManager[currentIndex];
  }
}

