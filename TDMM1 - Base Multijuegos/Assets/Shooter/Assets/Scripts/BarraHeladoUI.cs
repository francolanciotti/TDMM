using UnityEngine;
using UnityEngine.UI;

public class BarraHeladosUI : MonoBehaviour
{
    public Mochila mochila; // Referencia al script Mochila
    public Image barraHelados; // Referencia a la imagen de la barra de helados
    public int maxHelados = 20; // Máximo de helados que se pueden mostrar

    private void Update()
    {
        ActualizarBarra();
    }

    private void ActualizarBarra()
    {
        if (mochila != null && barraHelados != null)
        {
            float fillAmount = Mathf.Clamp01((float)mochila.helados / maxHelados);
            barraHelados.fillAmount = fillAmount;
        }
    }
}
