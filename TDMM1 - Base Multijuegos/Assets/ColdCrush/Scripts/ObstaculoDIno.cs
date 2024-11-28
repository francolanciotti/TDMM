using System.Collections;
using UnityEngine;

public class CharcoHelado : MonoBehaviour
{
    [SerializeField] private float speedReduction = 2f; // Reducción de velocidad
    [SerializeField] private float effectDuration = 3f; // Duración del efecto

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Objeto detectado: " + other.gameObject.name); // Log para depurar

        // Verifica si el objeto que colisiona es un enemigo
        if (other.CompareTag("Enemy"))
        {
            EnemyAI enemyAI = other.GetComponent<EnemyAI>();
            if (enemyAI != null)
            {
                StartCoroutine(ApplySpeedReduction(enemyAI));
            }
        }
    }

    private IEnumerator ApplySpeedReduction(EnemyAI enemyAI)
    {
        Debug.Log("Reduciendo velocidad del enemigo.");
        enemyAI.tempSpeedReduction += speedReduction; // Aplica la reducción temporal
        yield return new WaitForSeconds(effectDuration);
        enemyAI.tempSpeedReduction -= speedReduction; // Restaura la velocidad
        Debug.Log("Restaurando velocidad del enemigo.");
    }
}
