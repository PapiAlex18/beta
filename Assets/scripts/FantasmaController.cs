using UnityEngine;

public class FantasmaController : MonoBehaviour
{
    public Transform playerTransform;
    public Transform[] fantasmaTransform;
    public float moveSpeed = 4f;

    private bool moverFantasma = false;
    private float tiempoDeGracia = 0;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        tiempoDeGracia = tiempoDeGracia + Time.deltaTime;

        if(moverFantasma ) 
        {
            MoverFantasma();
        }        
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player") 
        {
            moverFantasma = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if(other.gameObject.tag == "Player") 
        {
            //tiempoDeGracia = 0;
             moverFantasma = false;
        }
    }

    void MoverFantasma() 
    {
        
        float distanceToPlayer = Vector3.Distance(transform.position, playerTransform.position);

        for(int fantasma=0; fantasma < fantasmaTransform.Length; fantasma++){
            Vector3 directionToPlayer = (playerTransform.position - fantasmaTransform[fantasma].position).normalized;
            fantasmaTransform[fantasma].position += directionToPlayer * moveSpeed * Time.deltaTime;
            fantasmaTransform[fantasma].LookAt(playerTransform);
        }
        
        
    }
}
