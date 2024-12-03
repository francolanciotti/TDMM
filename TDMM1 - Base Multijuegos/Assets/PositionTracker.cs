using UnityEngine;
using UnityEngine.UI;

public class PositionTracker : MonoBehaviour
{
    public Transform player;           // Referencia al transform del Player
    public Transform dinosaur;         // Referencia al transform del Dinosaurio
    public RectTransform playerIcon;   // Referencia al icono del Player en la barra
    public RectTransform dinoIcon;     // Referencia al icono del Dinosaurio en la barra
    public float trackHeight = 500f;   // Altura de la barra

    public float endPointZ = 1000f;    // Punto final de la carrera (total) en el eje Z
    public float visualEndPointZ = 500f; // Punto final visual de la carrera (cuando se reinician los iconos en la barra)

    private float totalProgressPlayer = 0f;  // Progreso general del Player (en la carrera)
    private float totalProgressDino = 0f;    // Progreso general del Dinosaurio (en la carrera)

    private float visualProgressPlayer = 0f; // Progreso visual de la barra (Player)
    private float visualProgressDino = 0f;   // Progreso visual de la barra (Dinosaurio)

    private Vector3 playerStartPoint;        // Punto de inicio real para el cálculo del progreso del jugador
    private Vector3 dinoStartPoint;          // Punto de inicio real para el cálculo del progreso del dinosaurio

    void Start()
    {
        // Inicializamos el punto de partida como la posición actual del jugador y dinosaurio
        playerStartPoint = player.position;
        dinoStartPoint = dinosaur.position;
    }

    void Update()
    {
        // Calcular el progreso total de la carrera para el Player y Dinosaurio (basado en la distancia total en la carrera)
        totalProgressPlayer = Mathf.InverseLerp(playerStartPoint.z, endPointZ, player.position.z);
        totalProgressDino = Mathf.InverseLerp(dinoStartPoint.z, endPointZ, dinosaur.position.z);

        // Calcular el progreso visual de la barra de progreso (basado en la distancia visual en la barra)
        visualProgressPlayer = Mathf.InverseLerp(0, visualEndPointZ, player.position.z);
        visualProgressDino = Mathf.InverseLerp(0, visualEndPointZ, dinosaur.position.z);

        // Si el Player alcanza el final visual de la barra, reiniciar el icono visual, pero no detener el avance
        if (visualProgressPlayer >= 1f)
        {
            visualProgressPlayer = 0f; // Reiniciar visualmente el icono del Player
            playerStartPoint = player.position; // Mantener el progreso real, pero reiniciar visualmente
        }

        // Si el Dinosaurio alcanza el final visual de la barra, reiniciar el icono visual, pero no detener el avance
        if (visualProgressDino >= 1f)
        {
            visualProgressDino = 0f; // Reiniciar visualmente el icono del Dinosaurio
            dinoStartPoint = dinosaur.position; // Mantener el progreso real, pero reiniciar visualmente
        }

        // Actualizar la posición de los iconos de la barra según el progreso visual
        playerIcon.anchoredPosition = new Vector2(playerIcon.anchoredPosition.x, Mathf.Lerp(0, trackHeight, visualProgressPlayer));
        dinoIcon.anchoredPosition = new Vector2(dinoIcon.anchoredPosition.x, Mathf.Lerp(0, trackHeight, visualProgressDino));
    }
}
