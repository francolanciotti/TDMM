using UnityEngine;

public class Mochila : MonoBehaviour
{
    public int helados = 0; // Contador de helados.
    public bool shoot = false; // Estado del disparador.
    public bool isShooting = false; // Indica si está disparando activamente.
    public float shootingDuration = 2f; // Duración del estado activo de disparo.

    public void AñadirHelado(int cantidad)
    {
        helados += cantidad;
        VerificarShoot();
    }

    private void VerificarShoot()
    {
        if (helados >= 2)
        {
            shoot = true;
        }
    }

    public void DispararHelado()
    {
        if (shoot)
        {
            Debug.Log("¡Helado disparado!");
            helados -= 2; // Restar 2 helados al disparar.
            shoot = false; // Desactivar el disparador.
            StartCoroutine(ActivarDisparo()); // Iniciar el estado activo de disparo.
        }
        else
        {
            Debug.Log("No hay suficientes helados para disparar.");
        }
    }

    private System.Collections.IEnumerator ActivarDisparo()
    {
        isShooting = true; // Activa el estado de disparo.
        yield return new WaitForSeconds(shootingDuration); // Espera el tiempo configurado.
        isShooting = false; // Desactiva el estado de disparo.
    }
}
