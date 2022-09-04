using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public int m_seconds;
    public Text m_timer;
    public GameObject m_gameOver;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Countdown());
    }
    IEnumerator Countdown()
    {
        m_timer.text = string.Format("{0}", m_seconds.ToString("00"));

        while (m_seconds>0)
        {
            yield return new WaitForSeconds(1);
            m_seconds--;

            if (m_seconds<0)
            {
                m_seconds = 0;
            }
            m_timer.text = string.Format("{0}", m_seconds.ToString("00"));
        }
        yield return new WaitForSeconds(1);
        m_gameOver.SetActive(true);
        Time.timeScale = 0;
        GameManagerScript.instance.btnReturn.gameObject.SetActive(true);
    }
    
}
