﻿//using UnityEngine;
//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine.UI;

///// <summary>
///// @author Mike Dobson
///// This is the basic state machine for the Settlers of not catan game for project 4, 
///// this machine will transfer the game from one phase to the next and run the content 
///// for each of the phases.
///// </summary>

////public enum GameState
////{
////    PHASE0,//GameStart
////    PHASE1,//Roll
////    PHASE2,//Trade
////    PHASE3,//Build
////    PHASE4,//Process
////    PHASE5,//EndGame
////    PHASE6//Win
////}

////public enum StateCommands
////{
////    GOTO_PHASE0,
////    GOTO_PHASE1,
////    GOTO_PHASE2,
////    GOTO_PHASE3,
////    GOTO_PHASE4,
////    GOTO_PHASE5,
////    GOTO_PHASE6,
////    QUIT_APPLICATION
////}

//public class ScriptEngine : MonoBehaviour
//{
//    public List<ScriptPlayer> players = new List<ScriptPlayer>();

//    //ScriptPlayer player = new ScriptPlayer("Mike");
//    //Dictionary<ScriptPhaseTransition, GameState> allTransitions; //a dictionary of phase transitions
//    //Dictionary<string, StateCommands> enumParse;
//    //public List<ScriptBoardHex> Hexes;
//    //public GameState CurrentState { get; private set; } //the current state of the game
//    //public GameState PreviousState { get; private set; } //the previous state of the game

//    //@Andrew commented out because player is updating their own resource text.
//    //#region Basic GUI Elements
//    //public Text PhaseText;
//    //public Text NumLumber;
//    //public Text NumWool;
//    //public Text NumBrick;
//    //public Text NumGrain;
//    //#endregion

//    #region Phase 0 variables
//    public GameObject phase0menu; //the phase 0 menu
//    public GameObject phase0button;
//    #endregion

//    #region Phase 1 variables
//    public GameObject phase1menu; //the phase 1 menu
//    #endregion

//    #region Phase 2 variables
//    [Header("Phase 2")]
//    public GameObject phase2menu; // the phase 2 menu
//    public GameObject tradeWindowButton;
//    #endregion

//    #region Phase 3 variables
//    [Header("Phase 3")]
//    public GameObject phase3menu; // the phase 3 menu
//    public GameObject BuildPhaseMenu; //Andrew Seba
//    public GameObject BuildSettlementButton; //build settlement button
//    public GameObject BuildRoadButton; //build road button
//    #endregion

//    #region Phase 4 variables
//    [Header("Phase 4")]
//    public GameObject phase4menu; // the phase 4 menu
//    #endregion

//    #region Phase 5 variables
//    [Header("Phase 5")]
//    public GameObject phase5menu; // the phase 5 menu
//    #endregion

//    #region Phase 6 variables
//    [Header("Phase 6")]
//    //public GameObject phase6menu; // the phase 6 menu
//    //public Text WinnerText; // winner text for phase 6
//    //int winningPlayerNumber = -1;
//    #endregion

//    /// <summary>
//    /// Visual FeedBack stuff.
//    /// </summary>
//    List<GameObject> allEmptySettlements;
//    List<GameObject> allEmptyRoads;

//    // Use this for initialization
//    void Start()
//    {
//        allEmptySettlements = new List<GameObject>();
//        allEmptyRoads = new List<GameObject>();
//        //Grab all settlements
//        foreach(GameObject settlement in GameObject.FindGameObjectsWithTag("Settlement"))
//        {
//            allEmptySettlements.Add(settlement);
//        }
//        foreach(GameObject road in GameObject.FindGameObjectsWithTag("Road"))
//        {
//            allEmptyRoads.Add(road);
//        }


//        //Populate List //Andrew Seba
//        foreach(GameObject player in GameObject.FindGameObjectsWithTag("Player"))
//        {
//            players.Add(player.GetComponent<ScriptPlayer>());

//        }
//        //setup the current state
//        CurrentState = GameState.PHASE0;

//        //setup the previous state
//        PreviousState = GameState.PHASE0;

//        //create the dictionary
//        allTransitions = new Dictionary<ScriptPhaseTransition, GameState>
//        {
//            //Defines the state transitions where
//            //{new ScriptPhaseTransition(actual state of the machine, transition state/command), final state of the machine)}
//            {new ScriptPhaseTransition(GameState.PHASE0, StateCommands.GOTO_PHASE5), GameState.PHASE5 },
//            {new ScriptPhaseTransition(GameState.PHASE1, StateCommands.GOTO_PHASE2), GameState.PHASE2 },
//            {new ScriptPhaseTransition(GameState.PHASE2, StateCommands.GOTO_PHASE3), GameState.PHASE3 },
//            {new ScriptPhaseTransition(GameState.PHASE3, StateCommands.GOTO_PHASE4), GameState.PHASE4 },
//            {new ScriptPhaseTransition(GameState.PHASE4, StateCommands.GOTO_PHASE2), GameState.PHASE2 },
//            {new ScriptPhaseTransition(GameState.PHASE4, StateCommands.GOTO_PHASE3), GameState.PHASE3 },
//            {new ScriptPhaseTransition(GameState.PHASE4, StateCommands.GOTO_PHASE5), GameState.PHASE5 },
//            {new ScriptPhaseTransition(GameState.PHASE5, StateCommands.GOTO_PHASE1), GameState.PHASE1 },
//            {new ScriptPhaseTransition(GameState.PHASE5, StateCommands.GOTO_PHASE6), GameState.PHASE6 }
//        };

//        //Create the dictionary where
//        //{string that is passed by the button, command the string represents
//        enumParse = new Dictionary<string, StateCommands>
//        {
//            {"goto phase 0", StateCommands.GOTO_PHASE0},
//            {"goto phase 1", StateCommands.GOTO_PHASE1},
//            {"goto phase 2", StateCommands.GOTO_PHASE2},
//            {"goto phase 3", StateCommands.GOTO_PHASE3},
//            {"goto phase 4", StateCommands.GOTO_PHASE4},
//            {"goto phase 5", StateCommands.GOTO_PHASE5},
//            {"goto phase 6", StateCommands.GOTO_PHASE6},
//            {"quit application", StateCommands.QUIT_APPLICATION}
//        };

//        Debug.Log("Current state: " + CurrentState);
//        Phase0();
//    }


//    #region Common Class Methods

//    //public void LoadTransition(GameState state, string command)
//    //{
//    //    CurrentState = state;
//    //    switch(state)
//    //    {
//    //        case GameState.PHASE1:
//    //            PreviousState = GameState.PHASE5;
//    //            phase1menu.SetActive(true);
//    //            break;
//    //        case GameState.PHASE2:
//    //            PreviousState = GameState.PHASE1;
//    //            MoveNextAndTransition(command);
//    //            break;
//    //        case GameState.PHASE3:
//    //            PreviousState = GameState.PHASE2;
//    //            MoveNextAndTransition(command);
//    //            break;
//    //        case GameState.PHASE4:
//    //            PreviousState = GameState.PHASE3;
//    //            MoveNextAndTransition(command);
//    //            break;
//    //    }
//    //}


//    //void PhaseTextTransition()
//    //{
//    //    if (PhaseText != null)
//    //    {
//    //        switch (CurrentState)
//    //        {
//    //            case GameState.PHASE0:
//    //                PhaseText.text = "Setup Phase";
//    //                break;
//    //            case GameState.PHASE1:
//    //                PhaseText.text = "Rolling Dice";
//    //                break;
//    //            case GameState.PHASE2:
//    //                PhaseText.text = "Trade";
//    //                break;
//    //            case GameState.PHASE3:
//    //                PhaseText.text = "Build";
//    //                break;
//    //            case GameState.PHASE4:
//    //                PhaseText.text = "End Turn";
//    //                break;
//    //            case GameState.PHASE5:
//    //                PhaseText.text = "Processing";
//    //                break;
//    //            case GameState.PHASE6:
//    //                PhaseText.text = "Winner is:";
//    //                break;
//    //            default:
//    //                PhaseText.text = "Current Phase Text";
//    //                break;
//    //        }
//    //    }
//    //    else
//    //    {
//    //        //throw new UnityException("No Phase text in Engine");
//    //        Debug.Log("No Phase text in Engine.");
//    //    }
//    //}

//    //GameState GetNext(StateCommands command)
//    //{
//    //    //construct transition based on machine current state and the command
//    //    ScriptPhaseTransition newTransition = new ScriptPhaseTransition(CurrentState, command);

//    //    //store the location to got to here
//    //    GameState newState;

//    //    if (!allTransitions.TryGetValue(newTransition, out newState))
//    //        throw new UnityException("Invalid Game State transition " + CurrentState + " -> " + command);

//    //    //return the new state
//    //    return newState;
//    //}

//    //public void MoveNextAndTransition(string command)
//    //{
//    //    //record the previous state of the machine
//    //    PreviousState = CurrentState;

//    //    //location for the new command
//    //    StateCommands newCommand;

//    //    //try to get the value of the command
//    //    if (!enumParse.TryGetValue(command, out newCommand))
//    //        throw new UnityException("Invalid command  -> " + command);

//    //    //setup the new state
//    //    CurrentState = GetNext(newCommand);

//    //    Debug.Log("Transitioning from " + PreviousState + " -> " + CurrentState);
//    //    //transition the game to the next state

//    //    Transition();

//    //}



//    //public void Transition()
//    //{
//    //    switch (PreviousState)
//    //    {
//    //        case GameState.PHASE0:
//    //            //phase0menu.SetActive(false); //Andrew Seba
//    //            //phase1menu.SetActive(true);
//    //            Phase5();
//    //            break;
//    //        case GameState.PHASE1:
//    //            //phase1menu.SetActive(false);
//    //            //phase2menu.SetActive(true);
//    //            tradeWindowButton.SetActive(true);
//    //            Phase2();
//    //            break;
//    //        case GameState.PHASE2:
//    //            //phase2menu.SetActive(false);
//    //            //phase3menu.SetActive(true);
//    //            tradeWindowButton.SetActive(false);
//    //            //Phase3();
//    //            break;
//    //        case GameState.PHASE3:
//    //            //phase3menu.SetActive(false);
//    //            BuildPhaseMenu.SetActive(true);
//    //            //phase4menu.SetActive(true);
//    //            Phase4();
//    //            break;
//    //        case GameState.PHASE4:
//    //            //phase4menu.SetActive(false);
//    //            Phase5();
//    //            break;
//    //        case GameState.PHASE5:
//    //            if (CurrentState == GameState.PHASE1)
//    //            {
//    //                //phase1menu.SetActive(true);
//    //                Phase1();
//    //            }
//    //            else
//    //            {
//    //                Phase6(winningPlayerNumber);
//    //            }
//    //            break;
//    //    }
//    //}
//    #endregion

//    #region Phase 0
//    void Phase0()
//    {
//        Debug.Log("Entering Phase 0");
//        //StartCoroutine("StartGame");
//    }
//    #endregion

//    //IEnumerator StartGame()
//    //{
//    //    //yield return StartCoroutine("GetSettlement");
//    //    yield return StartCoroutine("GetRoad");

//    //    //phase0button.SetActive(true);
//    //}


//    //IEnumerator GetSettlement()
//    //{
//    //    while (true)
//    //    {
//    //        foreach(GameObject settlement in allEmptySettlements)
//    //        {
//    //            settlement.GetComponent<Renderer>().material.color = Color.clear;
//    //        }

//    //        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
//    //        RaycastHit hit;

//    //        if (Physics.Raycast(ray, out hit))
//    //        {
//    //            if (hit.transform.tag == "Settlement")
//    //            {
//    //                hit.collider.gameObject.GetComponent<Renderer>().material.color = Color.yellow;

//    //                if (Input.GetMouseButtonDown(0))
//    //                {
//    //                    hit.transform.GetComponent<ScriptBoardCorner>().owner = players[0];
//    //                    players[0].settlements.Add(hit.transform.gameObject);//Andrew Seba
//    //                    allEmptySettlements.Remove(hit.collider.gameObject);
//    //                    break;
//    //                }
//    //            }
//    //        }
//    //        yield return null;
//    //    }
//    //}

//    //IEnumerator GetRoad()
//    //{
//    //    while (true)
//    //    {
//    //        foreach(GameObject road in allEmptyRoads)
//    //        {
//    //            road.GetComponent<Renderer>().material.color = Color.clear;
//    //        }
//    //        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
//    //        RaycastHit hit;

//    //        if (Physics.Raycast(ray, out hit))
//    //        {
//    //            if (hit.transform.tag == "Road")
//    //            {
//    //                hit.collider.gameObject.GetComponent<Renderer>().material.color = Color.yellow;
//    //                if (Input.GetMouseButtonDown(0))
//    //                {
//    //                    if (hit.transform.GetComponent<ScriptBoardEdge>().CheckStartRoad(this.gameObject))
//    //                    {
//    //                        hit.transform.GetComponent<ScriptBoardEdge>().owner = players[0];
//    //                        players[0].roads.Add(hit.transform.gameObject);//Andrew Seba
//    //                        allEmptyRoads.Remove(hit.collider.gameObject);

//    //                        break;
//    //                    }
//    //                }
//    //            }
//    //        }
//    //        yield return null;
//    //    }
//    //}

//    #region Phase 1
//    //void Phase1()
//    //{
//    //    Debug.Log("Entering Phase 1");
//    //    PhaseTextTransition();
//    //    //ResourcesText();
//    //    int diceRoll = Random.Range(1, 6);
//    //    Debug.Log("Dice Roll " + diceRoll);
//    //    Debug.Log("Checking Settlements");
//    //    players[0].GainResources(diceRoll);
//    //}
//    #endregion

//    #region Phase 2
//    //void Phase2()
//    //{
//    //    Debug.Log("Entered Phase 2");
//    //    PhaseTextTransition();
//    //}
//    #endregion

//    #region Phase 3


//    //public void ActivateBuilding(string command)
//    //{
//    //    switch(command)
//    //    {
//    //        case "buildRoad":
//    //            StartCoroutine("BuyRoad");
//    //            break;
//    //        case "buildSettlement":
//    //            StartCoroutine("BuySettlement");
//    //            break;
//    //    }
//    //}

//    //void DisplaySettlementButton()
//    //{
//    //    if (players[0].brick >= 1 && players[0].wood >= 1 && players[0].grain >= 1 && players[0].wool >= 1)
//    //    {
//    //        BuildSettlementButton.GetComponent<Button>().interactable = true;
//    //    }
//    //    else//andrew Seba
//    //    {
//    //        BuildSettlementButton.GetComponent<Button>().interactable = false;
//    //    }
//    //}

//    //IEnumerator BuySettlement()
//    //{
//    //    while (true)
//    //    {

//    //        //Andrew Seba
//    //        foreach (GameObject settlement in allEmptySettlements)
//    //        {
//    //            settlement.GetComponent<Renderer>().material.color = Color.clear;
//    //        }

//    //        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
//    //        RaycastHit hit;
//    //        if (Physics.Raycast(ray, out hit))
//    //        {
//    //            if (hit.transform.tag == "Settlement")
//    //            {

//    //                hit.collider.gameObject.GetComponent<Renderer>().material.color = Color.yellow;

//    //                if (Input.GetMouseButtonDown(0))
//    //                {
//    //                    if (hit.transform.GetComponent<ScriptBoardCorner>().CheckValidBuild(this.gameObject))
//    //                    {
//    //                        Debug.Log("Valid Settlement Placement");
//    //                        players[0].ChangeBrick(-1);
//    //                        players[0].ChangeWood(-1);
//    //                        players[0].ChangeGrain(-1);
//    //                        players[0].ChangeWool(-1);

//    //                        DisplayRoadButton();
//    //                        DisplaySettlementButton();

//    //                        //Add to player and remove from empty list //andrew seba
//    //                        hit.transform.GetComponent<ScriptBoardCorner>().owner = players[0];
//    //                        players[0].settlements.Add(hit.transform.gameObject);//Andrew Seba
//    //                        allEmptySettlements.Remove(hit.collider.gameObject);

//    //                        break;
//    //                    }
//    //                    else
//    //                    {
//    //                        Debug.Log("Invalid Settlement Placement");
//    //                        //break;
//    //                    }
//    //                }
//    //            }
//    //        }
//    //        yield return null;
//    //    }
            
        
//    //}

//    //void DisplayRoadButton()
//    //{
//    //    if (players[0].brick >= 1 && players[0].wood >= 1)
//    //    {
//    //        BuildRoadButton.GetComponent<Button>().interactable = true;
//    //    }
//    //    else//Andrew Seba
//    //    {
//    //        BuildRoadButton.GetComponent<Button>().interactable = false;
//    //    }
//    //}

//    //IEnumerator BuyRoad()
//    //{
//    //    while (true)
//    //    {

//    //        foreach (GameObject road in allEmptyRoads)
//    //        {
//    //            road.GetComponent<Renderer>().material.color = Color.clear;
//    //        }

//    //        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
//    //        RaycastHit hit;
//    //        if (Physics.Raycast(ray, out hit))
//    //        {
//    //            if (hit.transform.tag == "Road")
//    //            {
//    //                GameObject selectedRoad = hit.collider.gameObject;
//    //                selectedRoad.GetComponent<Renderer>().material.color = Color.yellow;

//    //                if (Input.GetMouseButtonDown(0))
//    //                {
//    //                    if (selectedRoad.GetComponent<ScriptBoardEdge>().CheckValidBuild(this.gameObject))
//    //                    {
//    //                        Debug.Log("Valid Road Placement");
//    //                        players[0].ChangeBrick(-1);
//    //                        players[0].ChangeWood(-1);
//    //                        DisplayRoadButton();
//    //                        DisplaySettlementButton();

//    //                        //Andrew Seba
//    //                        selectedRoad.GetComponent<ScriptBoardEdge>().owner = players[0];
//    //                        players[0].roads.Add(hit.transform.gameObject);
//    //                        allEmptyRoads.Remove(selectedRoad);
//    //                        //end Andrew Seba
//    //                        break;
//    //                    }
//    //                    else
//    //                    {
//    //                        Debug.Log("Invalid Road Placement");
//    //                        //break;
//    //                    }
//    //                }
//    //            }
//    //        }
//    //        yield return null;
//    //    }


//    //}

//    ////public void NextPhase()
//    ////{
//    ////    MoveNextAndTransition("goto phase 4");
//    ////}

//    #endregion



//        //Split phase 4
//        //something something
//    #region Phase 4
//    //void Phase4()
//    //{
//    //    Debug.Log("Entering Phase 4");
//    //    PhaseTextTransition();
//    //    //ResourcesText();
//    //    StartCoroutine("CheckForEndTurn");


//    //}

//    ////Split this to the game manager
//    //IEnumerator CheckForEndTurn()
//    //{
//    //    bool endTurn;
//    //    while (true)
//    //    {
//    //        endTurn = true;
//    //        foreach (ScriptPlayer player in players)
//    //        {
//    //            if (endTurn == true && player.endTurn == false)
//    //            {
//    //                endTurn = false;
//    //            }
//    //        }
//    //        if (endTurn)
//    //        {
//    //            break;
//    //        }
//    //        yield return null;
//    //    }
//    //    if (endTurn)
//    //    {
//    //        Debug.Log(players.Count);
//    //        for (int i = 0; i < players.Count; i++)
//    //        {
//    //            players[i].endTurn = false;
//    //        }

//    //        MoveNextAndTransition("goto phase 5");
//    //        yield break;
//    //    }
//    //    yield return null;

//    //}

//    //public void ReturnToTrade()
//    //{
//    //    StopCoroutine("CheckForEndTurn");
//    //    players[0].endTurn = false;
//    //    MoveNextAndTransition("goto phase 2");
//    //}

//    //public void ReturnToBuild()
//    //{
//    //    StopCoroutine("CheckForEndTurn");
//    //    players[0].endTurn = false;
//    //    MoveNextAndTransition("goto phase 3");
//    //}

//    //public void EndTurn()
//    //{
//    //    players[0].endTurn = true;
//    //}
//    #endregion
    

//    //Processing
//    #region Phase 5
//    //void Phase5()
//    //{
//    //    Debug.Log("Entering Phase 5");

//    //    //Cmd
//    //    PhaseTextTransition();

//    //    CheckForWinner();
//    //}


//    //void CheckForWinner()
//    //{
//    //    Debug.Log("Checking for winner");

//    //    Debug.Log("Start Processing");
//    //    for (int i = 0; i < players.Count; i++)
//    //    {
//    //        if (players[i].numSettlements > 1.25 * players.Count)
//    //        {
//    //            winningPlayerNumber = i;
//    //        }
//    //    }

//    //    if (winningPlayerNumber != -1)
//    //    {
//    //        Debug.Log("End Processing");
//    //        Debug.Log("Winner found");
//    //        MoveNextAndTransition("goto phase 6");
//    //    }
//    //    else
//    //    {
//    //        Debug.Log("End Processing");
//    //        Debug.Log("No winner");
//    //        MoveNextAndTransition("goto phase 1");
//    //    }
//    //}
//    #endregion

//    #region Phase 6
//    //void Phase6(int player)
//    //{
//    //    Debug.Log("Entering Phase 6 (End Game)");
//    //    WinnerText.text = ("Winner: " + players[player].playerName);
//    //}

//    //public void QuitApplication()
//    //{
//    //    Application.Quit();
//    //}
//    #endregion

//    /// <summary>
//    /// @Author: Andrew Seba
//    /// @Description: Takes the current phase and calls the transition engine.
//    /// Button should only be available if done with phase.
//    /// </summary>
//    //public void _NextPhaseButton()
//    //{
//    //    switch (CurrentState)
//    //    {
//    //        case GameState.PHASE0:
//    //            MoveNextAndTransition("goto phase 5");
//    //            break;
//    //        case GameState.PHASE1:
//    //            MoveNextAndTransition("goto phase 2");
//    //            break;
//    //        case GameState.PHASE2:
//    //            MoveNextAndTransition("goto phase 3");
//    //            break;
//    //        case GameState.PHASE3:
//    //            MoveNextAndTransition("goto phase 4");
//    //            break;
//    //        case GameState.PHASE4:
//    //            break;
//    //        case GameState.PHASE5:
//    //            break;

//    //    }
//    //}
//}



////using UnityEngine;
////using System.Collections;
////using System.Collections.Generic;

/////// <summary>
/////// @author Mike Dobson
/////// This is the basic state machine for the Settlers of not catan game for project 4, 
/////// this machine will transfer the game from one phase to the next and run the content 
/////// for each of the phases.
/////// </summary>

////public enum GameState
////{
////    PHASE0,
////    PHASE1,
////    PHASE2,
////    PHASE3,
////    PHASE4,
////    PHASE5,
////    PHASE6
////}

////public enum StateCommands
////{
////    GOTO_PHASE0,
////    GOTO_PHASE1,
////    GOTO_PHASE2,
////    GOTO_PHASE3,
////    GOTO_PHASE4,
////    GOTO_PHASE5,
////    GOTO_PHASE6
////}

////public class ScriptEngine : MonoBehaviour {
////<<<<<<< HEAD

////    //List<ScriptPlayer> players = new List<ScriptPlayer>();

////    ScriptPlayer player = new ScriptPlayer("Mike");
////    Dictionary<ScriptPhaseTransition, GameState> allTransitions; //a dictionary of phase transitions
////    Dictionary<string, StateCommands> enumParse;
////    public GameState CurrentState { get; private set; } //the current state of the game
////    public GameState PreviousState { get; private set; } //the previous state of the game
////    public GameObject phase0menu; //the phase 0 menu
////    public GameObject phase1menu; //the phase 1 menu
////    public GameObject phase2menu; // the phase 2 menu
////    public GameObject phase3menu; // the phase 3 menu
////    public GameObject phase4menu; // the phase 4 menu
////    public GameObject phase5menu; // the phase 5 menu
////    public GameObject phase6menu; // the phase 6 menu
////    public GameObject BuildSettlementMenu; //build settlement button
////    public GameObject BuildRoadMenu; //build road button
////=======

////    public List<ScriptPlayer> players = new List<ScriptPlayer>();

////    //ScriptPlayer player = new ScriptPlayer("Mike");
////    Dictionary<ScriptPhaseTransition, GameState> allTransitions; //a dictionary of phase transitions
////    Dictionary<string, StateCommands> enumParse;
////    //public List<ScriptBoardHex> Hexes;
////    public GameState CurrentState { get; private set; } //the current state of the game
////    public GameState PreviousState { get; private set; } //the previous state of the game

////    #region Phase 0 variables
////    public GameObject phase0menu; //the phase 0 menu
////    public GameObject phase0button;
////    #endregion

////    #region Phase 1 variables
////    public GameObject phase1menu; //the phase 1 menu
////    #endregion

////    #region Phase 2 variables
////    public GameObject phase2menu; // the phase 2 menu
////    #endregion

////    #region Phase 3 variables
////    public GameObject phase3menu; // the phase 3 menu
////    public GameObject BuildSettlementMenu; //build settlement button
////    public GameObject BuildRoadMenu; //build road button
////    #endregion

////    #region Phase 4 variables
////    public GameObject phase4menu; // the phase 4 menu
////    #endregion

////    #region Phase 5 variables
////    public GameObject phase5menu; // the phase 5 menu
////    #endregion

////    #region Phase 6 variables
////    public GameObject phase6menu; // the phase 6 menu
////    public Text WinnerText; // winner text for phase 6
////    int winningPlayerNumber = -1;
////    #endregion
////>>>>>>> mdobson2/master

////    // Use this for initialization
////    void Start () {

////        //players.Add(new ScriptPlayer("Mike"));
////        //setup the current state
////        CurrentState = GameState.PHASE0;

////        //setup the previous state
////        PreviousState = GameState.PHASE0;

////        //create the dictionary
////        allTransitions = new Dictionary<ScriptPhaseTransition, GameState>
////        {
////            //Defines the state transitions where
////            //{new ScriptPhaseTransition(actual state of the machine, transition state/command), final state of the machine)}
////            {new ScriptPhaseTransition(GameState.PHASE0, StateCommands.GOTO_PHASE5), GameState.PHASE5 },
////            {new ScriptPhaseTransition(GameState.PHASE1, StateCommands.GOTO_PHASE2), GameState.PHASE2 },
////            {new ScriptPhaseTransition(GameState.PHASE2, StateCommands.GOTO_PHASE3), GameState.PHASE3 },
////            {new ScriptPhaseTransition(GameState.PHASE3, StateCommands.GOTO_PHASE4), GameState.PHASE4 },
////            {new ScriptPhaseTransition(GameState.PHASE4, StateCommands.GOTO_PHASE5), GameState.PHASE5 },
////            {new ScriptPhaseTransition(GameState.PHASE5, StateCommands.GOTO_PHASE1), GameState.PHASE1 },
////            {new ScriptPhaseTransition(GameState.PHASE5, StateCommands.GOTO_PHASE6), GameState.PHASE6 }
////        };

////        //Create the dictionary where
////        //{string that is passed by the button, command the string represents
////        enumParse = new Dictionary<string, StateCommands>
////        {
////            {"goto phase 0", StateCommands.GOTO_PHASE0},
////            {"goto phase 1", StateCommands.GOTO_PHASE1},
////            {"goto phase 2", StateCommands.GOTO_PHASE2},
////            {"goto phase 3", StateCommands.GOTO_PHASE3},
////            {"goto phase 4", StateCommands.GOTO_PHASE4},
////            {"goto phase 5", StateCommands.GOTO_PHASE5},
////            {"goto phase 6", StateCommands.GOTO_PHASE6}
////        };

////        Debug.Log("Current state: " + CurrentState);
////        Phase0();
////    }

////    GameState GetNext(StateCommands command)
////<<<<<<< HEAD
////    {
////        //construct transition based on machine current state and the command
////        ScriptPhaseTransition newTransition = new ScriptPhaseTransition(CurrentState, command);

////        //store the location to got to here
////        GameState newState;

////        if(!allTransitions.TryGetValue(newTransition, out newState))
////            throw new UnityException("Invalid Game State transition " + CurrentState + " -> " + command);

////        //return the new state
////        return newState;
////    }

////    public void MoveNextAndTransition(string command)
////    {
////        //record the previous state of the machine
////        PreviousState = CurrentState;

////        //location for the new command
////        StateCommands newCommand;

////        //try to get the value of the command
////        if (!enumParse.TryGetValue(command, out newCommand))
////            throw new UnityException("Invalid command  -> " + command);

////        //setup the new state
////        CurrentState = GetNext(newCommand);

////        //transition the game to the next state
////        Transition();

////        Debug.Log("Transitioning from " + PreviousState + " -> " + CurrentState);
////    }

////    void Transition()
////    {
////        switch(PreviousState)
////        {
////            case GameState.PHASE0:
////                phase0menu.SetActive(false);
////                Phase5();
////                break;
////            case GameState.PHASE1:
////                phase1menu.SetActive(false);
////                phase2menu.SetActive(true);
////                Phase2();
////                break;
////            case GameState.PHASE2:
////                phase2menu.SetActive(false);
////                phase3menu.SetActive(true);
////                Phase3();
////                break;
////            case GameState.PHASE3:
////                phase3menu.SetActive(false);
////                //BuildSettlementMenu.SetActive(false);
////                //BuildRoadMenu.SetActive(false);
////                Phase4();
////                break;
////            case GameState.PHASE4:
////                Phase5();
////                break;
////            case GameState.PHASE5:
////                if(CurrentState == GameState.PHASE1)
////                {
////                    phase1menu.SetActive(true);
////                    Phase1();
////                }
////                else
////                {
////                    Phase6();
////                }
////                break;
////        }
////    }

////    void Phase0()
////    {
////        Debug.Log("Entering Phase 0");
////        //MoveNextAndTransition("goto phase 5");
////    }

////    void Phase1()
////    {
////        Debug.Log("Entering Phase 1");

////        int diceRoll = Random.Range(1, 6);
////        Debug.Log("Dice Roll " + diceRoll);
////        //MoveNextAndTransition("goto phase 2");
////    }

////    void Phase2()
////    {
////        Debug.Log("Entering Phase 2");

////        //MoveNextAndTransition("goto phase 3");
////    }

////    #region Phase3
////    void Phase3()
////    {
////        Debug.Log("Entering Phase 3");

////        if(player.NumBrick > 1 && player.NumLumber > 1 && player.NumWheat > 1 && player.NumWool > 1)
////        {
////            BuildSettlementMenu.SetActive(true);
////        }
////        if(player.NumBrick > 1 && player.NumLumber > 1)
////        {
////            BuildRoadMenu.SetActive(true);
////        }

////        //MoveNextAndTransition("goto phase 4");
////    }


////    #endregion

////    void Phase4()
////    {
////        Debug.Log("Entering Phase 4");

////        MoveNextAndTransition("goto phase 5");
////    }

////    void Phase5()
////    {
////        Debug.Log("Entering Phase 5");

////        //foreach(ScriptPlayer player in players)
////        //{
////            //if (player.NumSettlements > (players.Count * 1.25))
////            if(player.NumSettlements > 1.25)
////            {
////                MoveNextAndTransition("goto phase 6");
////            }
////            else
////            {
////                MoveNextAndTransition("goto phase 1");
////            }
////        //}
////    }

////    void Phase6()
////    {
////        Debug.Log("Entering Phase 6");

////        Application.Quit();
////    }
////=======
////    {
////        //construct transition based on machine current state and the command
////        ScriptPhaseTransition newTransition = new ScriptPhaseTransition(CurrentState, command);

////        //store the location to got to here
////        GameState newState;

////        if(!allTransitions.TryGetValue(newTransition, out newState))
////            throw new UnityException("Invalid Game State transition " + CurrentState + " -> " + command);

////        //return the new state
////        return newState;
////    }

////    public void MoveNextAndTransition(string command)
////    {
////        //record the previous state of the machine
////        PreviousState = CurrentState;

////        //location for the new command
////        StateCommands newCommand;

////        //try to get the value of the command
////        if (!enumParse.TryGetValue(command, out newCommand))
////            throw new UnityException("Invalid command  -> " + command);

////        //setup the new state
////        CurrentState = GetNext(newCommand);

////        Debug.Log("Transitioning from " + PreviousState + " -> " + CurrentState);
////        //transition the game to the next state
////        Transition();

////    }

////    void Transition()
////    {
////        switch(PreviousState)
////        {
////            case GameState.PHASE0:
////                phase0menu.SetActive(false);
////                phase1menu.SetActive(true);
////                Phase5();
////                break;
////            case GameState.PHASE1:
////                phase1menu.SetActive(false);
////                phase2menu.SetActive(true);
////                Phase2();
////                break;
////            case GameState.PHASE2:
////                phase2menu.SetActive(false);
////                phase3menu.SetActive(true);
////                Phase3();
////                break;
////            case GameState.PHASE3:
////                phase3menu.SetActive(false);
////                BuildRoadMenu.SetActive(false);
////                BuildSettlementMenu.SetActive(false);
////                phase4menu.SetActive(true);
////                Phase4();
////                break;
////            case GameState.PHASE4:
////                phase4menu.SetActive(false);
////                Phase5();
////                break;
////            case GameState.PHASE5:
////                if(CurrentState == GameState.PHASE1)
////                {
////                    phase1menu.SetActive(true);
////                    Phase1();
////                }
////                else
////                {
////                    Phase6(winningPlayerNumber);
////                }
////                break;
////        }
////    }

////    #region Phase 0
////    void Phase0()
////    {
////        Debug.Log("Entering Phase 0");

////        StartCoroutine("GetSettlement");
////        StartCoroutine("GetRoad");

////        phase0button.SetActive(true);

////        //MoveNextAndTransition("goto phase 5");
////    }

////    IEnumerator GetSettlement()
////    {
////        while (true)
////        {
////            if (Input.GetMouseButtonDown(0))
////            {
////                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
////                RaycastHit hit;
////                if (Physics.Raycast(ray, out hit))
////                {
////                    if (hit.transform.tag == "Settlement")
////                    {
////                        hit.transform.GetComponent<ScriptBoardCorner>().owner = players[0];
////                        break;
////                    }
////                }
////            }
////            yield return null;
////        }
////    }

////    IEnumerator GetRoad()
////    {
////        while (true)
////        {
////            if (Input.GetMouseButtonDown(0))
////            {
////                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
////                RaycastHit hit;
////                if (Physics.Raycast(ray, out hit))
////                {
////                    if (hit.transform.tag == "Road")
////                    {
////                        if (hit.transform.GetComponent<ScriptBoardEdge>().CheckStartRoad())
////                        {
////                            break;
////                        }
////                    }
////                }
////            }
////            yield return null;
////        }
////    }
////    #endregion

////    #region Phase 1
////    void Phase1()
////    {
////        Debug.Log("Entering Phase 1");

////        int diceRoll = Random.Range(1, 6);
////        Debug.Log("Dice Roll " + diceRoll);
////        //MoveNextAndTransition("goto phase 2");
////    }
////    #endregion

////    #region Phase 2
////    void Phase2()
////    {
////        Debug.Log("Entering Phase 2");

////        //MoveNextAndTransition("goto phase 3");
////    }
////    #endregion

////    #region Phase 3
////    void Phase3()
////    {
////        Debug.Log("Entering Phase 3");

////        DisplayRoadButton();
////        DisplaySettlementButton();
////    }

////    void DisplaySettlementButton()
////    {
////        if(players[0].NumBrick >= 1 && players[0].NumLumber >= 1 && players[0].NumWheat >= 1 && players[0].NumWool >= 1)
////        {
////            BuildSettlementMenu.SetActive(true);
////        }
////    }

////    public void BuySettlement()
////    {
////        while(true)
////        {
////            if(Input.GetMouseButtonDown(0))
////            {
////                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
////                RaycastHit hit;
////                if(Physics.Raycast(ray, out hit))
////                {
////                    if(hit.transform.tag == "Settlement")
////                    {
////                        if(hit.transform.GetComponent<ScriptBoardCorner>().CheckValidBuild())
////                        {
////                            Debug.Log("Valid Settlement Placement");
////                            players[0].RemoveBricks(1);
////                            players[0].RemoveLumber(1);
////                            players[0].RemoveWheat(1);
////                            players[0].RemoveWool(1);
////                            BuildSettlementMenu.SetActive(false);
////                            BuildRoadMenu.SetActive(false);
////                            DisplayRoadButton();
////                            DisplaySettlementButton();
////                            break;
////                        }
////                        else
////                        {
////                            Debug.Log("Invalid Settlement Placement");
////                            break;
////                        }
////                    }
////                }
////            }
////        }
////    }

////    void DisplayRoadButton()
////    {
////        if(players[0].NumBrick >= 1 && players [0].NumLumber >= 1)
////        {
////            BuildRoadMenu.SetActive(true);
////        }
////    }

////    public void BuyRoad()
////    {
////        while (true)
////        {
////            if (Input.GetMouseButtonDown(0))
////            {
////                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
////                RaycastHit hit;
////                if (Physics.Raycast(ray, out hit))
////                {
////                    if (hit.transform.tag == "Road")
////                    {
////                        if (hit.transform.GetComponent<ScriptBoardEdge>().CheckValidBuild())
////                        {
////                            Debug.Log("Valid Road Placement");
////                            players[0].RemoveBricks(1);
////                            players[0].RemoveLumber(1);
////                            BuildSettlementMenu.SetActive(false);
////                            BuildRoadMenu.SetActive(false);
////                            DisplayRoadButton();
////                            DisplaySettlementButton();
////                            break;
////                        }
////                        else
////                        {
////                            Debug.Log("Invalid Road Placement");
////                            break;
////                        }
////                    }
////                }
////            }
////        }
////    }



////    #endregion

////    #region Phase 4
////    void Phase4()
////    {
////        Debug.Log("Entering Phase 4");

////        StartCoroutine("CheckForEndTurn");


////    }

////    IEnumerator CheckForEndTurn()
////    {
////        bool endTurn;
////        while (true)
////        {
////            endTurn = true;
////            foreach (ScriptPlayer player in players)
////            {
////                if (endTurn == true && player.EndTurn == false)
////                {
////                    endTurn = false;
////                }
////            }
////            if(endTurn)
////            {
////                break;
////            }
////            yield return null;
////        }
////        if (endTurn)
////        {
////            Debug.Log(players.Count);
////            for (int i = 0; i < players.Count; i++)
////            {
////                players[i].EndTurn = false;
////            }

////            MoveNextAndTransition("goto phase 5");
////            yield break;  
////        }
////        yield return null;

////    }

////    public void ReturnToTrade()
////    {
////        StopCoroutine("CheckForEndTurn");
////        players[0].EndTurn = false;
////        MoveNextAndTransition("goto phase 2");
////    }

////    public void ReturnToBuild()
////    {
////        StopCoroutine("CheckForEndTurn");
////        players[0].EndTurn = false;
////        MoveNextAndTransition("goto phase 3");
////    }

////    public void EndTurn()
////    {
////        players[0].EndTurn = true;
////    }
////    #endregion

////    #region Phase 5
////    void Phase5()
////    {
////        Debug.Log("Entering Phase 5");

////        CheckForWinner();
////    }


////    void CheckForWinner()
////    {
////        Debug.Log("Checking for winner");

////        Debug.Log("Start Processing");
////        for(int i = 0; i < players.Count; i++)
////        {
////            if (players[i].NumSettlements > 1.25 * players.Count)
////            {
////                winningPlayerNumber = i;
////            }
////        }

////        if(winningPlayerNumber != -1)
////        {
////            Debug.Log("End Processing");
////            Debug.Log("Winner found");
////            MoveNextAndTransition("goto phase 6");
////        }
////        else
////        {
////            Debug.Log("End Processing");
////            Debug.Log("No winner");
////            MoveNextAndTransition("goto phase 1");
////        }
////    }
////    #endregion

////    #region Phase 6
////    void Phase6(int player)
////    {
////        Debug.Log("Entering Phase 6");
////        WinnerText.text = ("Winner: " + players[player].PlayerName);
////    }

////    public void QuitApplication()
////    {
////        Application.Quit();
////    }
////    #endregion
////>>>>>>> mdobson2/master
////}