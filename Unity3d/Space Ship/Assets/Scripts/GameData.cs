using UnityEngine;
using System.Collections;
using System.Security.Cryptography;

//Class used for handling game data that is used and needs to be displayed in game
public class GameData : MonoBehaviour {

	public static GameData current;

	public int credits;
	public string playerName;

	private string cypherKey = "Hadaru";
	
	void Awake()
	{
		if(current != null && current != this)
		{
			Destroy(gameObject);
		}
		else
		{
			DontDestroyOnLoad(gameObject);
			current = this;
			//Load Game Data
			//...
		}

		//Example
		//byte[] cypherText = Encrypt (System.Text.Encoding.UTF8.GetBytes("Hello World!") );
		//Decrypt(cypherText);
	}

	void Load()
	{

	}

	void Save()
	{

	}

	byte[] Encrypt(byte[] plainText)
	{
		CspParameters cspParams = new CspParameters();
		
		cspParams.KeyContainerName = cypherKey;
		var provider = new RSACryptoServiceProvider(cspParams);
		
		return provider.Encrypt(plainText, true);
	}

	void Decrypt(byte[] encryptedBytes)
	{
		CspParameters cspParams = new CspParameters();
		
		cspParams.KeyContainerName = cypherKey;
		var provider = new RSACryptoServiceProvider(cspParams);

		string decrypted = System.Text.Encoding.UTF8.GetString(
			provider.Decrypt(encryptedBytes, true));

		Debug.Log(decrypted);
	}
}
