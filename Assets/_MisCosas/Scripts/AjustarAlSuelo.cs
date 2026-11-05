using UnityEngine;

// Pone el objeto justo encima del suelo de Google.
// La ciudad de Cesium se va cargando poco a poco al darle a Play y el suelo cambia un poco de altura,
// así que cada medio segundo se mira con un rayo hacia abajo dónde está el suelo.
public class AjustarAlSuelo : MonoBehaviour
{
    public float cadaSegundos = 0.5f;
    float siguiente;

    void Update()
    {
        if (Time.time < siguiente) return;
        siguiente = Time.time + cadaSegundos;

        // si el objeto está dentro de otro que ya se ajusta solo, no hace falta
        if (transform.parent != null && transform.parent.GetComponentInParent<AjustarAlSuelo>() != null) return;

        Vector3 desde = transform.position + Vector3.up * 3f;
        float suelo = float.MinValue;
        foreach (RaycastHit h in Physics.RaycastAll(desde, Vector3.down, 8f))
        {
            if (h.collider.GetComponentInParent<AjustarAlSuelo>() != null) continue;      // otras personas, mesas o coches
            if (h.collider.GetComponentInParent<CharacterController>() != null) continue; // el avatar
            if (h.point.y > suelo) suelo = h.point.y;
        }
        if (suelo > float.MinValue)
            transform.position = new Vector3(transform.position.x, suelo, transform.position.z);
    }
}
