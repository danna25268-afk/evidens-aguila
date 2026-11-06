using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(SpriteRenderer))]
public class ControlAguila : MonoBehaviour
{
    [Header("Configuración de Movimiento")]
    [SerializeField] private float velocidad = 6f;

    [Header("Etiquetas de los Coleccionables (Tags)")]
    [SerializeField] private string tagGema = "Gema";
    [SerializeField] private string tagCereza = "Cherry";

    // Componentes internos
    private Rigidbody2D rb;
    private SpriteRenderer spriteRenderer;
    private Vector2 entradaMovimiento;

    // Puntaje acumulado
    public static int puntajeTotal = 0;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();

        // Evita que el águila caiga por gravedad o gire al chocar
        rb.gravityScale = 0f;
        rb.constraints = RigidbodyConstraints2D.FreezeRotation;
    }

    void Update()
    {
        // Detecta flechas y teclas W, A, S, D
        float movX = Input.GetAxisRaw("Horizontal");
        float movY = Input.GetAxisRaw("Vertical");

        entradaMovimiento = new Vector2(movX, movY).normalized;

        // Voltea el sprite a la izquierda o derecha según la dirección
        if (movX > 0)
        {
            spriteRenderer.flipX = true; // Mira a la derecha
        }
        else if (movX < 0)
        {
            spriteRenderer.flipX = false;  // Mira a la izquierda
        }
    }

    void FixedUpdate()
    {
        // Aplica el movimiento físico fluido
        rb.velocity = entradaMovimiento * velocidad;
    }

    // Detecta la colisión con gemas y cerezas
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Si toca una Gema -> SUMA 10 PUNTOS
        if (collision.CompareTag(tagGema))
        {
            SumarPuntos(10);
            Destroy(collision.gameObject);
        }
        // Si toca una Cereza -> RESTA 5 PUNTOS
        else if (collision.CompareTag(tagCereza))
        {
            RestarPuntos(5);
            Destroy(collision.gameObject);
        }
    }

    private void SumarPuntos(int cantidad)
    {
        puntajeTotal += cantidad;
        Debug.Log($"💎 ¡Gema obtenida! (+{cantidad} pts). Puntaje actual: {puntajeTotal}");

        if (GameManager.instance != null)
        {
            GameManager.instance.SumarPuntos(cantidad);
        }
    }

    private void RestarPuntos(int cantidad)
    {
        puntajeTotal -= cantidad;
        Debug.Log($"🍒 ¡Cereza tocada! (-{cantidad} pts). Puntaje actual: {puntajeTotal}");

        if (GameManager.instance != null)
        {
            GameManager.instance.RestarPuntos(cantidad);
        }
    }
}