using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class enemy : MonoBehaviour
{
  public GameObject deathEffect;
  public Text scoreText;

  public static int score = 0;
  public static int EnemiesAlive = 0;
  public float health = 4f;
  public int pointValue = 100;

  void Start ()
  {
    EnemiesAlive++;
  }

  void OnCollisionEnter2D (Collision2D colInfo)
  {
    if (colInfo.relativeVelocity.magnitude > health) {
      Die();
    }

  }

  void Die()
  {
    Instantiate(deathEffect, transform.position, Quaternion.identity);

    EnemiesAlive --;
    if (EnemiesAlive <= 0)
      Debug.Log("Level Won!");

    Destroy(gameObject);

    score = score + pointValue;
    scoreText.text = "Score: " + (score).ToString("");
  }

}
