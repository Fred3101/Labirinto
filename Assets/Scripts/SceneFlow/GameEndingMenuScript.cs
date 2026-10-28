using UnityEngine;
using UnityEngine.SceneManagement;

public class GameEndingMenuScript : MonoBehaviour
{
    private const string TutorialSceneName = "TutorialScene";

    [SerializeField] private GameObject endingCanvas;
    [SerializeField] private AudioClip finalNarracao;

    private AudioSource narrationAudioSource;
    private bool isOpen;

    private void Awake()
    {
        narrationAudioSource = gameObject.AddComponent<AudioSource>();
        narrationAudioSource.playOnAwake = false;
        narrationAudioSource.loop = false;
        narrationAudioSource.spatialBlend = 0f;

        if (endingCanvas == null)
        {
            Debug.LogError("Configure o canvas de encerramento no GameEndingMenuScript.", this);
            return;
        }

        endingCanvas.SetActive(false);
    }

    private void Update()
    {
        if (!isOpen)
        {
            return;
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            ReiniciarTutorial();
        }
    }

    public void Abrir()
    {
        if (endingCanvas == null)
        {
            Debug.LogError("Não é possível abrir o menu: o canvas de encerramento não foi configurado.", this);
            return;
        }

        isOpen = true;
        endingCanvas.SetActive(true);
        Time.timeScale = 0f;
        Cursor.visible = true;

        if (finalNarracao == null)
        {
            Debug.LogError("Configure o áudio FinalNarracao no GameEndingMenuScript.", this);
        }
        else
        {
            AudioPlaybackCoordinator.PlayOneShot(narrationAudioSource, finalNarracao);
        }

        Canvas canvas = endingCanvas.GetComponent<Canvas>();
        if (canvas != null)
        {
            canvas.overrideSorting = true;
            canvas.sortingOrder = 100;
        }

        MonoBehaviour[] behaviours =
            FindObjectsByType<MonoBehaviour>(FindObjectsSortMode.None);
        Transform canvasTransform = endingCanvas.transform;

        foreach (MonoBehaviour behaviour in behaviours)
        {
            if (behaviour == null ||
                behaviour == this ||
                behaviour is EscapeHoldQuit ||
                behaviour.transform == canvasTransform ||
                behaviour.transform.IsChildOf(canvasTransform))
            {
                continue;
            }

            behaviour.enabled = false;
        }
    }

    private void ReiniciarTutorial()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(TutorialSceneName);
    }
}
