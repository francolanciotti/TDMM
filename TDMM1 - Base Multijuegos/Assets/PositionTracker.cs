using UnityEngine;
using UnityEngine.UI;

public class IconTracker : MonoBehaviour
{
    public Transform player; // Referencia al transform del jugador
    public Transform dinosaur; // Referencia al transform del dinosaurio
    public RectTransform playerIcon; // Icono del jugador en la barra
    public RectTransform dinosaurIcon; // Icono del dinosaurio en la barra
    public RectTransform progressBar; // La barra de progreso (UI)
    public float worldDistance = 50f; // Distancia en el eje Z que cubre la barra antes de reiniciar
    public float barHeight = 80f; // Altura de la barra

    void Update()
    {
        UpdateIconPosition(player, playerIcon);
        UpdateIconPosition(dinosaur, dinosaurIcon);
    }

    private void UpdateIconPosition(Transform target, RectTransform icon)
    {
        // Calcula la posición relativa en el mundo
        float zPosition = target.position.z;

        // Oculta el icono si la posición Z es negativa
        if (zPosition < 0)
        {
            icon.gameObject.SetActive(false); // Desactiva el icono
            return;
        }
        else
        {
            icon.gameObject.SetActive(true); // Activa el icono si Z es positiva o cero
        }

        // Normaliza la posición en el rango [0, worldDistance]
        float normalizedPosition = (zPosition % worldDistance) / worldDistance;
        if (normalizedPosition < 0) normalizedPosition += 1; // Asegura valores positivos

        // Convierte la posición normalizada a la barra (altura en píxeles)
        float iconYPosition = normalizedPosition * barHeight;

        // Actualiza la posición del icono
        icon.anchoredPosition = new Vector2(icon.anchoredPosition.x, iconYPosition);
    }
}
