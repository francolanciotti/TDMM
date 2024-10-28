using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Espiritu : MonoBehaviour
{
    [SerializeField] public Player playerScript;
    [SerializeField] private float Timer = 0.1f;
    [SerializeField] private Configuracion_General config;
    
    void OnTriggerEnter(Collider other)
    {
        // Si el boost choca con el jugador
        if (other.gameObject.tag == "Player")
        {
            Debug.Log("No puedes succionar helados");
            StartCoroutine(NoSuck());
            return;

        }
}
    IEnumerator NoSuck()
    {
            if (playerScript != null)
            {
                playerScript.canSuck = false;
            }
            yield return new WaitForSeconds(Timer);
            playerScript.canSuck = true;
    }
}
