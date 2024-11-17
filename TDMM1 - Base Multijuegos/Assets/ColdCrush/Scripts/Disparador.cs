using UnityEngine;

public class Disparador : MonoBehaviour
{
    private Mochila mochila;
    public GameObject charcoPrefab; // Prefab del charco de helado
    [SerializeField] public Animator animator;

    private void Start()
    {
        mochila = GetComponent<Mochila>(); // Asegúrate de que el script Mochila esté en el mismo objeto
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) // Por ejemplo, usar la barra espaciadora para disparar
        {
            if (mochila.shoot) // Asegúrate de que el disparador esté activado
            {
                animator.SetBool("Shoot", true); // Inicia la animación
                mochila.DispararHelado(); // Realiza el disparo
            }
        }
    }

    // Este método se llamará al final de la animación "Shoot" mediante un evento
    public void OnShootAnimationEnd()
    {
        CrearCharcoDetrasDelJugador(); // Llama a la función para crear el charco
        animator.SetBool("Shoot", false); // Detiene la animación "Shoot"
    }

    private void CrearCharcoDetrasDelJugador()
    {
        // Calcula la posición detrás del jugador
        Vector3 posicionDetras = new Vector3(transform.position.x, 2.1f, transform.position.z - 1f);

        // Define la rotación deseada (90 grados en el eje X)
        Quaternion rotacionCharco = Quaternion.Euler(90, 0, 0);

        // Instancia el prefab del charco con la rotación y la posición calculada
        Instantiate(charcoPrefab, posicionDetras, rotacionCharco);
    }
}
