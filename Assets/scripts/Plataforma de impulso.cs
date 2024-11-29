using UnityEngine;

public class PlataformaImpulsora : MonoBehaviour
{
    // La fuerza que se aplicará para impulsar hacia arriba
    public float fuerzaDeImpulso = 10f;

    // Método que se llama cuando otro collider entra en contacto con esta plataforma
    private void OnCollisionEnter(Collision collision)
    {
        // Verifica si el objeto que colisiona es el jugador
        if (collision.gameObject.CompareTag("Player"))
        {
            // Obtiene el Rigidbody2D del jugador y aplica una fuerza hacia arriba
            Rigidbody rb = collision.gameObject.GetComponent<Rigidbody>();

            if (rb != null)
            {
                // Aplica una fuerza hacia arriba en el eje Y
                rb.AddForce(Vector3.up * fuerzaDeImpulso, ForceMode.Impulse);
            }
        }
    }
}
