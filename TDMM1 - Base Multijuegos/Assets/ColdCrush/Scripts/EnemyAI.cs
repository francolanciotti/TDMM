using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    [Header("Configuración de Velocidades")]
    [SerializeField] private float baseSpeed = 8f;  // Velocidad base del enemigo
    [SerializeField] private float proximitySpeedPercentage = 20f; // Porcentaje extra al acercarse al jugador
    [SerializeField] private float farSpeedMultiplier = 1.5f; // Multiplicador de velocidad cuando está lejos
    [SerializeField] private float proximityThreshold = 5f; // Distancia para activar velocidad dinámica cerca del jugador
    [SerializeField] private float farThreshold = 15f; // Distancia para considerar al jugador lejos
    [SerializeField] private float currentSpeed; // Velocidad actual calculada

    [Header("Modificación de Velocidad")]
    [SerializeField] public float tempSpeedReduction = 0f; // Reducción de velocidad temporal aplicada por el charco

    [Header("Configuración del Jugador")]
    public Transform player; // Referencia al jugador

    [Header("Configuración de Carriles")]
    public float[] posCarriles; // Posiciones de los carriles
    public int currentLane = 1; // Carril actual

    [Header("Configuración de Estadísticas")]
    [SerializeField] private int dmg = 1;

    private void Start()
    {
        // Inicializar carriles
        posCarriles = new float[3] { -5f, 0f, 5f };
        currentSpeed = baseSpeed; // Iniciar con la velocidad base
    }

    private void Update()
    {
        UpdateDynamicSpeed(); // Actualiza la velocidad dinámica
        MoveTowardsPlayer(); // Mover hacia el jugador
    }

    private void UpdateDynamicSpeed()
    {
        float dynamicSpeed = baseSpeed;

        // Si el enemigo está cerca del jugador, ajusta su velocidad
        if (player != null)
        {
            float distanceToPlayer = Vector3.Distance(transform.position, player.position);

            // Si está cerca del jugador (distancia menor o igual a proximityThreshold)
            if (distanceToPlayer <= proximityThreshold)
            {
                dynamicSpeed = player.GetComponent<Player>().GetSpeed() * (1 + proximitySpeedPercentage / 100f);
            }
            // Si está lejos del jugador (distancia mayor a farThreshold)
            else if (distanceToPlayer >= farThreshold)
            {
                dynamicSpeed = baseSpeed * farSpeedMultiplier;
            }
        }

        // Aplica la reducción de velocidad temporal (por ejemplo, por charcos)
        currentSpeed = dynamicSpeed - tempSpeedReduction;

        // Asegurarse de que la velocidad no sea negativa
        currentSpeed = Mathf.Max(currentSpeed, 0f);
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
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, currentSpeed * Time.deltaTime);

            // Mover hacia adelante en el eje Z
            transform.Translate(Vector3.forward * currentSpeed * Time.deltaTime);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        // Si el enemigo choca con el jugador
        if (other.CompareTag("Player"))
        {
            Player player = other.GetComponent<Player>();
            if (player != null)
            {
                Debug.Log("Te choqué");
                player.Damage(dmg);
            }
        }
    }
}
