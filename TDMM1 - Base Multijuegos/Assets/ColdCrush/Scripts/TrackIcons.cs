using UnityEngine;

public class MiniMapController : MonoBehaviour
{
    [SerializeField] private RectTransform playerIcon; // Icono del jugador
    [SerializeField] private RectTransform dinoIcon;   // Icono del dino
    [SerializeField] private Transform player;        // Transform del jugador
    [SerializeField] private Transform dino;          // Transform del dino
    [SerializeField] private float levelLength = 100f; // Longitud de cada nivel en unidades del mundo
    [SerializeField] private RectTransform bar;       // Barra del minimapa

    private float barHeight;

    private float playerZStart; // Z inicial del jugador
    private float dinoZStart;   // Z inicial del dino
    private float dinoOffset;   // Diferencia inicial entre dino y player

    private void Start()
    {
        barHeight = bar.rect.height; // Altura de la barra del minimapa

        // Guardar las posiciones iniciales
        playerZStart = player.position.z;
        dinoZStart = dino.position.z;

        // Calcular el offset inicial entre el dino y el player
        dinoOffset = dino.position.z - player.position.z;
    }

    private void Update()
    {
        UpdateIconPositions();
    }

    private void UpdateIconPositions()
    {
        // Progreso del jugador
        float playerProgress = Mathf.Clamp01((player.position.z - playerZStart) / levelLength);
        playerIcon.anchoredPosition = new Vector2(playerIcon.anchoredPosition.x, playerProgress * barHeight);

        // Progreso del dino (considerando su offset inicial)
        float dinoProgress = Mathf.Clamp01((dino.position.z - dinoZStart) / levelLength);
        float adjustedDinoPosition = Mathf.Clamp01((player.position.z - playerZStart + dinoOffset) / levelLength);
        dinoIcon.anchoredPosition = new Vector2(dinoIcon.anchoredPosition.x, adjustedDinoPosition * barHeight);
    }

    public void ResetIcons()
    {
        // Reiniciar las posiciones iniciales para ambos jugadores
        playerZStart = player.position.z;
        dinoZStart = dino.position.z;

        // Recalcular el offset inicial entre el dino y el player
        dinoOffset = dino.position.z - player.position.z;

        // Reiniciar los iconos al inicio de la barra
        playerIcon.anchoredPosition = new Vector2(playerIcon.anchoredPosition.x, 0);
        dinoIcon.anchoredPosition = new Vector2(dinoIcon.anchoredPosition.x, 0);
    }
}
