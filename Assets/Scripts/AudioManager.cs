using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class AudioManager : MonoBehaviour
{
    private AudioSource audioSource;

    [Header("Configurações de Áudio")]
    [SerializeField] private AudioClip somAtual;

    void Awake()
    {
        // Garante a referência ao componente AudioSource do mesmo GameObject
        audioSource = GetComponent<AudioSource>();
        
        // Configurações iniciais padrão por código para evitar esquecimento no Inspector
        audioSource.playOnAwake = false; // Não toca sozinho ao iniciar
        audioSource.loop = false;        // Toca apenas uma vez por comando
    }

    // COMANDO: Método público para ser chamado por outros scripts ou botões da UI
    public void TocarSom()
    {
        if (somAtual != null)
        {
            // PlayOneShot permite que o som termine de tocar mesmo se o comando for repetido rapidamente
            audioSource.PlayOneShot(somAtual);
        }
        else
        {
            Debug.LogWarning("Nenhum AudioClip foi definido no AudioManager!");
        }
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
}
