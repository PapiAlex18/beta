using UnityEngine;

public class Palanca : MonoBehaviour
{
    public bool estaActivada = false; // Estado de la palanca (activada/desactivada)

    public void Activar()
    {
        // Cambiar el estado de la palanca
        estaActivada = !estaActivada;
        
        // Aquí puedes añadir animaciones o efectos visuales
        if (estaActivada)
        {
            // Realizar alguna acción cuando la palanca se activa
            Debug.Log("Palanca Activada");
        }
        else
        {
            // Acción cuando la palanca se desactiva
            Debug.Log("Palanca Desactivada");
        }
    }

    // Puedes agregar efectos visuales, como cambiar la apariencia de la palanca cuando se active.
}
