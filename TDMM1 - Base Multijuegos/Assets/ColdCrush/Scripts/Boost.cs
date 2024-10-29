using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boost : MonoBehaviour
{
    //private Player playerScript;
    [SerializeField] private float BoostTimer = 0.1f;
    [SerializeField] private float speedUp = 4f;
    [SerializeField] public int cantidadDeHelados = 1; // Cantidad de helados que da este objeto
    [SerializeField] public Player playerScript;
    [SerializeField] private Configuracion_General config;
    //Estructura de datos para definir tipo de boost

    public enum boostType // your custom enumeration
    {
        Velocidad,
        Helado,
    };

    public boostType bs;

    void OnTriggerEnter(Collider other)
    {
        // Si el boost choca con el jugador
        if (other.gameObject.tag == "Player")
        {
            switch (bs)
            {
                case boostType.Velocidad:
                    StartCoroutine(SpeedBoost());
                    break;
                case boostType.Helado:

                    Mochila mochila = other.GetComponent<Mochila>();

                    if (mochila != null)
                    {
                        mochila.AñadirHelado(cantidadDeHelados);
                        Destroy(gameObject); // Destruir el objeto helado
                    }
                    break;
            }

        }
    }

    IEnumerator SpeedBoost()
    {
        if (playerScript != null)
        {
            playerScript.speed += speedUp;
        }
        yield return new WaitForSeconds(BoostTimer);
        playerScript.speed -= speedUp;
    }

}
