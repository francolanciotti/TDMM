using UnityEngine;
using UnityEngine.UI; // Necesario para manipular el componente Image

public class ProximityImageChanger : MonoBehaviour
{
    public Transform target; // Objeto objetivo
    public float proximityDistance = 5f; // Distancia a la que se considera "cerca"
    public bool isClose = false; // Estado para proximidad

    public Image[] imageComponents; // Array de componentes Image en el Canvas
    public Sprite defaultImage; // Imagen por defecto (cuando está lejos)
    public Sprite closeImage; // Imagen cuando está cerca

    void Update()
    {
        // Asegúrate de que el target no sea null
        if (target != null)
        {
            // Calculamos la distancia entre este objeto y el target
            float distance = Vector3.Distance(transform.position, target.position);

            // Si la distancia es menor o igual a la proximidad
            if (distance <= proximityDistance)
            {
                if (!isClose) // Solo cambiar si el estado cambia
                {
                    isClose = true;
                    ChangeImages(closeImage); // Cambiar todas las imágenes a la imagen de cerca
                }
            }
            else
            {
                if (isClose) // Solo cambiar si el estado cambia
                {
                    isClose = false;
                    ChangeImages(defaultImage); // Cambiar todas las imágenes a la imagen por defecto
                }
            }
        }
    }

    // Método para cambiar la imagen de todos los objetos UI Image
    void ChangeImages(Sprite newImage)
    {
        foreach (Image img in imageComponents) // Recorre todos los Image componentes
        {
            if (img != null && newImage != null)
            {
                img.sprite = newImage; // Cambiar la imagen de cada componente
            }
        }
    }
}
