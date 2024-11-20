using UnityEngine;

public class PanelController : MonoBehaviour
{
    public GameObject panel; // Asigna el panel en el Inspector

    private void Start()
    {
        // Ocultamos el panel al inicio y aseguramos que el juego esté en tiempo normal
        if (panel != null)
        {
            panel.SetActive(false);
        }
        Time.timeScale = 1f; // Tiempo normal al inicio
    }

    // Activa el panel, pausa el juego y desactiva el objeto al colisionar
    private void OnTriggerEnter(Collider other)
    {
        // Verifica si el panel existe y si el objeto que colisiona es el jugador (o el objeto deseado)
        if (panel != null && other.CompareTag("Player"))
        {
            panel.SetActive(true);
            Time.timeScale = 0f; // Pausa el juego
           
        }
    }

    private void Update()
    {
        // Desactiva el panel y reanuda el juego al presionar las teclas "1" o "2" o "3"
        if (panel != null && panel.activeSelf && (Input.GetKeyDown(KeyCode.Keypad1) || Input.GetKeyDown(KeyCode.Keypad3)))
        {
            panel.SetActive(false);
            Time.timeScale = 1f; // Reanuda el juego
            gameObject.SetActive(false); // Desactiva este objeto activador
        }
    }
}
