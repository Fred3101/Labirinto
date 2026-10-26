using System.Collections;
using UnityEngine;

public class BussolaSonoraScript : MonoBehaviour
{
    // Lista de AudioSources dos diferentes objetos na cena
    public AudioSource[] audioSources; 
    private bool sequenciaTocando;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q) && !sequenciaTocando)
        {
            sequenciaTocando = true;
            StartCoroutine(PlaySpatialSequence());
        }
    }

    IEnumerator PlaySpatialSequence()
    {
        if (audioSources == null)
        {
            Debug.LogError("BussolaSonoraScript precisa de uma lista de AudioSources configurada.", this);
            sequenciaTocando = false;
            yield break;
        }

        int ultimoIndiceComAudio = -1;
        for (int i = 0; i < audioSources.Length; i++)
        {
            if (audioSources[i] != null && audioSources[i].clip != null)
            {
                ultimoIndiceComAudio = i;
            }
        }

        if (ultimoIndiceComAudio < 0)
        {
            Debug.LogError("BussolaSonoraScript não tem nenhum AudioSource com clipe configurado.", this);
            sequenciaTocando = false;
            yield break;
        }

        for (int i = 0; i <= ultimoIndiceComAudio; i++)
        {
            AudioSource source = audioSources[i];
            if (source != null && source.clip != null)
            {
                AudioPlaybackCoordinator.Play(source);
                yield return new WaitWhile(() => source.isPlaying);
            }

            if (i == ultimoIndiceComAudio)
            {
                TutorialBSScript.RegistrarUltimoAudioDaBussola();
            }
        }

        sequenciaTocando = false;
    }
}
