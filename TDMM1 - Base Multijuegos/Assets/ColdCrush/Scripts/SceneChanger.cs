using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    public string sceneName; // Nombre de la escena a la que quieres cambiar
    public float delay = 5f; // Tiempo de espera antes de cambiar (en segundos)

    void Start()
    {
        // Llama a la corrutina para cambiar de escena después del tiempo especificado
        StartCoroutine(ChangeSceneAfterDelay());
    }

    IEnumerator ChangeSceneAfterDelay()
    {
        // Espera el tiempo especificado
        yield return new WaitForSeconds(delay);

        // Cambia a la escena especificada
        SceneManager.LoadScene(sceneName);
    }
}
