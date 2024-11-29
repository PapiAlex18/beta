using UnityEngine;

public class RotateObject : MonoBehaviour
{
    [Header("Configuración de Rotación")]
    [Tooltip("Velocidad de rotación en grados por segundo")]
    public Vector3 rotationSpeed = new Vector3(0, 90, 0); // Por defecto rota 90 grados/seg en el eje Y
    
    [Tooltip("Activar/Desactivar rotación")]
    public bool isRotating = true;

    void Update()
    {
        if (isRotating)
        {
            // Rota el objeto usando la velocidad especificada * el tiempo entre frames
            transform.Rotate(rotationSpeed * Time.deltaTime);
        }
    }
}
