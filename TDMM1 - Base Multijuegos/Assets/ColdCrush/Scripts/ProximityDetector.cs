using UnityEngine;

public class ProximityDetector : MonoBehaviour
{
    public Transform target; // El objeto con el que verificamos la proximidad
    public float proximityDistance = 5f; // Distancia a la que se considera "cerca"
    public bool isClose = false; // Determina si está cerca

    void Update()
    {
        if (target != null)
        {
            float distance = Vector3.Distance(transform.position, target.position);

            // Cambiar el estado de isClose según la proximidad
            if (distance <= proximityDistance)
            {
                isClose = true;
            }
            else
            {
                isClose = false;
            }
        }
    }
}
