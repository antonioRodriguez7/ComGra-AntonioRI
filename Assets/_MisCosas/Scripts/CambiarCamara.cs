using UnityEngine;
using UnityEngine.InputSystem;
using Unity.Cinemachine;

// Tecla V: cambia entre primera y tercera persona
public class CambiarCamara : MonoBehaviour
{
    public CinemachineCamera terceraPersona;   // PlayerFollowCamera
    public CinemachineCamera primeraPersona;   // CamaraPrimeraPersona
    public GameObject cuerpo;                  // Remy (se oculta en primera persona)

    bool enPrimera = false;

    void Update()
    {
        if (Keyboard.current.vKey.wasPressedThisFrame)
        {
            enPrimera = !enPrimera;

            // Cinemachine enseña la cámara con más prioridad
            primeraPersona.Priority = enPrimera ? 20 : 5;
            terceraPersona.Priority = 10;

            // en primera persona escondemos el cuerpo para no ver el interior de la cabeza
            foreach (var r in cuerpo.GetComponentsInChildren<SkinnedMeshRenderer>())
                r.enabled = !enPrimera;
        }
    }
}