using UnityEngine;

public class EscapeHoldQuit : MonoBehaviour
{
    private const float HoldDurationSeconds = 3f;

    private float heldDuration;
    private bool quitRequested;

    [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
    private static void Initialize()
    {
        GameObject quitObject = new GameObject(nameof(EscapeHoldQuit));
        DontDestroyOnLoad(quitObject);
        quitObject.AddComponent<EscapeHoldQuit>();
    }

    private void Update()
    {
        if (!Input.GetKey(KeyCode.Escape))
        {
            heldDuration = 0f;
            return;
        }

        heldDuration += Time.unscaledDeltaTime;
        if (heldDuration < HoldDurationSeconds || quitRequested)
        {
            return;
        }

        quitRequested = true;
        Application.Quit();

#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
    }
}
