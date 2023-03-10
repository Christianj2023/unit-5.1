using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Gui : MonoBehaviour
{
    private GameObject player;
	private int coins;
	private GameObject[] array;
	public int totalcoins;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        array = GameObject.FindGameObjectsWithTag("coin");
    	int tempInt = 0;
    	for (int i = 0; i < array.Length; i++)
    	{
    		if(array[i].activeSelf == true)
    		{
    			tempInt++;
    		}
    	}
    	coins =  totalcoins - tempInt;
    	tempInt = 0;

    	
        this.GetComponent<Text>().text = "Coins: " + coins.ToString();
    }
}
