using UnityEngine;

public class InteraccionJugador : MonoBehaviour
{
    public float distanciaDeInteraccion = 3f;  // Distancia a la que puede interactuar con objetos
    public LayerMask capaInteractuable;  // Capa para los objetos interactuables
    public KeyCode teclaDeInteraccion = KeyCode.E;  // Tecla para interactuar

    void Update()
    {
        // Detectamos si el jugador presiona la tecla de interacción
        if (Input.GetKeyDown(teclaDeInteraccion))
        {
            Interactuar();
        }
    }

    void Interactuar()
    {
        RaycastHit hit;
        // Raycast desde la cámara hacia donde está mirando el jugador
        if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hit, distanciaDeInteraccion, capaInteractuable))
        {
            // Si el objeto tiene el script de "ObjetoInteractuable"
            ObjetoInteractuable objetoInteractuable = hit.collider.GetComponent<ObjetoInteractuable>();
            if (objetoInteractuable != null)
            {
                objetoInteractuable.Interactuar();
            }
        }
    }
}
