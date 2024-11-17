using UnityEngine;

public class ObjectActivator : MonoBehaviour
{
    public ProximityDetector proximityDetector; // Referencia al script ProximityChecker
    public GameObject objectToActivate; // El objeto que se activará o desactivará

    void Update()
    {
        // Verificar si proximityChecker no es null
        if (proximityDetector != null)
        {
            // Activar o desactivar el objeto dependiendo del valor de isClose
            if (proximityDetector.isClose)
            {
                ActivateObject(); // Activar el objeto
            }
            else
            {
                DeactivateObject(); // Desactivar el objeto
            }
        }
    }

    // Método para activar el objeto
    void ActivateObject()
    {
        if (objectToActivate != null)
        {
            objectToActivate.SetActive(true); // Activar el objeto
        }
    }

    // Método para desactivar el objeto
    void DeactivateObject()
    {
        if (objectToActivate != null)
        {
            objectToActivate.SetActive(false); // Desactivar el objeto
        }
    }
}
