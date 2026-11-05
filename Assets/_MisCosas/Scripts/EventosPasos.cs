using UnityEngine;

// La animación de andar de los Starter Assets lleva "eventos" que llaman a OnFootstep (para el sonido de pasos).
// Las personas de la plaza no tienen sonido, así que aquí solo recibimos el aviso para que Unity no dé error.
public class EventosPasos : MonoBehaviour
{
    void OnFootstep(AnimationEvent evento) { }
    void OnLand(AnimationEvent evento) { }
}
