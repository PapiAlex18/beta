using UnityEngine;

public class CombinacionPuerta : MonoBehaviour
{
    public GameObject puerta; // La puerta que se desbloqueará
    public GameObject[] palancas; // Las palancas que forman la combinación
    private bool[] estadoPalancas; // El estado de las palancas (activadas o desactivadas)
    private int[] combinacionCorrecta; // El orden correcto de activación de las palancas
    private int indiceCombinacion; // Para controlar qué palanca estamos activando

    private void Start()
    {
        // Inicializar el estado de las palancas
        estadoPalancas = new bool[palancas.Length];
        for (int i = 0; i < estadoPalancas.Length; i++)
        {
            estadoPalancas[i] = false; // Al principio todas las palancas están desactivadas
        }

        // Definir la combinación correcta de palancas (por ejemplo, [0, 2, 1] significa palanca 0, luego 2, luego 1)
        combinacionCorrecta = new int[] { 0, 2, 1 }; // Aquí define el orden correcto de las palancas
        indiceCombinacion = 0; // Comienza con el primer valor de la combinación
    }

    // Este método se llama cuando una palanca es activada
    public void ActivarPalanca(int index)
    {
        if (index < 0 || index >= palancas.Length)
            return;

        // Verificar si la palanca activada corresponde al siguiente paso en la combinación
        if (index == combinacionCorrecta[indiceCombinacion])
        {
            estadoPalancas[index] = true;
            indiceCombinacion++;

            // Si hemos activado todas las palancas en el orden correcto, abrimos la puerta
            if (indiceCombinacion == combinacionCorrecta.Length)
            {
                AbrirPuerta();
            }
        }
        else
        {
            // Si la palanca activada no corresponde al siguiente paso, reiniciamos la combinación
            ReiniciarCombinacion();
        }
    }

    private void AbrirPuerta()
    {
        // Aquí deberías agregar la lógica para abrir la puerta, como animarla o cambiar su estado
        puerta.GetComponent<Animator>().SetTrigger("Abrir"); // Suponiendo que tienes un Animator en la puerta
        Debug.Log("¡Puerta desbloqueada!");
    }

    private void ReiniciarCombinacion()
    {
        // Reiniciar el estado de las palancas y la combinación
        estadoPalancas = new bool[palancas.Length];
        indiceCombinacion = 0;
        Debug.Log("Combinación incorrecta. Reiniciando...");
    }
}
