using UnityEngine;

public class MovimientoAguila : MonoBehaviour
{
    public float velocidad = 5f;
    private Rigidbody2D rb;
    private SpriteRenderer spriteRenderer;
    private Vector2 direccion;

    void Start()
    {
        // Conseguimos los componentes necesarios al iniciar
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        // Detectamos las teclas W, A, S, D
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");

        direccion = new Vector2(horizontal, vertical).normalized;

        // --- CÓDIGO PARA VOLTEAR EL ÁGUILA ---
        // Si presionas la A (horizontal es menor a 0), camina a la izquierda
        if (horizontal < 0)
        {
            spriteRenderer.flipX = true; // Activa el volteado horizontal
        }
        // Si presionas la D (horizontal es mayor a 0), camina a la derecha
        else if (horizontal > 0)
        {
            spriteRenderer.flipX = false; // Desactiva el volteado (mira al frente/derecha original)
        }
    }

    void FixedUpdate()
    {
        // Movemos al personaje respetando los choques físicos
        rb.MovePosition(rb.position + direccion * velocidad * Time.fixedDeltaTime);
    }
}