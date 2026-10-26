using UnityEngine;

public class TutorialBSScript : MonoBehaviour
{
    private static bool cicloJaIniciado;
    public static bool SegundoAudioConcluido { get; private set; }
    public static bool UltimoAudioDaBussolaConcluido { get; private set; }

    [SerializeField] private AudioSource primeiroAudio;
    [SerializeField] private AudioSource segundoAudio;
    [SerializeField] private BussolaSonoraScript bussolaSonora;

    private EstadoTutorial estado = EstadoTutorial.AguardandoPlayer;
    private AudioSource audioFinalDaBussola;
    private bool audioFinalFoiIniciado;
    private bool audioFinalTerminou;
    private bool contatoRegistrado;

    [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.SubsystemRegistration)]
    private static void ResetState()
    {
        cicloJaIniciado = false;
        SegundoAudioConcluido = false;
        UltimoAudioDaBussolaConcluido = false;
    }

    public static void RegistrarUltimoAudioDaBussola()
    {
        UltimoAudioDaBussolaConcluido = true;
    }

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
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (estado == EstadoTutorial.TocandoPrimeiroAudio)
            {
                primeiroAudio.Stop();
            }
            else if (estado == EstadoTutorial.TocandoSegundoAudio)
            {
                segundoAudio.Stop();
            }
        }

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
                AudioPlaybackCoordinator.Play(segundoAudio);
                estado = EstadoTutorial.TocandoSegundoAudio;
                break;
            case EstadoTutorial.TocandoSegundoAudio when !segundoAudio.isPlaying:
                Time.timeScale = 1f;
                estado = EstadoTutorial.Concluido;
                SegundoAudioConcluido = true;
                break;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player") || contatoRegistrado || cicloJaIniciado ||
            estado != EstadoTutorial.AguardandoPlayer)
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
        contatoRegistrado = true;
        cicloJaIniciado = true;
        foreach (Collider plataformaCollider in GetComponentsInChildren<Collider>(true))
        {
            plataformaCollider.enabled = false;
        }

        Time.timeScale = 0f;
        AudioPlaybackCoordinator.Play(primeiroAudio);
        estado = EstadoTutorial.TocandoPrimeiroAudio;
    }
}
