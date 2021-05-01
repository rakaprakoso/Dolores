using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private Transform target;
    [SerializeField] [Range(0.01f,1f)]
     private float Smoothspeed = 0.125f;
    [SerializeField] private Vector3 offset;

    private Vector3 velocity = Vector3.zero;

    private void LateUpdate() {
       Vector3 desiredPos= target.position + offset;
        transform.position = Vector3.SmoothDamp(transform.position, desiredPos,ref velocity,Smoothspeed);
   }
}
