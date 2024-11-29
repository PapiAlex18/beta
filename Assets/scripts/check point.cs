using UnityEngine;


// Script para cada checkpoint individual
public class Checkpoint : MonoBehaviour
{
    private Vector3 checkpointPosition;

    private void Start() 
    {
        checkpointPosition = transform.position;
    }

    private void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Checkpoint")
        {
            checkpointPosition = col.gameObject.transform.position;
        }

        if (col.gameObject.tag == "LimiteAbajo")
        {
            transform.position = checkpointPosition;
        }
    }
}
