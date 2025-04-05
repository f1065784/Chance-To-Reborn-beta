using System.Collections;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class End : MonoBehaviour
{
    [SerializeField] private TMP_Text descriptionText;
    [SerializeField] private GameObject endScreen;
    [SerializeField] private CanvasGroup endScreenCanvasGroup;

    void Start()
    {
        PlayerPrefs.SetInt("enteredToEndRoom", 0);
        endScreen.SetActive(false);
        endScreenCanvasGroup.alpha = 0;
    }

    void Update()
    {
        if(CheckPlayerPrefsValue("enteredToEndRoom")){
            switch(DeterminationofEnd())
            {
                case 1:
                    descriptionText.text = "Ви досягли безпеки: велика частина боргів погашена, рахунки наповнені, родина забезпечена. Але ціною стали відмова від мрій - ваші сміливі ідеї так і залишились на папері, друзі називають вас 'нудним бухгалтером', а Денис вже не розповідає вам про свої креативні проекти. Ви виграли гру, але програли себе.";
                    OpenEndScreen(endScreenCanvasGroup);
                    break;
                case 2:
                    descriptionText.text = "Ви залишились з нулем: квартира продана, родина роз’їхалась, кредитори пишуть зловісні листи. Але... ви отримали безцінний досвід. Тепер ви знаєте, як НЕ треба поводитись з грошима. Можливо, саме цей провал стане початком нової історії?";
                    OpenEndScreen(endScreenCanvasGroup);
                    break;
                case 3:
                    descriptionText.text = "Ваші рішення зруйнували родину: Анна з Денисом живуть окремо, ви залишились сам із грудою дорогих речей. Гроші є, але немає кому сказати 'добраніч'. Ви грали, щоб забезпечити їх, але втратили саме те, заради чого грали";
                    OpenEndScreen(endScreenCanvasGroup);
                    break; 
                case 4:
                    descriptionText.text = "Ви мільйонер! Ваші авантюри окупились стократ. Але ці цифри на рахунку - все, що у вас залишилось. Анна не розмовляє з вами після останньої угоди, Денис вчиться за кордоном і не відповідає на дзвінки. Ви виграли капітал, але програли родину.";
                    OpenEndScreen(endScreenCanvasGroup);
                    break;
                case 5:
                    descriptionText.text = "Ви в пастці: 80% доходу йде на відсотки, кожен дзвінок - це колектор, ви спите з розрахунками під подушкою. Але... ви знаєте кожну помилку, кожен хибний крок. Можливо, саме ці знання допоможуть вам почати все з нуля? Історія ще не закінчена.";
                    OpenEndScreen(endScreenCanvasGroup);
                    break;
                default:
                    break;
            }
        }
    }

    private int DeterminationofEnd(){
        if(CheckPlayerPrefsValue("ChooseEnding1Path")) return 1;
        if(CheckPlayerPrefsValue("ChooseEnding2Path")) return 2;
        if(CheckPlayerPrefsValue("ChooseEnding3Path")) return 3;
        if(CheckPlayerPrefsValue("ChooseEnding4Path")) return 4;
        if(CheckPlayerPrefsValue("ChooseEnding5Path")) return 5;
        else return 0;
    }

    public bool CheckPlayerPrefsValue(string key)
    {
        //Debug.Log(PlayerPrefs.GetInt(key, 0) == 1);
        return PlayerPrefs.GetInt(key, 0) == 1;
    }
    
    private void OpenEndScreen(CanvasGroup screen){
        endScreen.SetActive(true);
        StartCoroutine(FadeIn(screen, 1f));
    }

    private IEnumerator FadeIn(CanvasGroup screen, float duration)
    {
        float startAlpha = screen.alpha;
        float time = 0;

        while (time < duration)
        {
            time += Time.deltaTime;
            screen.alpha = Mathf.Lerp(startAlpha, 1f, time / duration);
            yield return null;
        }

        screen.alpha = 1f;
    }

    public void GoToMainMenu(){
        SceneManager.LoadScene(0);
    }

    public void RestartGame(){
        SceneManager.LoadScene(1);
    }
}
