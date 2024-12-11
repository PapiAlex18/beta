using UnityEngine;
using UnityEngine.SceneManagement;

public class PortalToNextScene : MonoBehaviour
{
    // Nombre de la siguiente escena a cargar
    public string nextSceneName;

    private void OnTriggerEnter(Collider other)
    {
        // Verificar si el objeto que entra es el jugador
        if (other.CompareTag("Player"))
        {
            // Cargar la siguiente escena
            SceneManager.LoadScene(nextSceneName);
        }
    }
}