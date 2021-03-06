﻿using UnityEngine;
using System.Collections;
using System;
using UnityEngine.UI;

public class GameController : Singleton<GameController>{

	public GameModel gameModel;
	private System.Random randomNumberGenerator;

	[Header("Summary Canvas")]
	public GameObject twoPlayerRules;
	public GameObject twoPlayerHeaderText;
	public GameObject fourPlayerRules;
	public GameObject fourPlayerHeaderText;
	[Header("Game Canvas")]
	public GameObject twoPlayerWordLabel;
	public GameObject fourPlayerWordLabel;
	[Header("Main Camera")]
	public GameObject mainCamera;

	[Header("BFF INPUTS")]
	public Text playerOneInputField;
	public Text playerTwoInputField;
	private Color playerOneInputFieldColor;
	private Color playerTwoInputFieldColor;

	public Animator twoPlayerGameCanvasAnimator;
	public Animator fourPlayerGameCanvasAnimator;

	public GameController(){
		gameModel = new GameModel ();
		randomNumberGenerator = new System.Random ();
	}

	void Start(){
		playerOneInputFieldColor = playerOneInputField.color;
		playerTwoInputFieldColor = playerTwoInputField.color;
	}

	public void SetupGame(string gameName){
		gameModel.initialiseGame (gameName);
		UpdateSummaryUI ();
		twoPlayerGameCanvasAnimator.SetInteger ("TimerAmount", gameModel.Timer);
		fourPlayerGameCanvasAnimator.SetInteger ("TimerAmount", gameModel.Timer);
	}

	public void UpdateSummaryUI(){
		twoPlayerRules.GetComponent<Text> ().text = gameModel.Summary;
		twoPlayerHeaderText.GetComponent<Text> ().text = gameModel.Title;
		fourPlayerRules.GetComponent<Text> ().text = gameModel.Summary; //Just doing both because of time saved over performance
		fourPlayerHeaderText.GetComponent<Text> ().text = gameModel.Title;

	}

	public void DisplayRandomWord(){
		string randomWord;
		gameModel.WordsInPlayContainer.TryGetValue(getAppropriateRandomNumber(), out randomWord );
		twoPlayerWordLabel.GetComponent<Text> ().text = randomWord;
		fourPlayerWordLabel.GetComponent<Text> ().text = randomWord;
	}

	private int getAppropriateRandomNumber(){
		return Convert.ToInt32(randomNumberGenerator.Next(gameModel.WordsInPlayContainer.Count));
	}


	public void ResetInputFields(){
		playerOneInputField.GetComponentInParent<InputField> ().text = "";
		playerOneInputField.color = playerOneInputFieldColor;
		playerTwoInputField.GetComponentInParent<InputField> ().text = "";
		playerTwoInputField.color = playerTwoInputFieldColor;
	}

	public void RevealInputFields(){
		playerOneInputField.color = Color.black;
		playerTwoInputField.color = Color.black;
	}


}

