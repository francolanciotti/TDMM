using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Nota : MonoBehaviour {

    public Configuracion_General config;
    Rigidbody2D rb;
    //Esta variable nos va a indicar la velocidad con la que se va a mover en el eje y, osea que tan rapido va a "caer".
    //Hacemos esta variable publica para poder setearla desde el inspector de la nota
    public float velocidad;
    //Esta booleana la vamos a usar para asegurarnos que se llama una sola vez
    bool called = false;

   

    void Awake()
    {
        if (config == null) // Si no está asignado manualmente
        {
            // Buscar el objeto GameManager en la escena
            GameObject gameManager = GameObject.Find("GameManager (1)");

            // Verificar si se encontró el objeto
            if (gameManager != null)
            {
                // Asignar el componente Configuracion_General del GameManager
                config = gameManager.GetComponent<Configuracion_General>();

                // Verificar si el componente fue encontrado
                if (config == null)
                {
                    Debug.LogError("No se encontró el componente Configuracion_General en el GameManager.");
                }
            }
            else
            {
                Debug.LogError("No se encontró el objeto GameManager en la escena.");
            }
        }
        velocidad = config.velocidad;
        rb = GetComponent<Rigidbody2D>();

    }
	
	void Update () {
        //Esto lo hacemos para asegurarnos que las notas empiecen a moverse junto con la musica. 
        //Como necesitamos que la velocidad se sume una sola vez agragamos esta variable "called".
        if ( PlayerPrefs.GetInt("Start") == 1 && !called)
        {
            rb.linearVelocity = new Vector2(0, -velocidad);
        }
    }

}
