using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Ball : MonoBehaviour
{
  public UIManager UIManager;

  public Rigidbody2D rb;
  public Rigidbody2D hook;
  public GameObject nextBall;

  public float releaseTime = 0.15f;
  public float maxDragDistance = 2f;

  private bool spaceHeld = false;
  private float angle = 0;

  //private Vector3 
  
  private bool isPressed = false;
  void Update()
  {
    if (isPressed)
    {
      Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
      if (Vector3.Distance(mousePos, hook.position) > maxDragDistance)
        rb.position = hook.position + (mousePos - hook.position).normalized * maxDragDistance;
      else
        rb.position = mousePos;
    }
  }

  void OnMouseDown ()
  {
    isPressed = true;
    rb.isKinematic = true;
  }
  void OnMouseUp ()
  {
    isPressed = false;
    rb.isKinematic = false;
    //release function
    StartCoroutine(Release());
  } 

  /*void Update() {

    if (Input.GetKey("space")) {
      angle = angle + 0.2f;
    }

    if (Input.GetKeyUp(KeyCode.Space)) {
      print(angle);
    }

  }*/


  IEnumerator Release ()
  {
    UIManager.BallsUsed++;

    yield return new WaitForSeconds(releaseTime);
    GetComponent<SpringJoint2D>().enabled = false;
    this.enabled = false;

    yield return new WaitForSeconds(2f);
    if (nextBall != null && UIManager.EnemiesAlive != 0) {
      nextBall.SetActive(true);
    } else {
      yield return new WaitForSeconds(3f);
      if (UIManager.EnemiesAlive != 0) {
        UIManager.levelFail();
      }
    }

  }

}
