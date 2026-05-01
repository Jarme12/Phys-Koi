using UnityEngine;

public class CameraController : MonoBehaviour
{
   public Transform objetive;
   public float CameraSpeed = 0.025f;
   public Vector3 desplacement;

   private void LateUpdate()
    {
        Vector3 DesiredPosition = objetive.position + desplacement;

        Vector3 SmoothedPosition = Vector3.Lerp(transform.position, DesiredPosition, CameraSpeed);
        
        transform.position = SmoothedPosition;
    }


}
