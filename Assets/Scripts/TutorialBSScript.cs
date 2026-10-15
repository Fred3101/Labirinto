using UnityEngine;

public class TutorialBSScript : MonoBehaviour
{
    [SerializeField] private AudioSource primeiroAudio;
    [SerializeField] private AudioSource segundoAudio;
    [SerializeField] private BussolaSonoraScript bussolaSonora;

    private EstadoTutorial estado = EstadoTutorial.AguardandoPlayer;
    private AudioSource audioFinalDaBussola;
    private bool audioFinalFoiIniciado;
    private bool audioFinalTerminou;

    private enum EstadoTutorial
    {
        AguardandoPlayer,
        TocandoPrimeiroAudio,
        AguardandoAudioFinalDaBussola,
        TocandoSegundoAudio,
        Concluido
    }

    private void Update()
    {
        if (estado != EstadoTutorial.AguardandoPlayer && estado != EstadoTutorial.Concluido)
        {
            if (audioFinalDaBussola.isPlaying)
            {
                audioFinalFoiIniciado = true;
            }
            else if (audioFinalFoiIniciado)
            {
                audioFinalTerminou = true;
            }
        }

        switch (estado)
        {
            case EstadoTutorial.TocandoPrimeiroAudio when !primeiroAudio.isPlaying:
                Time.timeScale = 1f;
                estado = EstadoTutorial.AguardandoAudioFinalDaBussola;
                break;
            case EstadoTutorial.AguardandoAudioFinalDaBussola when audioFinalTerminou:
                Time.timeScale = 0f;
                segundoAudio.Play();
                estado = EstadoTutorial.TocandoSegundoAudio;
                break;
            case EstadoTutorial.TocandoSegundoAudio when !segundoAudio.isPlaying:
                Time.timeScale = 1f;
                estado = EstadoTutorial.Concluido;
                break;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (estado != EstadoTutorial.AguardandoPlayer || !other.CompareTag("Player"))
        {
            return;
        }

        if (primeiroAudio == null || primeiroAudio.clip == null ||
            segundoAudio == null || segundoAudio.clip == null ||
            bussolaSonora == null || bussolaSonora.audioSources == null ||
            bussolaSonora.audioSources.Length <= 3 || bussolaSonora.audioSources[3] == null)
        {
            Debug.LogError("TutorialBSScript precisa dos dois AudioSources e do Element 3 da BussolaSonoraScript configurados.", this);
            return;
        }

        audioFinalDaBussola = bussolaSonora.audioSources[3];
        audioFinalFoiIniciado = false;
        audioFinalTerminou = false;
        Time.timeScale = 0f;
        primeiroAudio.Play();
        estado = EstadoTutorial.TocandoPrimeiroAudio;
    }
}
