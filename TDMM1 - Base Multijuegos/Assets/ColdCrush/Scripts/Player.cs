using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [Header("Configuración de movimiento")]
    public bool carriles = false;
    public bool autoPilot = false;
    [HideInInspector] public float[] posCarriles;
    [SerializeField] public Animator animator;
    [SerializeField] private int cantCarriles = 3;
    [SerializeField] private float movementDistance = 6.0f;

    public float playerPosition;
    [SerializeField] private float limitY = -3.5f;
    [SerializeField] private float limitX = 8.10f;

    [HideInInspector] public float speed = 8;

    [SerializeField] private bool puedeVolar = false;

    [Header("Configuración de vida")]
    [HideInInspector] public int life = 3;
    [HideInInspector] public bool inmunity = false;

    [Header("Configuración de Succion de helado")]
    [SerializeField] public bool canSuck = true;
    [SerializeField] public float suckDuration = 2f;
    private bool isSucking = false;

    [Header("Configuración generales")]
    [SerializeField] private Configuracion_General config;

    // Variables para el CapsuleCollider
    private CapsuleCollider capsuleCollider;
    private float originalHeight;
    private float newHeight = 4f; // Nueva altura del collider
    private Vector3 originalCenter;
    private Vector3 newCenter = new Vector3(0f, 1f, 0f); // Nuevo centro del collider

    // Start is called before the first frame update
    void Start()
    {
        life = config.vidas;
        speed = config.velocidad;

        // Inicializa el CapsuleCollider
        capsuleCollider = GetComponent<CapsuleCollider>();
        if (capsuleCollider != null)
        {
            originalHeight = capsuleCollider.height; // Guarda la altura original
            originalCenter = capsuleCollider.center; // Guarda el centro original
        }

        // Configuración de carriles
        if (carriles)
        {
            if (cantCarriles == 2)
            {
                posCarriles = new float[3] { -movementDistance, 0, movementDistance };
            }
            else if (cantCarriles == 3)
            {
                posCarriles = new float[3] { -movementDistance, 0, movementDistance };  // Añadimos el carril intermedio
            }
            else
            {
                Debug.Log("Estas intentando usar " + cantCarriles + ". El permitido es tres o dos.");
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
        Chupar();
        animator.SetFloat("Speed", speed);
    }

    private void Movement()
    {
        if (carriles)
        {
            // Movimiento en el eje X entre carriles usando los botones 1, 2 y 3
            float playerPosition = transform.position.x;

            if (Input.GetKeyDown(KeyCode.Keypad1)) // Carril izquierdo
            {
                transform.position = new Vector3(posCarriles[0], transform.position.y, transform.position.z);
            }
            else if (Input.GetKeyDown(KeyCode.Keypad2)) // Carril central
            {
                transform.position = new Vector3(posCarriles[1], transform.position.y, transform.position.z);
            }
            else if (Input.GetKeyDown(KeyCode.Keypad3)) // Carril derecho
            {
                transform.position = new Vector3(posCarriles[2], transform.position.y, transform.position.z);
            }
        }
        else
        {
            float horizontalInput = Input.GetAxis("Horizontal");
            transform.Translate(Vector3.right * speed * horizontalInput * Time.deltaTime);

            if (transform.position.x > limitX)
            {
                transform.position = new Vector3(limitX, transform.position.y);
            }
            else if (transform.position.x < -limitX)
            {
                transform.position = new Vector3(-limitX, transform.position.y);
            }

            if (puedeVolar)
            {
                float verticalInput = Input.GetAxis("Vertical");
                transform.Translate(Vector2.up * speed * verticalInput * Time.deltaTime);

                if (transform.position.y > 0)
                {
                    transform.position = new Vector2(transform.position.x, 0);
                }
                else if (transform.position.y < limitY)
                {
                    transform.position = new Vector2(transform.position.x, limitY);
                }
            }
        }

        if (autoPilot)
        {
            transform.Translate(Vector3.forward * speed * Time.deltaTime);
            Debug.Log(speed);
        }
    }

    void OnTriggerEnter(Collider obj)
    {
        Debug.Log("Choqué con algo y su tag es: " + obj.gameObject.tag);
    }

    public void Damage(int _dmg)
    {
        if (inmunity == false)
        {
            if (life > 0)
            {
                life -= _dmg;
                if (life <= 0)
                {
                    Debug.Log("El jugador ha perdido.");
                    config.perdiste = true;
                    //Destroy(this.gameObject);
                }
            }
        }
        else
        {
            inmunity = false;
        }

        // Actualizamos la variable de vida de la configuración general
        config.vidas = life;
    }

    public void moveOSC(float _x)
    {
        transform.Translate(Vector3.right * speed * _x * Time.deltaTime);
        if (transform.position.x > limitX)
        {
            transform.position = new Vector3(limitX, transform.position.y);
        }
        else if (transform.position.x < -limitX)
        {
            transform.position = new Vector3(-limitX, transform.position.y);
        }
    }

    private void Chupar()
    {
        // Si se presiona la tecla "+" y no está ya activo
        if (Input.GetKeyDown(KeyCode.O) && canSuck && !isSucking)
        {
            animator.SetBool("Chupar", true);
            isSucking = true; // Activar estado
            ChangeColliderProperties(true); // Cambiar propiedades
            Invoke("StopSucking", suckDuration); // Programar la desactivación después de suckDuration segundos
        }
    }

    private void ChangeColliderProperties(bool isChanging)
    {
        if (capsuleCollider != null)
        {
            if (isChanging)
            {
                capsuleCollider.height = newHeight;
                capsuleCollider.center = newCenter;
            }
            else
            {
                capsuleCollider.height = originalHeight;
                capsuleCollider.center = originalCenter;
            }
        }
    }

    private void StopSucking()
    {
        isSucking = false;
        ChangeColliderProperties(false); // Revertir propiedades
        animator.SetBool("Chupar", false);
    }
}
