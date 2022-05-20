using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour {

	public Dialogue dialogue;
	public bool DialogueOpen = false;

	public void TriggerDialogue ()
	{
		DialogueOpen = true;
		Cursor.visible = true;
		Cursor.lockState = CursorLockMode.Confined;
		FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
	}

}