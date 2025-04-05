using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using TMPro;

public class Balance : MonoBehaviour
{
    public static Balance Instance {  get; private set; }
    [SerializeField] private TMP_Text balanceText;
    [SerializeField] private TMP_Text deptBalanceText;
    [SerializeField] private GameObject profileWindow;
    public int playerBalance {  get; private set; }
    public int playerDept { get; private set; }

    private void Start()
    {
        Instance = this;
        playerBalance = 120000;
        playerDept = 200000;
        balanceText.text = playerBalance.ToString();
    }
    
    private void Update()
    {
        balanceText.text = $"{playerBalance.ToString()}$";
        if (Input.GetKeyDown(KeyCode.M))
        {
            AddBalance(100);

        }
    }

    public void AddBalance(int amount)
    {
        int startBalance = playerBalance;
        playerBalance += amount;
        AnimateProfileWindow();
        AnimateText(startBalance, playerBalance);
    }

    public void SubstructBalance(int amount)
    {
        int startBalance = playerBalance;
        playerBalance -= amount;

        if (playerBalance < 0)
        {
            playerDept += Mathf.Abs(playerBalance);
            playerBalance = 0;
        }

        AnimateProfileWindow();
        AnimateText(startBalance, playerBalance);
        deptBalanceText.text = $"{playerDept}$";
    }


    public void AddDept(int amount){
        int startDept = playerDept;
        playerDept += amount;
        AnimateProfileWindow();
        AnimateText(startDept, playerDept);
    }

    public void SubstructDept(int amount)
    {
        int startDept = playerDept;
        playerDept -= amount;

        if (playerDept < 0)
        {
            playerBalance += Mathf.Abs(playerDept);
            playerDept = 0;
        }

        AnimateProfileWindow();
        AnimateText(startDept, playerDept);
        deptBalanceText.text = $"{playerDept}$";
    }

    private void AnimateText(int startValue, int endValue)
    {
        DOVirtual.Int(startValue, endValue, 1f, value =>
        {
            balanceText.text = $"{value.ToString()}$";
        });
    }

    private void AnimateProfileWindow()
    {
        profileWindow?.transform.DOShakePosition(0.5f, new Vector3(0, 10, 0), 10, 90, false, true);
    }
}
