using System.Collections;
using UnityEngine;

public class Boost : MonoBehaviour
{
    [SerializeField] private float BoostTimer = 0.1f;  // Duración del boost
    [SerializeField] private float speedUp = 4f;       // Incremento de velocidad
    [SerializeField] public int cantidadDeHelados = 1; // Cantidad de helados
    [SerializeField] public Player playerScript;       // Script del jugador
    [SerializeField] private Configuracion_General config;
    [SerializeField] public Animator animator;
    [SerializeField] private BoostUI boostUI;           // Referencia a BoostUI para activar las barras

    public enum boostType
    {
        Velocidad,
        Helado,
        Fantasma,
        Obstaculo
    };

    public boostType bs;

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            switch (bs)
            {
                case boostType.Velocidad:
                    StartCoroutine(SpeedBoost());
                    boostUI.ActivateBoostBar(boostType.Velocidad, BoostTimer);  // Activar barra de Velocidad
                    break;

                case boostType.Helado:
                    Mochila mochila = other.GetComponent<Mochila>();
                    if (mochila != null)
                    {
                        mochila.AñadirHelado(cantidadDeHelados);
                        Destroy(gameObject); // Destruir objeto de helado
                    }
                    break;

                case boostType.Fantasma:
                    StartCoroutine(DisableSuck());
                    boostUI.ActivateBoostBar(boostType.Fantasma, BoostTimer);  // Activar barra de Fantasma
                    break;

                case boostType.Obstaculo:
                    StartCoroutine(SpeedBoost());
                    boostUI.ActivateBoostBar(boostType.Obstaculo, BoostTimer);  // Activar barra de Obstáculo
                    break;
            }
        }
    }

    IEnumerator SpeedBoost()
{
    if (playerScript != null)
    {
        playerScript.speed += speedUp; // Aumentar solo la velocidad actual del jugador
    }
    yield return new WaitForSeconds(BoostTimer); // Esperar el BoostTimer
    if (playerScript != null)
    {
        playerScript.speed -= speedUp; // Restablecer la velocidad actual
    }
}

    IEnumerator DisableSuck()
    {
        if (playerScript != null)
        {
            playerScript.canSuck = false;    // Habilitar acción de "Suck"
            animator.SetBool("CanSuck", false);
        }
        yield return new WaitForSeconds(BoostTimer); // Esperar el BoostTimer
        if (playerScript != null)
        {
            playerScript.canSuck = true;   // Deshabilitar acción de "Suck"
            animator.SetBool("CanSuck", true);
        }
    }
}
