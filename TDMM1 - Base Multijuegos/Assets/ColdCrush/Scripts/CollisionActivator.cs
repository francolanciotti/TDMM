using UnityEngine;
using System.Collections;

public class TriggerActivator : MonoBehaviour
{
    public GameObject objectToActivate; // El objeto dentro del Canvas que se activará

    // Este método se llama cuando algo entra en el Trigger
    void OnTriggerEnter(Collider other)
    {
        // Verificar si el objeto con el que entra en el trigger tiene el tag "Player"
        if (other.CompareTag("Player"))
        {
            ActivateObject(); // Activar el objeto
        }
    }

    // Método para activar el objeto
    void ActivateObject()
    {
        if (objectToActivate != null)
        {
            objectToActivate.SetActive(true); // Activar el objeto dentro del Canvas
            StartCoroutine(DeactivateObjectAfterDelay(2f)); // Iniciar la corutina para desactivarlo después de 2 segundos
        }
    }

    // Corutina para desactivar el objeto después de un tiempo
    IEnumerator DeactivateObjectAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay); // Esperar el tiempo especificado (2 segundos)
        if (objectToActivate != null)
        {
            objectToActivate.SetActive(false); // Desactivar el objeto
        }
    }
}
