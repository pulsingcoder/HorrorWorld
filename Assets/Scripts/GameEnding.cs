using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameEnding : MonoBehaviour
{
    public float fadeDuration = 1f;
    public GameObject player;
    bool m_IsPlayerAtExit;
    float m_Timer;
    public CanvasGroup exitBackgroundImageCanvasGroup;
    public float displayImageDuration = 1f;
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
            EndLevel();
        }
    }
    void EndLevel()
    {
        m_Timer += Time.deltaTime;
        exitBackgroundImageCanvasGroup.alpha = m_Timer / fadeDuration;
        if (m_Timer > fadeDuration + displayImageDuration)
        {
            Application.Quit();
        }
    }

}
