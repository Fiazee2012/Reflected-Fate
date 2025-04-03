using UnityEngine;
using System.Collections;

public class HeartBeat : MonoBehaviour
{
    public float Strength;
    public float Speed;

    // Variable para almacenar la referencia del coroutine
    private Coroutine pulseCoroutine;

    public void Beat()
    {
        // Solo iniciar el coroutine si aún no se está ejecutando.
        if (pulseCoroutine == null)
        {
            pulseCoroutine = StartCoroutine(Pulse());
        }
    }

    public void StopBeat()
    {
        // Solo detener el coroutine si está en ejecución.
        if (pulseCoroutine != null)
        {
            StopCoroutine(pulseCoroutine);
            pulseCoroutine = null;
        }
    }

    IEnumerator Pulse()
    {
        // Bucle infinito para el latido del corazón
        while (true)
        {
            float timer = 0f;
            float originalSize = transform.localScale.x;

            // Latido doble
            for (int i = 0; i < 2; i++)
            {
                // Zoom in
                while (timer < 0.1f)
                {
                    yield return new WaitForEndOfFrame();
                    timer += Time.deltaTime;

                    transform.localScale = new Vector3
                    (
                        transform.localScale.x + (Time.deltaTime * Strength * 2),
                        transform.localScale.y + (Time.deltaTime * Strength * 2)
                    );
                }
                // Reiniciar el timer para el siguiente ciclo de latido
                timer = 0f;
            }

            // Volver a la escala original de forma progresiva
            while (transform.localScale.x > originalSize)
            {
                yield return new WaitForEndOfFrame();

                transform.localScale = new Vector3
                (
                    transform.localScale.x - Time.deltaTime * Strength,
                    transform.localScale.y - Time.deltaTime * Strength
                );
            }

            // Ajuste final para la escala
            transform.localScale = new Vector3(originalSize, originalSize);

            yield return new WaitForSeconds(Speed);
        }
    }
}
