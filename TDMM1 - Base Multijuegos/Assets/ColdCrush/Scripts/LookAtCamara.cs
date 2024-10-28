using UnityEngine;

public class LookAtCamera : MonoBehaviour
{
    void Update()
    {
        // Obtener la posición de la cámara
        Vector3 cameraPosition = Camera.main.transform.position;

        // Calcular la dirección hacia la cámara
        Vector3 direction = cameraPosition - transform.position;

        // Obtener la rotación solo en el eje Y
        Quaternion rotation = Quaternion.LookRotation(direction);
        transform.rotation = Quaternion.Euler(0, rotation.eulerAngles.y, 0);
    }
}
