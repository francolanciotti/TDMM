using UnityEngine;

public class TunnelTrigger : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // Reiniciar iconos del minimapa al cruzar el túnel
            FindObjectOfType<MiniMapController>().ResetIcons();
        }
    }
}
