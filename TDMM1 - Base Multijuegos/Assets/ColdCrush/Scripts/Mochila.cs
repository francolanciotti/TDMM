using UnityEngine;

public class Mochila : MonoBehaviour
{
    public int helados = 0; // Contador de helados
    public bool shoot = false; // Estado del disparador

    public void AñadirHelado(int cantidad)
    {
        helados += cantidad;
        VerificarShoot();
    }

    private void VerificarShoot()
    {
        if (helados >= 5)
        {
            shoot = true;
        }
    }

    public void DispararHelado()
    {
        if (shoot)
        {
            // Aquí puedes implementar la lógica para disparar el helado
            Debug.Log("¡Helado disparado!");
            helados -= 5; // Restar 5 helados al disparar
            shoot = false; // Desactivar el disparador
        }
        else
        {
            Debug.Log("No hay suficientes helados para disparar.");
        }
    }
}
