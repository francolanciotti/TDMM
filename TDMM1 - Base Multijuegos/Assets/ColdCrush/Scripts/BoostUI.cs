using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class BoostUI : MonoBehaviour
{
    [SerializeField] private Image velocidadBarEmpty;    // Barra vacía de Velocidad
    [SerializeField] private Image velocidadBarFilled;   // Barra llena de Velocidad
    [SerializeField] private Image obstaculoBarEmpty;    // Barra vacía de Obstáculo
    [SerializeField] private Image obstaculoBarFilled;   // Barra llena de Obstáculo
    [SerializeField] private Image fantasmaBarEmpty;     // Barra vacía de Fantasma
    [SerializeField] private Image fantasmaBarFilled;    // Barra llena de Fantasma

    private void Start()
    {
        // Inicializar todas las barras vacías y desactivarlas al principio
        velocidadBarEmpty.fillAmount = 1;
        velocidadBarFilled.fillAmount = 0;

        obstaculoBarEmpty.fillAmount = 1;
        obstaculoBarFilled.fillAmount = 0;

        fantasmaBarEmpty.fillAmount = 1;
        fantasmaBarFilled.fillAmount = 0;

        // Desactivar todas las barras inicialmente
        velocidadBarEmpty.gameObject.SetActive(false);
        velocidadBarFilled.gameObject.SetActive(false);

        obstaculoBarEmpty.gameObject.SetActive(false);
        obstaculoBarFilled.gameObject.SetActive(false);

        fantasmaBarEmpty.gameObject.SetActive(false);
        fantasmaBarFilled.gameObject.SetActive(false);
    }

    // Activar las barras según el tipo de boost
    public void ActivateBoostBar(Boost.boostType boostType, float boostDuration)
    {
        switch (boostType)
        {
            case Boost.boostType.Velocidad:
                velocidadBarEmpty.gameObject.SetActive(true);   // Activar barra vacía
                velocidadBarFilled.gameObject.SetActive(true);  // Activar barra llena
                velocidadBarFilled.fillAmount = 1;              // Llenar la barra
                StartCoroutine(DeactivateBoostBar(velocidadBarEmpty, velocidadBarFilled, boostDuration)); // Desactivarla después del boost
                break;

            case Boost.boostType.Fantasma:
                fantasmaBarEmpty.gameObject.SetActive(true);    // Activar barra vacía
                fantasmaBarFilled.gameObject.SetActive(true);   // Activar barra llena
                fantasmaBarFilled.fillAmount = 1;               // Llenar la barra
                StartCoroutine(DeactivateBoostBar(fantasmaBarEmpty, fantasmaBarFilled, boostDuration)); // Desactivarla después del boost
                break;

            case Boost.boostType.Obstaculo:
                obstaculoBarEmpty.gameObject.SetActive(true);   // Activar barra vacía
                obstaculoBarFilled.gameObject.SetActive(true);  // Activar barra llena
                obstaculoBarFilled.fillAmount = 1;              // Llenar la barra
                StartCoroutine(DeactivateBoostBar(obstaculoBarEmpty, obstaculoBarFilled, boostDuration)); // Desactivarla después del boost
                break;
        }
    }

    // Coroutine para vaciar y desactivar la barra al finalizar el boost
    private IEnumerator DeactivateBoostBar(Image barEmpty, Image barFilled, float boostDuration)
    {
        float elapsedTime = 0f;

        // Mientras el tiempo del boost no haya pasado, reducimos el fillAmount de la barra llena
        while (elapsedTime < boostDuration)
        {
            elapsedTime += Time.deltaTime;  // Aumentar el tiempo transcurrido
            barFilled.fillAmount = 1 - (elapsedTime / boostDuration);  // Vaciar la barra de derecha a izquierda
            yield return null;  // Esperar un frame antes de continuar
        }

        // Después de que haya terminado el boost, vaciar la barra llena y desactivarla
        barFilled.fillAmount = 0;
        barFilled.gameObject.SetActive(false);

        // Desactivar la barra vacía también
        barEmpty.gameObject.SetActive(false);
    }
}
