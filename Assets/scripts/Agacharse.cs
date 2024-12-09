using UnityEngine;

public class MovimientoYAgachado : MonoBehaviour
{
    public float alturaAgachado = 0.5f;  // La altura a la que el personaje se agacha
    public float velocidadCambio = 5f;   // Velocidad a la que el personaje se agacha y se levanta
    public Transform camara;             // Referencia a la cámara para ajustar su altura
    public CapsuleCollider colision;     // El collider del personaje para ajustarlo al agacharse

    private float alturaOriginal;        // Altura original del personaje
    private Vector3 posicionOriginalCamara; // Posición original de la cámara

    private bool estaAgachado = false;   // Determina si el personaje está agachado o no

    void Start()
    {
        // Guardamos la altura original y la posición de la cámara al principio
        alturaOriginal = transform.localScale.y;
        posicionOriginalCamara = camara.localPosition;
    }

    void Update()
    {
        // Comprobamos si se ha presionado la tecla para agacharse
        if (Input.GetKeyDown(KeyCode.C)) // Puedes cambiar la tecla a cualquier otra que prefieras
        {
            // Cambiamos el estado de agachado
            estaAgachado = true;
        }

        if (Input.GetKeyUp(KeyCode.C))
        {
            estaAgachado = false;
        }
        // Si el personaje está agachado
        if (estaAgachado)
        {
            // Reducir la escala del personaje y del collider
            transform.localScale = Vector3.Lerp(transform.localScale, new Vector3(1f, alturaAgachado, 1f), velocidadCambio * Time.deltaTime);
            colision.height = Mathf.Lerp(colision.height, alturaAgachado, velocidadCambio * Time.deltaTime);
            colision.center = new Vector3(colision.center.x, alturaAgachado / 2f, colision.center.z);

            // Cambiar la posición de la cámara
            camara.localPosition = Vector3.Lerp(camara.localPosition, new Vector3(camara.localPosition.x, posicionOriginalCamara.y - (alturaOriginal - alturaAgachado) / 2f, camara.localPosition.z), velocidadCambio * Time.deltaTime);
        }
        else
        {
            // Si no está agachado, volvemos a la posición original
            transform.localScale = Vector3.Lerp(transform.localScale, new Vector3(1f, alturaOriginal, 1f), velocidadCambio * Time.deltaTime);
            colision.height = Mathf.Lerp(colision.height, alturaOriginal, velocidadCambio * Time.deltaTime);
            colision.center = new Vector3(colision.center.x, alturaOriginal / 2f, colision.center.z);

            // Volver a la posición original de la cámara
            camara.localPosition = Vector3.Lerp(camara.localPosition, posicionOriginalCamara, velocidadCambio * Time.deltaTime);
        }
    }
}
