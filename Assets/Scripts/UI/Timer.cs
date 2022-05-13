using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public float time = 600f;
    void Start()
    {
        StartCoroutine(timer());
    }

    IEnumerator timer()
    {
        while (time > 0)
        {
            time--;
            yield return new WaitForSeconds(1f);
            GetComponent<Text>().text = string.Format("{0:0}:{1:00}", Mathf.Floor(time/60), time % 60);
        }
    }
}
