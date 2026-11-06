using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public Transform player; // Arrastra a tu personaje aquí desde el Inspector
    public Vector3 offset = new Vector3(0f, 2f, -5f); // Distancia entre la cámara y el jugador

    void LateUpdate()
    {
        if (player != null)
        {
            transform.position = player.position + offset;
        }
    }
}
