using UnityEngine;

public class GhostFollow : MonoBehaviour
{
    public Transform playerTransform;
    public float moveSpeed = 4f;
    public float detectionRadius = 5f;

    private bool isPlayerDetected = false;

    void Update()
    {
        // Verificar si el jugador está dentro del radio de detección
        float distanceToPlayer = Vector3.Distance(transform.position, playerTransform.position);

        if (distanceToPlayer <= detectionRadius)
        {
            // Activar el seguimiento cuando el jugador entra en el área
            isPlayerDetected = true;
        }

        // Si el jugador ha sido detectado, seguirlo directamente
        if (isPlayerDetected)
        {
            // Calcular dirección hacia el jugador
            Vector3 directionToPlayer = (playerTransform.position - transform.position).normalized;

            // Mover el fantasma directamente hacia el jugador
            transform.position += directionToPlayer * moveSpeed * Time.deltaTime;

            // Rotar para mirar al jugador
            transform.LookAt(playerTransform);
        }
    }

    // Método opcional para visualizar el radio de detección en el editor
    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, detectionRadius);
    }
}