using UnityEngine;

public class GameManager : MonoBehaviour
{
    // Permite acceder al GameManager desde CherryController sin errores
    public static GameManager instance;

    [Header("Puntaje del Juego")]
    public int puntajeTotal = 0;

    private void Awake()
    {
        // Configuración Singleton
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // Método para restar puntos cuando el águila toca la cereza
    public void RestarPuntos(int cantidad)
    {
        puntajeTotal -= cantidad;
        Debug.Log("Puntaje actual: " + puntajeTotal);
    }

    // Método opcional para sumar puntos si recoges gemas
    public void SumarPuntos(int cantidad)
    {
        puntajeTotal += cantidad;
        Debug.Log("Puntaje actual: " + puntajeTotal);
    }
}