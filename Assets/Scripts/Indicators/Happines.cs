using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using TMPro;

public class Happines : MonoBehaviour
{
    public static Happines Instance {  get; private set; }
    [SerializeField] private TMP_Text happinesText;
    [SerializeField] private GameObject profileWindow;
    public int playerHappines {  get; private set; }
    public int playerDept { get; private set; }

    private void Start()
    {
        Instance = this;
        happinesText.text = playerHappines.ToString();
    }
    
    private void Update()
    {
        happinesText.text = $"{playerHappines.ToString()}";
        if (Input.GetKeyDown(KeyCode.M))
        {
            AddHappines(100);
        }
    }

    public void AddHappines(int amount)
    {
        int startHappines = playerHappines;
        playerHappines += amount;
        AnimateProfileWindow();
        AnimateText(startHappines, playerHappines);
    }

    public void SubstructHappines(int amount)
    {
        int startHappines = playerHappines;
        playerHappines -= amount;
        AnimateProfileWindow();
        AnimateText(startHappines, playerHappines);
    }

    private void AnimateText(int startValue, int endValue)
    {
        DOVirtual.Int(startValue, endValue, 1f, value =>
        {
            happinesText.text = value.ToString();
        });
    }

    private void AnimateProfileWindow()
    {
        profileWindow?.transform.DOShakePosition(0.5f, new Vector3(0, 10, 0), 10, 90, false, true);
    }
}
