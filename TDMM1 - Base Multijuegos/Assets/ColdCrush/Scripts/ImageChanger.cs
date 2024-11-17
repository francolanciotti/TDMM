using UnityEngine;
using UnityEngine.UI; // Necesario para manipular el componente Image

public class ImageChanger : MonoBehaviour
{
    public ProximityDetector proximityDetector; 
    public Image imageComponent; // El componente Image en el Canvas
    public Sprite defaultImage; // Imagen por defecto
    public Sprite closeImage; // Imagen cuando isClose es true

    void Update()
    {
        
        if (proximityDetector != null)
        {
            // Cambia la imagen dependiendo de la variable isClose
            if (proximityDetector.isClose)
            {
                ChangeImage(closeImage); // Cambiar a la imagen de cerca
            }
            else
            {
                ChangeImage(defaultImage); // Cambiar a la imagen por defecto
            }
        }
    }

    // Método para cambiar la imagen
    void ChangeImage(Sprite newImage)
    {
        if (imageComponent != null && newImage != null)
        {
            imageComponent.sprite = newImage; // Cambiar la imagen en el componente
        }
    }
}
