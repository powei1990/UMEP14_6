using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static Canvas StatusInformationUI;
    public static Canvas MainMenu;
    public static Canvas InventoryUI;

    private Canvas GamePlayUI;
    private Canvas DialogueUI;
    private Canvas ShopUI;
    private Canvas MiniMap;

    private GameObject StartMenu;
    private Canvas GameOverUI;
    private Canvas DemoEnd;

    public static GameState currentState;
    public enum GameState
    {
        EStartMenu,
        EMainMenu,
        EGamePlay,
        ECutscene,
        EInventory,
        ETalk,
        EShop,
        EGameOver,
        EDemoEnd,
    }

    // Use this for initialization
    void Start()
    {
        //配合Timeline只好不抓Canvas
        StartMenu = GameObject.Find("StartMenu").gameObject;

        GameOverUI = GameObject.Find("GameOverUI").gameObject.GetComponent<Canvas>();
        DemoEnd = GameObject.Find("DemoEnd").gameObject.GetComponent<Canvas>();

        GamePlayUI = GameObject.Find("GamePlayUI").gameObject.GetComponent<Canvas>();
        MainMenu = GameObject.Find("MainMenu").gameObject.GetComponent<Canvas>();
        InventoryUI = GameObject.Find("InventoryUI").gameObject.GetComponent<Canvas>();
        DialogueUI = GameObject.Find("DialogueUI").gameObject.GetComponent<Canvas>();
        StatusInformationUI = GameObject.Find("StatusInformationUI").gameObject.GetComponent<Canvas>();
        ShopUI = GameObject.Find("ShopUI").gameObject.GetComponent<Canvas>();
        MiniMap = GameObject.Find("MiniMap").gameObject.GetComponent<Canvas>();

        ChangeState(GameState.EStartMenu);
        //ChangeState(GameState.EGamePlay);
        //Debug.Log(GamePlayUI);
        //Debug.Log(MainMenu);
        //Debug.Log(InventoryUI);
        //Debug.Log(DialogueUI);
        //Debug.Log(StatusInformationUI);
        //Debug.Log(ShopUI);
        //Debug.Log(MiniMap);


    }

    // Update is called once per frame
    void Update()
    {

    }


    IEnumerator EStartMenuState()
    {
        StartMenu.SetActive(true);

        while (currentState == GameState.EStartMenu)
        {
            yield return null;
        }

        StartMenu.SetActive(false);
    }


    IEnumerator EMainMenuState()
    {
        MainMenu.enabled = true;

        while (currentState == GameState.EMainMenu)
        {
            yield return null;
        }

        MainMenu.enabled = false;
    }

    IEnumerator EGamePlayState()
    {
        GamePlayUI.enabled = true;


        while ((currentState == GameState.EGamePlay)||(currentState == GameState.EInventory))
        {
            yield return null;
        }

        GamePlayUI.enabled = false;
    }


    IEnumerator ECutsceneState()
    {
        //StartMenu.SetActive(true);

        while (currentState == GameState.ECutscene)
        {
            yield return null;
        }

        //StartMenu.SetActive(false);
    }

    IEnumerator ETalkState()
    {
        DialogueUI.enabled = true;


        while (currentState == GameState.ETalk)
        {
            yield return null;
        }

        DialogueUI.enabled = false;

    }


    IEnumerator EShopState()
    {
        DialogueUI.enabled = true;
        ShopUI.enabled = true;

        while (currentState == GameState.EShop)
        {
            yield return null;
        }

        ShopUI.enabled = false;
        DialogueUI.enabled = false;
    }

    IEnumerator EGameOverState()
    {
        GameOverUI.enabled = true;

        while (currentState == GameState.EGameOver)
        {
            yield return null;
        }

        GameOverUI.enabled = false;
    }


    IEnumerator EDemoEndState()
    {
        DemoEnd.enabled = true;

        while (currentState == GameState.EDemoEnd)
        {
            yield return null;
        }

        DemoEnd.enabled = false;
    }


    public void ChangeState(GameState newState)
    {
        currentState = newState;
        StartCoroutine(newState.ToString() + "State");
        Debug.Log(currentState);
    }
}
