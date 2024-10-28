using UnityEngine;

public class Chase : MonoBehaviour
{
    public Transform target; // El objeto que será perseguido
    public float speed = 5f; // Velocidad de persecución

    void Update()
    {
        if (target != null)
        {
            // Calcular la dirección hacia el objetivo
            Vector3 direction = target.position - transform.position;
            direction.Normalize(); // Normalizar para obtener solo la dirección

            // Mover el objeto hacia el objetivo
            transform.position += direction * speed * Time.deltaTime;
        }
    }
}
