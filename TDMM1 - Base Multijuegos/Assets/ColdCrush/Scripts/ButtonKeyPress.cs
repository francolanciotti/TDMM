using UnityEngine;
using UnityEngine.UI;

public class ButtonKeyPress : MonoBehaviour
{
    public Button targetButton; // Botón que se activará

    void Update()
{
    foreach (char c in Input.inputString)
    {
        if (c == '+') // Detectar específicamente el carácter '+'
        {
            // Mostrar el efecto visual de selección
            targetButton.Select();
            
            // Activar el botón
            targetButton.onClick.Invoke();
        }
    }
}
}