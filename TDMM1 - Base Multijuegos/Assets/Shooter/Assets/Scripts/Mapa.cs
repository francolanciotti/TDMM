using UnityEngine;
using UnityEngine.UI;

public class TrackIcons : MonoBehaviour
{
    [SerializeField] GameObject player1; // Primer jugador
    [SerializeField] GameObject player2; // Segundo jugador
    [SerializeField] RectTransform icon1; // Ícono del primer jugador
    [SerializeField] RectTransform icon2; // Ícono del segundo jugador
    [SerializeField] float maxDistance = 100f; // Distancia máxima de la pista
    [SerializeField] float offsetY = 5f; // Desplazamiento en Y

    void Start()
    {
        // Establecer la posición inicial de los íconos en Y + offsetY
        icon1.anchoredPosition = new Vector2(icon1.anchoredPosition.x, icon1.anchoredPosition.y + offsetY);
        icon2.anchoredPosition = new Vector2(icon2.anchoredPosition.x, icon2.anchoredPosition.y + offsetY);
    }

    void Update()
    {
        // Calcular el progreso de ambos jugadores
        float progress1 = player1.transform.position.z / maxDistance;
        float progress2 = player2.transform.position.z / maxDistance;

        // Asegurarse de que el progreso no exceda 1
        progress1 = Mathf.Clamp01(progress1);
        progress2 = Mathf.Clamp01(progress2);

        // Mover los íconos en la barra
        icon1.anchoredPosition = new Vector2(icon1.anchoredPosition.x, progress1 * 100f + offsetY); // 100f es el ancho total
        icon2.anchoredPosition = new Vector2(icon2.anchoredPosition.x, progress2 * 100f + offsetY); // 100f es el ancho total
    }
}
