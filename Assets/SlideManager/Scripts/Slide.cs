using UnityEngine;
using System.Collections;
using System.IO;
using System;

public class Slide {
  private readonly GameObject prefab = Resources.Load("Slide") as GameObject;
  private GameObject slide;

  public Slide(string path) {
    slide = MonoBehaviour.Instantiate(prefab, Vector3.zero, Quaternion.identity) as GameObject;
    slide.GetComponent<GUITexture>().texture = LoadTexture(path);
    slide.GetComponent<GUITexture>().pixelInset = GetRect(slide.GetComponent<GUITexture>().texture);
    slide.transform.localScale = Vector3.zero;
  }

  public float Distance {
    get { return Math.Abs(this.slide.transform.position.x); }
  }

  public void Move(Vector3 position) {
    this.slide.transform.position = position;
  }

  private Rect GetRect(Texture texture) {
    Rect rect = new Rect(0, 0, 0, 0);
    float rateWidth = (float)Screen.width / texture.width;
    float rateHeight = (float)Screen.height / texture.height;
    float rate = rateWidth < rateHeight ? rateWidth : rateHeight;
    rect.width = texture.width * rate;
    rect.height = texture.height * rate;
    rect.x = (Screen.width - rect.width) / 2;
    rect.y = (Screen.height - rect.height) / 2;
    return rect;
  }

  private byte[] LoadBytes(string path) {
    FileStream fs = new FileStream(path, FileMode.Open);
    BinaryReader bin = new BinaryReader(fs);
    byte[] result = bin.ReadBytes((int)bin.BaseStream.Length);
    bin.Close();
    return result;
  }

  private Texture2D LoadTexture(string path) {
    Texture2D texture = new Texture2D(0, 0);
    texture.LoadImage(LoadBytes(path));
    return texture;
  }
}

