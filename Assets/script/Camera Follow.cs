using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target; // Gracz jako cel kamery
    public float smoothSpeed = 0.125f; // Wspó³czynnik p³ynnoœci œledzenia

    void LateUpdate()
    {
        if (target != null)
        {
            Vector3 desiredPosition = target.position + new Vector3(0, 10, -10); // Ustawienie po³o¿enia kamery z góry
            Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
            transform.position = smoothedPosition;

            transform.LookAt(target.position); // Skieruj kamerê w stronê gracza
        }
    }
}
