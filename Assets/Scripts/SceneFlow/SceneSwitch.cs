using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(AudioSource))]
public class SceneSwitch : MonoBehaviour
{
    
    private AudioSource audioSource;
    public MouseLook player; 
    private bool hasTriggered = false;
    private bool audioHasPlayed = false;
    public int sceneToLoad = 1; // Defina o índice da cena que deseja carregar

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (audioHasPlayed && !audioSource.isPlaying && !hasTriggered)
        {
            hasTriggered = true;
            Debug.Log("Mudando de fase");
            StartCoroutine(CarregarFaseAposAudioDeConquista());
        }
    }

    private IEnumerator CarregarFaseAposAudioDeConquista()
    {
        achievementsRegisterScript registroConquistas =
            FindFirstObjectByType<achievementsRegisterScript>();

        if (registroConquistas == null)
        {
            Debug.LogError("Configure um achievementsRegisterScript ativo na fase.", this);
        }
        else
        {
            AudioClip audioConquista = registroConquistas.ObterAudioConquista();
            if (audioConquista != null)
            {
                AudioPlaybackCoordinator.PlayOneShot(audioSource, audioConquista);
                yield return new WaitWhile(() => audioSource.isPlaying);
            }
        }

        yield return new WaitForSecondsRealtime(2f);
        SceneManager.LoadScene(sceneToLoad);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !audioHasPlayed && !hasTriggered)
        {

            player.canMove = false;
            AudioPlaybackCoordinator.Play(audioSource);
            audioHasPlayed = true;

        }
    }
}
