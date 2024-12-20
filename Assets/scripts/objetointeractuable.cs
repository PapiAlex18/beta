using UnityEngine;

public class ObjetoInteractuable : MonoBehaviour
{
    public string mensajeDeInteraccion = "Has interactuado con el objeto.";  // Mensaje a mostrar al interactuar
    public float distanciaDeInteraccion = 3f;  // Distancia a la que el jugador puede interactuar con el objeto

    private void Update()
    {
        // Comprobar si el jugador está cerca y presiona la tecla E
        if (Input.GetKeyDown(KeyCode.E))  // Puedes cambiar la tecla si lo deseas
        {
            RaycastHit hit;

            // Lanza un raycast desde la cámara hacia donde el jugador está mirando
            if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hit, distanciaDeInteraccion))
            {
                // Verifica si el objeto que el raycast tocó es este objeto
                if (hit.collider.gameObject == gameObject)
                {
                    Interactuar();  // Llama al método para interactuar con el objeto
                }
            }
        }
    }

    // Método de interacción que se llama cuando el jugador interactúa con el objeto
    public void Interactuar()
    {
        // Imprime un mensaje en la consola (puedes reemplazarlo por cualquier otra acción)
        Debug.Log(mensajeDeInteraccion);

        // Ejemplo de acción al interactuar: Eliminar el objeto
        // Destroy(gameObject);  // Descomenta esta línea si deseas destruir el objeto al interactuar

        // Aquí puedes agregar la lógica que desees, como agregar al inventario, activar una animación, etc.
    }
}
