using System.Collections;
using UnityEngine;

public class BussolaSonoraScript : MonoBehaviour
{
    // Lista de AudioSources dos diferentes objetos na cena
    public AudioSource[] audioSources; 

    void Update()
    {
        if (Input.GetKey(KeyCode.Q)) 
        {
            StartCoroutine(PlaySpatialSequence());
        }
    }

    IEnumerator PlaySpatialSequence()
    {
        foreach (AudioSource source in audioSources)
        {
            // Garante que o AudioSource tem um clipe configurado
            if (source != null && source.clip != null)
            {
                source.Play();

                // Espera a duração do clipe que está tocando nesse objeto específico
                yield return new WaitForSeconds(source.clip.length);
            }
        }
    }
}
