using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target; // Gracz jako cel kamery
    public float smoothSpeed = 0.125f; // Wsp�czynnik p�ynno�ci �ledzenia

    void LateUpdate()
    {
        if (target != null)
        {
            Vector3 desiredPosition = target.position + new Vector3(0, 10, -10); // Ustawienie po�o�enia kamery z g�ry
            Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
            transform.position = smoothedPosition;

            transform.LookAt(target.position); // Skieruj kamer� w stron� gracza
        }
    }
}
