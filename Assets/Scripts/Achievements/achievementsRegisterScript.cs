using UnityEngine;

public class achievementsRegisterScript : MonoBehaviour
{
    public bool erroCalculo = false;
    public bool usouRespawn = false;

    [Header("Áudios de conquista")]
    [SerializeField] private AudioClip audioSemErrosCalculo;
    [SerializeField] private AudioClip audioSemRespawn;
    [SerializeField] private AudioClip audioSemErrosNemRespawn;
    [SerializeField] private AudioClip audioComErrosCalculoERespawn;

    public void RegistrarErroCalculo()
    {
        erroCalculo = true;
    }

    public void RegistrarUsoRespawn()
    {
        usouRespawn = true;
    }

    public AudioClip ObterAudioConquista()
    {
        AudioClip audioConquista;
        string nomeConquista;

        if (!erroCalculo && !usouRespawn)
        {
            audioConquista = audioSemErrosNemRespawn;
            nomeConquista = "Sem erros de cálculo e sem respawn";
        }
        else if (!erroCalculo)
        {
            audioConquista = audioSemErrosCalculo;
            nomeConquista = "Sem erros de cálculo";
        }
        else if (!usouRespawn)
        {
            audioConquista = audioSemRespawn;
            nomeConquista = "Sem respawn";
        }
        else
        {
            audioConquista = audioComErrosCalculoERespawn;
            nomeConquista = "Com erros de cálculo e respawn";
        }

        if (audioConquista == null)
        {
            Debug.LogError($"Configure o áudio da conquista \"{nomeConquista}\" no achievementsRegisterScript.", this);
        }

        return audioConquista;
    }
}
