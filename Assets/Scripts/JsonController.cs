using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class JsonController  {

    //load text from json file into a text asset
	public static string LoadJsonFile(string path){
		string filePath = path.Replace(".json", "");
		TextAsset jsonFileText = Resources.Load<TextAsset>(filePath);
		return jsonFileText.text;
	}	
}


//serialise the list of cubes
[System.Serializable]

public class EnemyList
{
	public List<Enemy> item;
	
}


//serialize the porperties of cubes
[System.Serializable]
public struct Enemy {
	public int ID;
	public string name;
	public float[] material;
	public int hitPoints;

}

	

