using UnityEngine;

public class autopilot : MonoBehaviour
{
     [Header("Configuraci�n de comportamiento")]
    [SerializeField] private float speed = 3.0f;
    [SerializeField] private Configuracion_General config;
private void Awake()
    {
        GameObject gm = GameObject.FindWithTag("GameController");

        if (gm != null)
        {
            config = gm.GetComponent<Configuracion_General>();

        }

    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
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
}}
