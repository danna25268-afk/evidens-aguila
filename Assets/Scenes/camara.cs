using UnityEngine;

public class camara : MonoBehaviour
{
    [Header("Objetivo a Seguir")]
    [SerializeField] private Transform objetivo; // Asigna aquí el GameObject de tu Águila

    [Header("Configuración de Seguimiento")]
    [SerializeField] private float suavizado = 5f; // Velocidad de movimiento de la cámara
    [SerializeField] private Vector3 desfase = new Vector3(0f, 0f, -10f); // Mantiene Z en -10 para vista 2D

    void LateUpdate()
    {
        if (objetivo != null)
        {
            // Calcula la posición destino
            Vector3 posicionDeseada = objetivo.position + desfase;

            // Movimiento fluido hacia el águila
            Vector3 posicionSuave = Vector3.Lerp(transform.position, posicionDeseada, suavizado * Time.deltaTime);

            // Aplica la nueva posición a la cámara
            transform.position = posicionSuave;
        }
    }
}