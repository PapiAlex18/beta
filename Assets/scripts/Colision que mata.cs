using UnityEngine;

public class CollisionTeleporter : MonoBehaviour
{
    // El objeto al que queremos teletransportarnos
    [SerializeField] private Transform destinationObject;
    
    // Tag del objeto que puede activar el teletransporte (por defecto "Player")
    [SerializeField] private string playerTag = "Player";
    
    // Offset opcional para ajustar la posición final
    [SerializeField] private Vector3 offsetPosition = Vector3.zero;

    private void OnCollisionEnter(Collision collision)
    {
        // Verificar si el objeto que colisionó tiene el tag correcto
        if (collision.gameObject.CompareTag(playerTag))
        {
            TeleportObject(collision.transform);
        }
    }

    // Versión alternativa usando triggers si prefieres usar triggers en lugar de colisiones
    private void OnTriggerEnter(Collider other)
    {
        // Verificar si el objeto que entró tiene el tag correcto
        if (other.CompareTag(playerTag))
        {
            TeleportObject(other.transform);
        }
    }

    private void TeleportObject(Transform objectToTeleport)
    {
        if (destinationObject != null)
        {
            // Teletransportar el objeto a la posición del destino + el offset
            objectToTeleport.position = destinationObject.position + offsetPosition;
            Debug.Log($"¡{objectToTeleport.name} ha sido teletransportado!");
        }
        else
        {
            Debug.LogWarning("No se puede teletransportar: falta el objeto destino");
        }
    }
}