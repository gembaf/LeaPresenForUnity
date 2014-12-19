using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.IO;

public class SlideList {
  private const float offset = 1.5f;

  private List<Slide> slideList = new List<Slide>();
  private int currentIndex;

  public SlideList(string path) {
    string[] files = Directory.GetFiles(path);

    //  Contents/.keepを無視する
    for ( int k = 1; k < files.Length; k++ ) {
      Slide slide = new Slide(files[k]);
      slideList.Add(slide);
      slide.Move(Vector3.right * (k-1) * offset);
    }
    currentIndex = 0;
  }

  public void SetMainPosition() {
    float min = float.MaxValue;
    for ( int k = 0; k < slideList.Count; k++ ) {
      float distance = slideList[k].Distance;
      if ( min > distance ) { min = distance; currentIndex = k; }
    }
    SetSlide();
  }

  public void SetSlide() {
    float pos = -currentIndex * offset;
    for ( int k = 0; k < slideList.Count; k++ ) {
      slideList[k].Move(Vector3.right * pos);
      pos += offset;
    }
  }

  public void Next() {
    currentIndex++;
    SetSlide();
  }

  public void Prev() {
    currentIndex--;
    SetSlide();
  }

  private Slide CurrentSlide() {
    return slideList[currentIndex];
  }
}

