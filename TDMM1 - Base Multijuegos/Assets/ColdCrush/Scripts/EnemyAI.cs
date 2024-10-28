using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    [Header("Configuración de comportamiento")]
    public Transform player; // Referencia al jugador
    public float speed = 4f; // Velocidad de movimiento
    public float[] posCarriles; // Posiciones de los carriles
    public int currentLane = 1; // Carril actual

    [Header("Configuración de estadísticas")]
    [SerializeField] private int dmg = 1;
    public float score = 10f;

    [SerializeField] private Configuracion_General config;

    private void Awake()
    {
        GameObject gm = GameObject.FindWithTag("GameController");

        if (gm != null)
        {
            config = gm.GetComponent<Configuracion_General>();
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        // Define las posiciones de los carriles
        posCarriles = new float[3] { -5f, 0f, 5f };
    }

    // Update is called once per frame
    void Update()
    {
        MoveTowardsPlayer();
    }

    void OnTriggerEnter(Collider other)
    {
        // Si el enemigo choca con el jugador
        if (other.gameObject.CompareTag("Player"))
        {
            Player player = other.GetComponent<Player>();
            if (player != null)
            {
                Debug.Log("Te choque");
                player.Damage(dmg);
            }
        }
    }

    private void MoveTowardsPlayer()
    {
        if (player != null)
        {
            float playerPosX = player.position.x;

            // Determinar el carril basado en la posición X del jugador
            if (playerPosX <= posCarriles[0]) // Si está a la izquierda del primer carril
            {
                currentLane = 0;
            }
            else if (playerPosX >= posCarriles[2]) // Si está a la derecha del último carril
            {
                currentLane = 2;
            }
            else // Si está en el medio
            {
                currentLane = 1;
            }

            // Calcular la posición objetivo en el carril
            float targetPositionX = posCarriles[currentLane];

            // Mover al enemigo hacia la posición objetivo en el carril
            Vector3 targetPosition = new Vector3(targetPositionX, transform.position.y, transform.position.z);
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);

            // Mover hacia adelante en el eje Z
            transform.Translate(Vector3.forward * speed * Time.deltaTime);
        }
    }
}
