using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Events : MonoBehaviour
{
    #region playerprefs
    private void Awake()
    {
        // 2
        PlayerPrefs.SetInt("ChooseBankPath", 0); 
        // 4
        PlayerPrefs.SetInt("ChooseMarketPath", 0);
        // 5
        PlayerPrefs.SetInt("ChooseFamilyRoomPath", 0);
        // 6
        PlayerPrefs.SetInt("ChooseFriendVadimPath", 0);
        // 9
        PlayerPrefs.SetInt("ChooseNewBuisnessPath", 0);
        // 10
        PlayerPrefs.SetInt("ChooseCrisisPath", 0);
        // 11
        PlayerPrefs.SetInt("ChooseStabilityPath", 0);
        // 12
        PlayerPrefs.SetInt("ChooseConflictPath", 0);
        // 13
        PlayerPrefs.SetInt("ChooseAddvertismentPath", 0);
        // 14
        PlayerPrefs.SetInt("ChooseSuccessfulInvestment", 0);
        // 18
        PlayerPrefs.SetInt("ChooseHelpFriendPath", 0);
        // 19
        PlayerPrefs.SetInt("ChooseLossFamilyPath", 0);
        // 20
        PlayerPrefs.SetInt("ChooseSocialProjectPath", 0);
        // 21
        PlayerPrefs.SetInt("ChooseUnexpectedPresentPath", 0);
        // 22
        PlayerPrefs.SetInt("ChoosePolicePath", 0);
        // 23
        PlayerPrefs.SetInt("ChooseNewCreditsPath", 0);
        // 24
        PlayerPrefs.SetInt("ChooseFinanceAssistantPath", 0);
        // 27
        PlayerPrefs.SetInt("ChooseCharityPath", 0);
        // 28
        PlayerPrefs.SetInt("ChooseStartupInvestmentPath", 0);
        // 29
        PlayerPrefs.SetInt("ChoosePensionFundPath", 0);
        // 30
        PlayerPrefs.SetInt("ChooseLastChancePath", 0);
        // 31
        PlayerPrefs.SetInt("ChooseResultOfStartup", 0);
        // 34
        PlayerPrefs.SetInt("ChooseResultOfPresentPath", 0);

        // ends
        PlayerPrefs.SetInt("ChooseEnding1Path", 0);
        PlayerPrefs.SetInt("ChooseEnding2Path", 0);
        PlayerPrefs.SetInt("ChooseEnding3Path", 0);
        PlayerPrefs.SetInt("ChooseEnding4Path", 0);
        PlayerPrefs.SetInt("ChooseEnding5Path", 0);
        
    }
    #endregion
     




    #region Room_1_Legacy
        public void ChooseMarketPath_Room_4()
        {
            PlayerPrefs.SetInt("ChooseMarketPath", 1);
            PlayerPrefs.SetInt("ChooseBankPath", 0);
        }
        public void ChooseBankPath_Room_2()
        {
            PlayerPrefs.SetInt("ChooseMarketPath", 0);
            PlayerPrefs.SetInt("ChooseBankPath", 1);
        }
    
    #endregion
  

    #region Room_2_Bank
        public void ChooseFamilyRoomPath_Room_5()
        {
            Balance.Instance.SubstructDept(100000); 
            Balance.Instance.SubstructBalance(100000);
            PlayerPrefs.SetInt("ChooseFamilyRoomPath", 1);
            PlayerPrefs.SetInt("ChooseFriendVadimPath", 0);
        }
        public void ChooseFriendVadimPath_Room_6()
        {
            Balance.Instance.SubstructDept(50000); 
            Balance.Instance.SubstructBalance(50000);
            PlayerPrefs.SetInt("ChooseFamilyRoomPath", 0);
            PlayerPrefs.SetInt("ChooseFriendVadimPath", 1);
        }
    #endregion






    #region Room_4_Market                                                                                               

        public void ChooseNewBuisnessPath_Room_9()
        {
            PlayerPrefs.SetInt("ChooseNewBuisnessPath", 1);
            PlayerPrefs.SetInt("ChooseCrisisPath", 0);
        }
        public void ChooseCrisisPath_Room_10()
        {
            PlayerPrefs.SetInt("ChooseNewBuisnessPath", 0);
            PlayerPrefs.SetInt("ChooseCrisisPath", 1);
        }

    #endregion
    




    #region Room_5_Family

        public void ChooseStabilityPath_Room_11()
        {
            Balance.Instance.SubstructBalance(30000);
            Happines.Instance.AddHappines(35);
            PlayerPrefs.SetInt("ChooseStabilityPath", 1);
            PlayerPrefs.SetInt("ChooseConflictPath", 0);
            
        }
        public void ChooseConflictPath_Room_12()
        {
            Happines.Instance.SubstructHappines(35);
            PlayerPrefs.SetInt("ChooseStabilityPath", 0);
            PlayerPrefs.SetInt("ChooseConflictPath", 1);
        }

    #endregion





    #region Room_6_FreindVadym
        public void ChooseAddvertismentPath_Room_13()
        {
            Balance.Instance.SubstructBalance(30000);
            Happines.Instance.AddHappines(35);
            PlayerPrefs.SetInt("ChooseAddvertismentPath", 1);
            PlayerPrefs.SetInt("ChooseSuccessfulInvestment", 0);
        }
        public void ChooseSuccessfulInvestment_Room_14()
        {
            Happines.Instance.SubstructHappines(35);
            PlayerPrefs.SetInt("ChooseAddvertismentPath", 0);
            PlayerPrefs.SetInt("ChooseSuccessfulInvestment", 1);
        }
    #endregion
    




    #region Room_9_NewBuisness
        public void ChooseHelpFriendPath_Room_18()
        {
            Balance.Instance.SubstructBalance(50000);
            Happines.Instance.AddHappines(35);
            PlayerPrefs.SetInt("ChooseHelpFriendPath", 1);
            PlayerPrefs.SetInt("ChooseLossFamilyPath", 0);
        }
        public void ChooseLossFamilyPath_Room_19()
        {
            Happines.Instance.SubstructHappines(35);
            PlayerPrefs.SetInt("ChooseHelpFriendPath", 0);
            PlayerPrefs.SetInt("ChooseLossFamilyPath", 1);
        }
    #endregion





    #region Room_10_Crysis
        public void ChooseSocialProjectPath_Room_20()
        {
            Happines.Instance.SubstructHappines(50);
            PlayerPrefs.SetInt("ChooseSocialProjectPath", 1);
            Debug.Log("SocialProjectPath_Room_20 is" + CheckPlayerPrefsValue("SocialProjectPath_Room_20"));
        }
    #endregion





    #region Room_11_Stability
        // end 1 logic
    #endregion




  
    #region Room_12_Conflict
        public void ChooseUnexpectedPresentPath_Room_21()
        {
            Happines.Instance.SubstructHappines(50);
            PlayerPrefs.SetInt("ChooseUnexpectedPresentPath", 1);
        }
    #endregion





    #region Room_13_Addvertisment
        public void ChoosePolicePath_Room_22(){
            Balance.Instance.SubstructBalance(30000);
            PlayerPrefs.SetInt("ChoosePolicePath", 1);
            PlayerPrefs.SetInt("ChooseNewCreditsPath", 0);
        }
        public void ChooseNewCreditsPath_Room_23()
        {
            PlayerPrefs.SetInt("ChoosePolicePath", 0);
            PlayerPrefs.SetInt("ChooseNewCreditsPath", 1);
        }

        
    #endregion





    #region Room_14_SuccessfulInvestment
        public void ChooseFinanceAssistantPath_Room_24()
        {
            Balance.Instance.AddBalance(30000);
            Happines.Instance.AddHappines(50);
            PlayerPrefs.SetInt("ChooseFinanceAssistantPath", 1);
            Debug.Log("FinanceAssistantPath_Room_24 is " + CheckPlayerPrefsValue("ChooseFinanceAssistantPath"));
        }
    #endregion






    #region Room_18_HelpFriend 
        public void ChooseStartupPath_Room_28()
        {
            Balance.Instance.SubstructBalance(30000);
            PlayerPrefs.SetInt("ChooseStartupPath", 1);
            PlayerPrefs.SetInt("ChoosePensionFundPath", 0);
        }
        public void ChoosePensionFundPath_Room_29()
        {
            Happines.Instance.SubstructHappines(20);
            PlayerPrefs.SetInt("ChooseStartupPath", 0);
            PlayerPrefs.SetInt("ChoosePensionFundPath", 1);
        }
    #endregion





    #region Room_19_FamilyLoose
        // end 2
    #endregion
    





    #region Room_20_SocialProject

        public void ChooseLastChancePath_Room_30()
        {
            Happines.Instance.AddHappines(50);
            Balance.Instance.SubstructBalance(10000);
            PlayerPrefs.SetInt("ChooseLastChancePath", 1);
        }

    #endregion

    



    #region Room_21_UnexpectedPresentPath
        public void ChooseResultOfPresentPath_Room_34()
        {
            int randomNum = UnityEngine.Random.Range(1, 100);
            if(randomNum > 50)
            {
                PlayerPrefs.SetInt("ChooseEnding1Path", 1);
                PlayerPrefs.SetInt("ChooseCrisisPath", 0);
            }
            else
            {
                PlayerPrefs.SetInt("ChooseEnding1Path", 0);
                PlayerPrefs.SetInt("ChooseCrisisPath", 1);
            }
        }
        // room 30
    #endregion





    #region Room_22_PolicePath
        // end logic
    #endregion
    



    
    #region Room_23_NewCredits
        // end 5

        public void ChooseCharityPath_Room_27()
        {
            
            PlayerPrefs.SetInt("ChooseEnding5Path", 0);
            PlayerPrefs.SetInt("ChooseCharityPath", 1);
        }

    #endregion





    #region Room_24_Assistant
        // end 1

        public void ChooseStartupInvestmentPath_Room_28()
        {
            
            PlayerPrefs.SetInt("ChooseEnding1Path", 0);
            PlayerPrefs.SetInt("ChooseStartupInvestmentPath", 1);
        }
    #endregion 
    
    
    
    

    #region Room_27_Charity
        /* 
            end 1
        */
        
        /* 
            ChooseRoom30_LastChance
        */
    #endregion
    

    

    #region Room_28_StartupInvestion
        public void ChooseResultOfStartupPath_Room_31()
        {
            Balance.Instance.SubstructBalance(40000);
            int randomNum = UnityEngine.Random.Range(1, 100);
            if(randomNum > 50)
            {
                PlayerPrefs.SetInt("ChooseEnding1Path", 0);
                PlayerPrefs.SetInt("ChooseCrisisPath", 1);
            }
            else
            {
                PlayerPrefs.SetInt("ChooseEnding1Path", 1);
                PlayerPrefs.SetInt("ChooseCrisisPath", 0);
            }
            PlayerPrefs.SetInt("ChoosePensionFundPath", 0);
        }
        public void ChoosePensionPath()
        {
            PlayerPrefs.SetInt("ChooseResultOfStartupPath", 0);
            PlayerPrefs.SetInt("ChoosePensionFundPath", 1);
        }
    #endregion





    #region Room_30_LastChance
        /* 
            end 1
        */
        
        /* 
            end 5
        */
    
    #endregion
    
    


    #region Room_31_StartupResult
        
        
        /*
            // CrysisPath_Room_10
        */

        /*
            // end 1
        */
    #endregion 






    #region Room_34_PresentResult
        /*
            // end 1
        */
        /*
            // CrysisPath_Room_10
        */
    #endregion





    #region endings 
        public void ChooseEnding1Path()
        {
            PlayerPrefs.SetInt("ChooseEnding1Path", 1);
        }
        public void ChooseEnding2Path()
        {
            PlayerPrefs.SetInt("ChooseEnding2Path", 1);
        }
        public void ChooseEnding3Path()
        {
            PlayerPrefs.SetInt("ChooseEnding3Path", 1);
        }
        public void ChooseEnding4Path()
        {
            PlayerPrefs.SetInt("ChooseEnding4Path", 1);
        }
        public void ChooseEnding5Path()
        {
            PlayerPrefs.SetInt("ChooseEnding5Path", 1);
        }
    #endregion






    #region Conditions
        // Room 1 - legacy
        public bool IsRoom_ONE_Ready()
        {
            return true;
        }

        // Room 2
        public bool IsRoom_TWO_Ready()
        {
            return CheckPlayerPrefsValue("ChooseBankPath");
        }

        // Room 4
        public bool IsRoom_FOUR_Ready()
        {
            return CheckPlayerPrefsValue("ChooseMarketPath");
        }

        // Room 5
        public bool IsRoom_FIVE_Ready()
        {
            return CheckPlayerPrefsValue("ChooseFamilyRoomPath");
        }

        // Room 6
        public bool IsRoom_SIX_Ready()
        {
            return CheckPlayerPrefsValue("ChooseFriendVadimPath");
        }

        // Room 9
        public bool IsRoom_NINE_Ready()
        {
            return CheckPlayerPrefsValue("ChooseNewBuisnessPath");
        }

        // Room 10
        public bool IsRoom_TEN_Ready()
        {
            return CheckPlayerPrefsValue("ChooseCrisisPath");
        }

        // Room 11
        public bool IsRoom_ELEVEN_Ready()
        {
            return CheckPlayerPrefsValue("ChooseStabilityPath");
        }

        // Room 12
        public bool IsRoom_TWELVE_Ready()
        {
            return CheckPlayerPrefsValue("ChooseConflictPath");
        }

        // Room 13
        public bool IsRoom_THIRTEEN_Ready()
        {
            return CheckPlayerPrefsValue("ChooseAddvertismentPath");
        }

        // Room 14
        public bool IsRoom_FOURTEEN_Ready()
        {
            return CheckPlayerPrefsValue("ChooseSuccessfulInvestment");
        }

        // Room 18
        public bool IsRoom_EIGHTEEN_Ready()
        {
            return CheckPlayerPrefsValue("ChooseHelpFriendPath");
        }

        // Room 19
        public bool IsRoom_NINETEEN_Ready()
        {
            return CheckPlayerPrefsValue("ChooseLossFamilyPath");
        }

        // Room 20
        public bool IsRoom_TWENTY_Ready(){
            return CheckPlayerPrefsValue("ChooseSocialProjectPath");
        }

        // Room 21
        public bool IsRoom_TWENTY_ONE_Ready(){
            return CheckPlayerPrefsValue("ChooseUnexpectedPresentPath");
        }

        // Room 22
        public bool IsRoom_TWENTY_TWO_Ready(){
            return CheckPlayerPrefsValue("ChoosePolicePath");
        }

        // Room 23
        public bool IsRoom_TWENTY_THREE_Ready(){
            return CheckPlayerPrefsValue("ChooseNewCreditsPath");
        }

        // Room 24
        public bool IsRoom_TWENTY_FOUR_Ready(){
            Debug.Log("FinanceAssistantPath_Room_24 is " + CheckPlayerPrefsValue("FinanceAssistantPath_Room_24"));  
            return CheckPlayerPrefsValue("ChooseFinanceAssistantPath");
        }

        // Room 27
        public bool IsRoom_TWENTY_SEVEN_Ready(){
            return CheckPlayerPrefsValue("ChooseCharityPath");
        }

        // 28
        public bool IsRoom_TWENTY_EIGHT_Ready(){
            return CheckPlayerPrefsValue("ChooseStartupInvestmentPath");
        }

        // 29
        public bool IsRoom_TWENTY_NINE_Ready(){
            return CheckPlayerPrefsValue("ChoosePensionFundPath");
        }
        // 30
        public bool IsRoom_THIRTY_Ready(){
            return CheckPlayerPrefsValue("ChooseLastChancePath");
        }

        //31
        public bool IsRoom_THIRTY_ONE_Ready(){
            return CheckPlayerPrefsValue("ChooseResultOfStartupPath");
        }

        //34
        public bool IsRoom_THIRTY_FOUR_Ready(){
            return CheckPlayerPrefsValue("ChooseResultOfPresentPath");
        }

        // endings
        public bool IsEnding1_Ready(){
            return CheckPlayerPrefsValue("ChooseEnding1Path");
        }
        public bool IsEnding2_Ready(){
            return CheckPlayerPrefsValue("ChooseEnding2Path");
        }
        public bool IsEnding3_Ready(){
            return CheckPlayerPrefsValue("ChooseEnding3Path");
        }
        public bool IsEnding4_Ready(){
            return CheckPlayerPrefsValue("ChooseEnding4Path");
        }
        public bool IsEnding5_Ready(){  
            return CheckPlayerPrefsValue("ChooseEnding5Path");
        }
    #endregion



 
    public bool CheckPlayerPrefsValue(string key)
    {
        Debug.Log(PlayerPrefs.GetInt(key, 0) == 1);
        return PlayerPrefs.GetInt(key, 0) == 1;
    }
}