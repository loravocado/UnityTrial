
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
  public Transform target1;
  public float smoothSpeed = 0.125f;
  public Vector3 offset;


  void FixedUpdate ()
  {
    Vector3 desiredPosition = target1.position + offset;
    Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
    transform.position = smoothedPosition;
  }
}
