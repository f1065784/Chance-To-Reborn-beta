using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomInitilizeIndicators : MonoBehaviour
{
    [SerializeField] private int addToBalance;
    [SerializeField] private int substractToBalance;

    [SerializeField] private int addToDept;
    [SerializeField] private int substractToDept;

    [SerializeField] private int addToHappiness;
    [SerializeField] private int substartToHappiness;
    
    public void Start()
    {
        Balance.Instance.AddBalance(addToBalance);
        Balance.Instance.SubstructBalance(substractToBalance);

        Balance.Instance.AddDept(addToDept);
        Balance.Instance.SubstructDept(substractToDept);

        Happines.Instance.AddHappines(addToHappiness);
        Happines.Instance.SubstructHappines(substartToHappiness);
    }
}
