using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using Game.DialogeSystem.UI;
using TMPro;

public class HelloPanel : MonoBehaviour
{
    [Header("UI Elements")]
    public GameObject introPanel;
    public TMP_Text titleText;
    public TMP_Text mainText;
    public TMP_Text continuePrompt;

    [Header("Settings")]
    public float typingSpeed = 0.03f;
    public float delayBetweenMessages = 0.5f;
    public float paragraphPause = 1.5f;

    [Header("Content")]
    public string titleMessage = "Привіт, друже!";
    
    [TextArea(3, 10)]
    public List<string> introParagraphs = new List<string>()
    {
        "Ви — Андрій Коваленко, звичайний чоловік, який все життя жив «одним днем». Кредити на непотрібні речі, постійні позики у друзів, сварки з родиною через гроші… Але сьогодні все зміниться!",
        
        "Лист від дідуся\nВи щойно дізналися, що ваш покійний дідусь, який колись був приватним підприємцем, залишив вам $120,000 у спадок. У листі він написав:\n\n«Андрію, гроші — це інструмент. Вони можуть зруйнувати тебе або дати свободу. Вибирай розумно.»",
        
        "Ваше завдання\n- Розпорядитися грошима (погасити борги? інвестувати? купити щось для родини?)\n- Втримати родину (Анна хоче стабільності, Денис мріє про новий комп'ютер, сестра Ніколь просить позики)\n- Не повторити минулих помилок (але спокуси на кожному кроці!)",
        
        "⚡ Обережно!\n- Банки, колектори, шахраї — усі хочуть ваші гроші.\n- Ризикові друзі — пропонують «гарячі» схеми.\n- Ваші слабкості — чи втримаєтесь, щоб не купити новий телефон «зараз, бо sale»?",
        
        "5 можливих кінцівок\n1. Фінансова стабільність (але втрачена молодість)\n2. Банкрутство (але ви навчилися)\n3. Сімейний розкол (гроші є, але родини немає)\n4. Ризикований успіх (мільйонер-самотняк)\n5. Довічні борги (пастка кредитів)",
        
        "Порада від дідуся:\n«Не дивись на цифри — дивись на те, що вони тобі дають. І не забувай, хто ти є.»"
    };

    private bool isTyping = false;
    private bool messageComplete = false;
    private int currentParagraphIndex = 0;
    private Coroutine typingCoroutine;

    void Start()
    {
        continuePrompt.gameObject.SetActive(false);
        titleText.text = titleMessage;
        StartCoroutine(ShowIntroSequence());
        DialogeUI.IsOPen = true;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (isTyping)
            {
                StopCoroutine(typingCoroutine);
                mainText.text = introParagraphs[currentParagraphIndex];
                isTyping = false;
                messageComplete = true;
                continuePrompt.gameObject.SetActive(true);
            }
            else if (messageComplete)
            {
                continuePrompt.gameObject.SetActive(false);
                messageComplete = false;
                
                if (currentParagraphIndex < introParagraphs.Count - 1)
                {
                    currentParagraphIndex++;
                    typingCoroutine = StartCoroutine(TypeText(introParagraphs[currentParagraphIndex]));
                }
                else
                {
                    StartCoroutine(CompleteIntro());
                }
            }
        }
    }

    IEnumerator ShowIntroSequence()
    {
        introPanel.SetActive(true);
        yield return new WaitForSeconds(1f);
        typingCoroutine = StartCoroutine(TypeText(introParagraphs[currentParagraphIndex]));
    }

    IEnumerator TypeText(string paragraph)
    {
        isTyping = true;
        mainText.text = "";
        continuePrompt.gameObject.SetActive(false);

        string[] lines = paragraph.Split('\n');
        
        for (int i = 0; i < lines.Length; i++)
        {
            string line = lines[i];
            
            foreach (char letter in line.ToCharArray())
            {
                mainText.text += letter;
                yield return new WaitForSeconds(typingSpeed);
            }
            
            if (i < lines.Length - 1)
            {
                mainText.text += "\n";
                yield return new WaitForSeconds(typingSpeed * 5);
            }
        }

        isTyping = false;
        messageComplete = true;
        continuePrompt.gameObject.SetActive(true);
    }

    IEnumerator CompleteIntro()
    {
        mainText.text = "Удачної гри!";
        continuePrompt.gameObject.SetActive(false);
        
        yield return new WaitForSeconds(2f);
        
        introPanel.SetActive(false);
        DialogeUI.IsOPen = false;
    }
}