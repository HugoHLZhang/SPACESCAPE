using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    #region
    public static Timer instanceTimer;

    private void Awake()
    {
        instanceTimer = this.GetComponent<Timer>();
    }
    #endregion

    [SerializeField] private DialogueTrigger Dialogue;
    private bool hasAlreadyOpenDialogue = false;

    public float time = 600f;
    void Start()
    {
        StartCoroutine(timer());
        Dialogue = GetComponentInChildren<DialogueTrigger>();
    }

    IEnumerator timer()
    {
        while (time > 0)
        {
            time--;
            yield return new WaitForSeconds(1f);
            GetComponent<Text>().text = string.Format("{0:0}:{1:00}", Mathf.Floor(time/60), time % 60);
            if (time == 597f && !hasAlreadyOpenDialogue)
            {
                Dialogue.TriggerDialogue();
                hasAlreadyOpenDialogue = true;
            }
        }
        
    }

    public void addTime(float TimeAdd)
    {
        if(time < 540f)
        {
            time = time + TimeAdd;
        }
        else
        {
            time = 600f;
        }
        
    }
}
