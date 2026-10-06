using UnityEngine;

public class MenuPauseScript : MonoBehaviour
{

    [SerializeField] private GameObject menu;

    void Start()
    {
        PausarJogo();
    }

    public void PausarJogo()
    {
        menu.SetActive(true);
        Time.timeScale = 0f;
    }

    public void RetomarJogo()
    {
        menu.SetActive(false);
        Time.timeScale = 1f;
    }
}
