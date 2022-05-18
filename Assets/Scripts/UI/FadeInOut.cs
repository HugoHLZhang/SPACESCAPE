using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class FadeInOut : MonoBehaviour
{
    private bool isFaded = true;
    public float Duration = 0.3f;

    public void Fade()
    {
        var canvGroup = GetComponent<CanvasGroup>();
        if(isFaded)
            StartCoroutine(DoFade(canvGroup, canvGroup.alpha, 1f));
        else
            StartCoroutine(DoFade(canvGroup, canvGroup.alpha, 0f));
        isFaded = !isFaded;
        Debug.Log("isFaded : " + isFaded);
    }

    public IEnumerator DoFade(CanvasGroup canvGroup, float start, float end)
    {
        float counter = 0f;

        while(counter < Duration)
        {
            counter += Time.deltaTime;
            canvGroup.alpha = Mathf.Lerp(start, end, counter / Duration);

            yield return null;
        }
    }
}
