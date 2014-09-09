using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public enum MiniGame
{
	MagnifyingLense,
	EnergyMaze,
	Library,
	GPSGame
};

public class GlobalData  {

	#region Constructor
	
	private static GlobalData instance;

	
	public static GlobalData Instance
	{
		get
		{
			if (instance == null)
			{
				new GlobalData();
			}
			return instance;
		}
	}
	
	#endregion
	#region GameResults

	public GlobalData()
	{
		if (instance != null)
		{
			return;
		}

	


		instance = this;
	}

	public bool isGameSolved(MiniGame game) {
		string key = "solvedGame_"+ game.ToString();

		if(PlayerPrefs.HasKey(key))
		{
			return PlayerPrefs.GetInt(key) != 0;
		} 
		return false;

	}

	public void gameSolved(MiniGame game) {
		string key = "solvedGame_"+ game.ToString();
		//PlayerPrefs.SetInt(1);
	}

	public float getGameValue(MiniGame game, string keySuffix){
		string key =  game.ToString()+keySuffix;
		
		if(PlayerPrefs.HasKey(key))
		{
			return PlayerPrefs.GetFloat(key);
		} 
		return 0f;
	}

	public void setGameValue(MiniGame game, string keySuffix, float value){
		string key =  game.ToString()+keySuffix;
		PlayerPrefs.SetFloat(key, value);
	}


	
	#endregion


}
