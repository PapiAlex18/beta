using UnityEngine;

public class playercam : MonoBehaviour
{
    public float sensivilidadX = 2.0f;
    public float sensivilidadY = 2.0f;
    public Transform jugador;

    private float rotacionX = 0.0f;
    private float rotacionY = 0.0f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
    float mouseX = Input.GetAxisRaw("Mouse X") * sensivilidadX * Time.deltaTime;  
    float mouseY = Input.GetAxisRaw("Mouse Y") * sensivilidadY * Time.deltaTime; 

    rotacionX -= mouseY;
    rotacionY +=mouseX;
    rotacionX = Mathf.Clamp(rotacionX, -90.0f, 90.0f);
  
    transform.rotation = Quaternion.Euler(rotacionX, rotacionY, 0.0f);
    jugador.rotation = Quaternion.Euler(0.0f, rotacionY, 0.0f);
    }
}
