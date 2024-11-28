using UnityEngine;

public class UIFadeEffect : MonoBehaviour
{
    public CanvasGroup uiElement; // Referencia al CanvasGroup del objeto UI.
    public float fadeDuration = 1f; // Duración del fade in/out.
    public Mochila mochila; // Referencia al script Mochila.

    private bool previousShootingState = false; // Para detectar cambios en el estado de `isShooting`.

    void Update()
    {
        // Verifica si el valor de `isShooting` cambia.
        if (mochila.isShooting != previousShootingState)
        {
            previousShootingState = mochila.isShooting;

            if (mochila.isShooting)
                StartCoroutine(FadeIn());
            else
                StartCoroutine(FadeOut());
        }
    }

    private System.Collections.IEnumerator FadeIn()
    {
        float elapsedTime = 0f;

        while (elapsedTime < fadeDuration)
        {
            elapsedTime += Time.deltaTime;
            uiElement.alpha = Mathf.Clamp01(elapsedTime / fadeDuration); // Interpola la opacidad.
            yield return null;
        }

        uiElement.alpha = 1f; // Asegúrate de que quede completamente visible.
        uiElement.interactable = true; // Permitir interacción.
        uiElement.blocksRaycasts = true; // Permitir detección de clics.
    }

    private System.Collections.IEnumerator FadeOut()
    {
        float elapsedTime = 0f;

        while (elapsedTime < fadeDuration)
        {
            elapsedTime += Time.deltaTime;
            uiElement.alpha = Mathf.Clamp01(1f - (elapsedTime / fadeDuration)); // Interpola la opacidad.
            yield return null;
        }

        uiElement.alpha = 0f; // Asegúrate de que quede completamente invisible.
        uiElement.interactable = false; // Deshabilitar interacción.
        uiElement.blocksRaycasts = false; // Deshabilitar detección de clics.
    }
}
