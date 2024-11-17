using UnityEngine;
using System.Collections;  // Necesario para las coroutines

public class IntroPanelController : MonoBehaviour
{
    public GameObject introPanel;  // Referencia al panel de introducción
    public float timeToDisappear = 3f;  // Tiempo en segundos antes de que desaparezca

    void Start()
    {
        // Asegurarse de que el panel esté activo al iniciar
        introPanel.SetActive(true);
        Debug.Log("Panel visible. El temporizador se iniciará.");

        // Pausar el juego inmediatamente
        Time.timeScale = 0f;

        // Iniciar la coroutine para ocultar el panel después del tiempo especificado
        StartCoroutine(HideIntroPanelAfterTime(timeToDisappear));
    }

    // Coroutine para ocultar el panel después de un tiempo
    IEnumerator HideIntroPanelAfterTime(float timeToDisappear)
    {
        // Esperar el tiempo definido
        yield return new WaitForSecondsRealtime(timeToDisappear);

        Debug.Log("HideIntroPanel fue llamado desde la Coroutine");

        // Verificar si el panel aún está activo antes de desactivarlo
        if (introPanel.activeSelf)
        {
            introPanel.SetActive(false);
            Debug.Log("Panel ocultado.");
        }

        // Reanudar el juego
        Time.timeScale = 1f;
        Debug.Log("Juego reanudado.");
    }
}
