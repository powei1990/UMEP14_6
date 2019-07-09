using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class DialogueManager : MonoBehaviour
{
    [SerializeField]
    private Text nameText;
    [SerializeField]
    private Text dialogueText;
    [SerializeField]
    private GameObject confirmButton;
    [SerializeField]
    private GameObject nextButton;

    private Queue<string> sentences;
    private ViewChanger viewChanger;

    // Use this for initialization
    void Start()
    {
        sentences = new Queue<string>();
        viewChanger = FindObjectOfType<ViewChanger>();
    }

    // Update is called once per frame

    private void Update()
    {
        if (sentences.Count == 0)
        {
            confirmButton.SetActive(true);
            return;
        }
        else
        {
            nextButton.SetActive(true);
            confirmButton.SetActive(false);
        }
    }

    public void StartDialogue(Dialogue dialogue)
    {
        //Debug.Log("Starting conversation with" + dialogue.name);

        nameText.text = dialogue.name;

        sentences.Clear();
        foreach (string sentence in dialogue.sentences)
        {
            sentences.Enqueue(sentence);//在對列後面增加句子
        }

        DisplayNextSentence();
    }

    public void DisplayNextSentence()
    {
        //if (sentences.Count == 0)
        //{
        //    confirmButton.SetActive(true);
        //    return;
        //}
        //else
        //{
        //    nextButton.SetActive(true);
        //    confirmButton.SetActive(false);
        //}
        string sentence = sentences.Dequeue();//移除對列最前面句子

        dialogueText.text = sentence;


        //Debug.Log(sentence);
        //StopAllCoroutines();
        //StartCoroutine(TypeSentence(sentence));

    }

    //逐字顯示
    //IEnumerator TypeSentence(string sentence)
    //{
    //    dialogueText.text = "";
    //    foreach (char letter in sentence.ToCharArray())

    //    {
    //        dialogueText.text += letter;
    //        yield return null;
    //    }

    //}

    public void EndDialogue()
    {
        FindObjectOfType<DialogueTrigger>().SetIsTalked();
        viewChanger.GamePlay();
        Debug.Log("End of conversation");
    }

}
