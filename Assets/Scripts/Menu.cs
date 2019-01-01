using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour {

    public static string idFeature;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void InitialPressed()
    {
        idFeature = "A0";
        //load scenes
        Debug.Log("InitialPressed");
        Load("login");

    }
    public void WarhousePressed()
    {
        idFeature = "A1";
        //load scenes
        Debug.Log("WarehousePressed");
        Load("login");

    }
    public void Load(string scenename)
    {
        Debug.Log("sceneName to load: " + scenename);
        SceneManager.LoadScene(scenename);
    }
}
