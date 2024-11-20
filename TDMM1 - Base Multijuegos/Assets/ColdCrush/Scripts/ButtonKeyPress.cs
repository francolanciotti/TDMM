using UnityEngine;
using UnityEngine.UI;

public class ButtonKeyPress : MonoBehaviour
{
    public Button targetButton; // Botón que se activará

    void Update()
    {
        // Detectar si se presionó la tecla "O" o "o"
        if (Input.GetKeyDown(KeyCode.O))  // Detecta cuando se presiona la tecla "O"
        {
            // Mostrar el efecto visual de selección
            targetButton.Select();

            // Activar el botón (ejecutar su evento onClick)
            targetButton.onClick.Invoke();
        }
    }
}
