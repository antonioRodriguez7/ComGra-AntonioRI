using UnityEngine;

// Persona de la plaza (personaje de Mixamo).
// Si "pasear" está activado, anda hacia delante unos metros, se da la vuelta y vuelve.
// Las piernas las mueve el Animator con la animación de andar.
public class Paseante : MonoBehaviour
{
    public bool pasear = true;
    public float velocidad = 1.2f;   // metros por segundo
    public float distancia = 15f;    // metros antes de darse la vuelta

    float recorrido;                 // metros andados desde la última vuelta

    void Start()
    {
        // cada persona empieza en un punto distinto, para que no se giren todas a la vez
        recorrido = Random.Range(0f, distancia);
    }

    void Update()
    {
        if (!pasear) return;

        // avanzar hacia delante (independiente de los FPS gracias a Time.deltaTime)
        transform.position += transform.forward * velocidad * Time.deltaTime;
        recorrido += velocidad * Time.deltaTime;

        // al llegar a la distancia, media vuelta
        if (recorrido >= distancia)
        {
            recorrido = 0f;
            transform.Rotate(0f, 180f, 0f);
        }
    }
}
