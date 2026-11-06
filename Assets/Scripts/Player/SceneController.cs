using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    private static readonly string[] sceneNames =
    {
        "InitialInstructionsScene",
        "TutorialScene",
        "Fase1Scene",
        "Fase2Scene",
        "Fase3Scene",
        "Fase4Scene"
    };

    private static readonly KeyCode[] sceneKeys =
    {
        KeyCode.F1,
        KeyCode.F2,
        KeyCode.F3,
        KeyCode.F4,
        KeyCode.F5,
        KeyCode.F6
    };

    private static SceneController instance;

    [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.SubsystemRegistration)]
    private static void ResetInstance()
    {
        instance = null;
    }

    [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
    private static void Initialize()
    {
        GameObject controllerObject = new GameObject(nameof(SceneController));
        DontDestroyOnLoad(controllerObject);
        controllerObject.AddComponent<SceneController>();
    }

    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
            return;
        }

        instance = this;
        DontDestroyOnLoad(gameObject);
    }

    private void Update()
    {
        for (int sceneIndex = 0; sceneIndex < sceneNames.Length; sceneIndex++)
        {
            if (Input.GetKeyDown(sceneKeys[sceneIndex]))
            {
                SceneManager.LoadScene(sceneNames[sceneIndex]);
                return;
            }
        }
    }
}
