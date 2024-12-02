using UnityEngine;

public class DebugWeaponDelivery : MonoBehaviour
{
    [Header("Referencias Obligatorias")]
    public GameObject weaponPrefab;      // Prefab del arma
    public Transform deliveryPoint;      // Punto de entrega
    public GameObject player;            // Jugador
    public Transform weaponHolderPoint;  // Punto donde se equipará el arma

    [Header("Configuración de Entrega")]
    public float deliveryRadius = 2f;    // Radio de detección

    private bool weaponDelivered = false;

    void Start()
    {
        // Validaciones iniciales
        if (weaponPrefab == null)
            Debug.LogError("¡FALTA: No has asignado el prefab del arma!");
        
        if (deliveryPoint == null)
            Debug.LogError("¡FALTA: No has asignado el punto de entrega!");
        
        if (player == null)
            Debug.LogError("¡FALTA: No has asignado el jugador!");
        
        if (weaponHolderPoint == null)
            Debug.LogError("¡FALTA: No has asignado el punto de agarre del arma!");
    }

    void Update()
    {
        // Si ya se entregó el arma, no hacer nada
        if (weaponDelivered) return;

        // Verificar distancia
        float distancia = Vector3.Distance(player.transform.position, deliveryPoint.position);
        
        // Depuración de distancia
        Debug.Log($"Distancia al punto: {distancia}. Radio: {deliveryRadius}");

        // Entregar si está cerca
        if (distancia <= deliveryRadius)
        {
            EntregarArma();
        }
    }

    void EntregarArma()
    {
        if (weaponPrefab == null || weaponHolderPoint == null)
        {
            Debug.LogError("No se puede entregar: referencias faltantes");
            return;
        }

        // Instanciar el arma
        GameObject armaEntregada = Instantiate(
            weaponPrefab, 
            weaponHolderPoint.position, 
            weaponHolderPoint.rotation, 
            weaponHolderPoint
        );

        // Activar el arma
        armaEntregada.SetActive(true);

        Debug.Log("¡ARMA ENTREGADA EXITOSAMENTE!");

        weaponDelivered = true;
    }

    // Mostrar radio de detección en el editor
    void OnDrawGizmos()
    {
        if (deliveryPoint != null)
        {
            Gizmos.color = Color.yellow;
            Gizmos.DrawWireSphere(deliveryPoint.position, deliveryRadius);
        }
    }
}