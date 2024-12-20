using UnityEngine;

[System.Serializable]
public class Palanc {
    public AN_Button palanca;
    public bool estado;
}

public class CombinacionPuerta : MonoBehaviour
{
    public Palanc[] p;
    public AN_DoorScript puerta;
    private bool puertaAbierta = false;
    private bool abrirPuerta = false;
    
    private void Update() 
    {
        if (puertaAbierta) return;

        abrirPuerta = true;

        for (int i = 0; i < p.Length; i++)
        {
            if (p[i].palanca.isOpened != p[i].estado)
            {
                abrirPuerta = false;
            }
        }

        if (abrirPuerta)
        {
            puerta.Action();
            puertaAbierta = true;
        } 
    }
}
