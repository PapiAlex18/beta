using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    [Header("Configuración de Movimiento")]
    public float moveSpeed = 5f;           // Velocidad de movimiento de la plataforma
    public float maxMoveDistance = 10f;    // Distancia máxima de movimiento
    public bool moveHorizontal = true;     // ¿Se mueve horizontalmente o verticalmente?

    [Header("Límites de Movimiento")]
    public Vector3 startPosition;          // Posición inicial de la plataforma
    private Vector3 movementDirection;     // Dirección de movimiento
    private float movementProgress = 0f;   // Progreso del movimiento
    private bool canMove = true;           // Flag para controlar el movimiento

    private bool isPlayerOnPlatform = false; // Flag para saber si el jugador está en la plataforma

    void Start()
    {
        startPosition = transform.position;
        
        // Definir dirección de movimiento
        movementDirection = moveHorizontal 
            ? Vector3.right 
            : Vector3.up;
    }

    void Update()
    {
        // Solo mover la plataforma si el jugador está encima y no ha llegado al límite
        if (isPlayerOnPlatform && canMove)
        {
            // Calcular movimiento
            movementProgress += moveSpeed * Time.deltaTime;
            
            // Detener cuando alcance la distancia máxima
            if (movementProgress >= maxMoveDistance)
            {
                canMove = false;
            }

            // Actualizar posición de la plataforma
            Vector3 newPosition = startPosition + (movementDirection * movementProgress);
            transform.position = newPosition;
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        // Verificar si el jugador está en la plataforma
        if (collision.gameObject.CompareTag("Player"))
        {
            isPlayerOnPlatform = true;
            // Hacer que el jugador sea hijo de la plataforma para que se mueva con ella
            collision.gameObject.transform.SetParent(transform);
        }
    }

    void OnCollisionExit(Collision collision)
    {
        // Restaurar cuando el jugador salga de la plataforma
        if (collision.gameObject.CompareTag("Player"))
        {
            isPlayerOnPlatform = false;
            // Quitar la referencia del padre
            collision.gameObject.transform.SetParent(null);
        }
    }
}