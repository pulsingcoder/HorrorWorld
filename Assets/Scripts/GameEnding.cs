using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameEnding : MonoBehaviour
{
    public float fadeDuration = 1f;
    public GameObject player;
    bool m_IsPlayerAtExit;
    float m_Timer;
    public CanvasGroup exitBackgroundImageCanvasGroup;
    public CanvasGroup caughtBackgroundImageCanvasGroup;
    bool m_IsPlayerCaught;
    public float displayImageDuration = 1f;
    public AudioSource exitAudio;
    public AudioSource caughtAudio;
    public AudioClip exitClip;
    bool m_HasAudioPlayed;

    // Start is called before the first frame update


    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject)
        {
            m_IsPlayerAtExit = true;

        }
    }

    // Update is called once per frame
    void Update()
    {
        if (m_IsPlayerAtExit)
        {
            EndLevel(exitBackgroundImageCanvasGroup, false, exitAudio);
        }
        else if (m_IsPlayerCaught)
        {
            EndLevel(caughtBackgroundImageCanvasGroup, true, caughtAudio);
        }
    }
    void EndLevel(CanvasGroup imageCanvasGroup, bool doRestart, AudioSource audioSource)
    {
        m_Timer += Time.deltaTime;
        imageCanvasGroup.alpha = m_Timer / fadeDuration;
        
        audioSource.PlayOneShot(exitClip);
        m_HasAudioPlayed = true;
        print("YEAH");
        if (m_Timer > fadeDuration + displayImageDuration)
        {
           // if (!m_HasAudioPlayed)
           // {
              

            //}
            if (doRestart)
            {
                SceneManager.LoadScene(0);
            }
            else
            {
                Application.Quit();
            }
            
            
        }
    }
    public void OnPlayerCaught()
    {
        m_IsPlayerCaught = true;
    }


}
