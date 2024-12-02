using UnityEngine;

public class WeaponDamage : MonoBehaviour
{
    [Header("Configuración de Daño")]
    public float damage = 10f;           // Cantidad de daño por golpe
    public float attackRange = 2f;       // Alcance del ataque
    public LayerMask enemyLayer;         // Capa de los enemigos

    [Header("Efectos de Ataque")]
    public ParticleSystem hitEffect;     // Efecto de impacto
    public AudioClip hitSound;           // Sonido de impacto

    private AudioSource audioSource;

    void Start()
    {
        // Configurar audio si hay sonido
        if (hitSound != null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
        }
    }

    void Update()
    {
        // Detectar click del ratón
        if (Input.GetMouseButtonDown(0)) // 0 es el botón izquierdo
        {
            Attack();
        }
    }

    void Attack()
    {
        // Crear un rayo desde la cámara
        Ray ray = Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
        RaycastHit hit;

        // Detectar si el rayo golpea a un enemigo
        if (Physics.Raycast(ray, out hit, attackRange, enemyLayer))
        {
            // Obtener componente de vida del enemigo
            EnemyHealth enemyHealth = hit.collider.GetComponent<EnemyHealth>();

            if (enemyHealth != null)
            {
                // Aplicar daño
                enemyHealth.TakeDamage(damage);

                // Efectos de impacto
                if (hitEffect != null)
                {
                    Instantiate(hitEffect, hit.point, Quaternion.LookRotation(hit.normal));
                }

                // Reproducir sonido
                if (hitSound != null && audioSource != null)
                {
                    audioSource.PlayOneShot(hitSound);
                }

                Debug.Log($"Enemigo golpeado. Daño: {damage}");
            }
        }
    }

    // Mostrar rango de ataque en el editor
    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawRay(Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0)).origin, 
                       Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0)).direction * attackRange);
    }
}

// Script para la vida del enemigo
public class EnemyHealth : MonoBehaviour
{
    public float maxHealth = 100f;
    private float currentHealth;

    void Start()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(float damageAmount)
    {
        currentHealth -= damageAmount;

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        Debug.Log("Enemigo eliminado");
        Destroy(gameObject);
    }
}