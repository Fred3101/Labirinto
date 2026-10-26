using UnityEngine;
using UnityEngine.SceneManagement;

public class InstrucaoInicialScript : MonoBehaviour
{
    private const string GameplaySceneName = "TutorialScene";

    void Awake()
    {
        if (SceneManager.GetActiveScene().name == GameplaySceneName)
        {
            gameObject.SetActive(false);
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            SceneManager.LoadScene(GameplaySceneName);
        }
    }
}
