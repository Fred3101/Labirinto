using System.Collections;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class AudioManager : MonoBehaviour
{
    private AudioSource audioSource;

    [Header("Configurações de Áudio")]
    [SerializeField] private AudioClip somAtual;
    [Header("Introdução do nível (opcional)")]
    [SerializeField] private AudioClip audioIntroducao;

    private bool introducaoConcluida;

    public bool IntroducaoConcluida => audioIntroducao == null || introducaoConcluida;

    void Awake()
    {
        // Garante a referência ao componente AudioSource do mesmo GameObject
        audioSource = GetComponent<AudioSource>();
        
        // Configurações iniciais padrão por código para evitar esquecimento no Inspector
        audioSource.playOnAwake = false; // Não toca sozinho ao iniciar
        audioSource.loop = false;        // Toca apenas uma vez por comando

        if (audioIntroducao != null)
        {
            StartCoroutine(TocarIntroducao());
        }
        else
        {
            introducaoConcluida = true;
        }
    }

    private IEnumerator TocarIntroducao()
    {
        AudioPlaybackCoordinator.PlayOneShot(audioSource, audioIntroducao);
        yield return new WaitWhile(() => audioSource.isPlaying);
        introducaoConcluida = true;
    }

    // COMANDO: Método público para ser chamado por outros scripts ou botões da UI
    public void TocarSom()
    {
        if (somAtual != null)
        {
            AudioPlaybackCoordinator.PlayOneShot(audioSource, somAtual);
        }
        else
        {
            Debug.LogWarning("Nenhum AudioClip foi definido no AudioManager!");
        }
    }

    public void TocarAudio(AudioClip audio)
    {
        if (audio == null)
        {
            Debug.LogWarning("Nenhum AudioClip foi definido para este áudio.", this);
            return;
        }

        AudioPlaybackCoordinator.PlayOneShot(audioSource, audio);
    }

    public void TocarAudioInicialDepois(
        AudioSource audioSourceInicial,
        AudioClip audioInicial,
        AudioClip audioSeguinte)
    {
        if (audioSourceInicial == null || audioInicial == null || audioSeguinte == null)
        {
            Debug.LogError("AudioManager precisa de um AudioSource e dos dois AudioClips configurados.", this);
            return;
        }

        StartCoroutine(TocarAudioInicialDepoisCoroutine(audioSourceInicial, audioInicial, audioSeguinte));
    }

    private IEnumerator TocarAudioInicialDepoisCoroutine(
        AudioSource audioSourceInicial,
        AudioClip audioInicial,
        AudioClip audioSeguinte)
    {
        AudioPlaybackCoordinator.PlayOneShot(audioSourceInicial, audioInicial);
        yield return new WaitWhile(() => audioSourceInicial.isPlaying);

        AtualizarSom(audioSeguinte);
    }

    // ATUALIZAÇÃO: Método para trocar o som atual do sistema em momentos específicos
    public void AtualizarSom(AudioClip novoSom)
    {
        if (novoSom != null)
        {
            somAtual = novoSom;
            Debug.Log($"O áudio do sistema foi atualizado para: {novoSom.name}");
        }
    }

    public void AtualizarSomETocar(AudioClip novoSom)
    {
        if (novoSom == null)
        {
            Debug.LogError("Não é possível atualizar e tocar um AudioClip nulo.", this);
            return;
        }

        somAtual = novoSom;
        AudioPlaybackCoordinator.PlayOneShot(audioSource, somAtual);
        Debug.Log($"O áudio do sistema foi atualizado e iniciado: {novoSom.name}");
    }
}
