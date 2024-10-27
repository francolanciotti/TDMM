using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{

    [Header("Configuraci�n de comportamiento")]
    [SerializeField] private float speed = 3.0f;

    [Header("Configuraci�n de estad�sticas")]
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

    }

    // Update is called once per frame
    void Update()
    {
        Movement();
    }

    private void Movement()
    {
        if (Configuracion_General.runner3D == false)
        {
            if (transform.position.y <= 122.0f)
            {
                transform.Translate(Vector3.forward * speed * Time.deltaTime);
            }
        }else
        {
            if (transform.position.z <= 122.0f)
            {
                transform.Translate(Vector3.forward * speed * Time.deltaTime);
            }
        }

    }

    void OnTriggerEnter(Collider other)
    {
        // Si el enemigo choca con el jugador
        if (other.gameObject.tag == "Player")
        {
            Player player = other.GetComponent<Player>();
            if (player != null)
            {
                Debug.Log("Te choque");
                player.Damage(dmg);
            }

        }
    }
}
    

    

