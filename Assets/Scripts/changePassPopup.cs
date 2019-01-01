using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class changePassPopup : MonoBehaviour {

    public GameObject pass,passConfirm;
    public GameObject thongbao;
    public GameObject changePopup;
	// Use this for initialization
    public void buttonPressed()
    {
        string pass1 = pass.GetComponent<InputField>().text;
        string passConfirm1 = passConfirm.GetComponent<InputField>().text;
        if (pass1 == passConfirm1)
        {
            Debug.Log("true");
            thongbao.GetComponent<Text>().text = "";
            SKIO.Evt_ChangePassword(User.id, pass1);
            destroyPopup();
        }
        else
        {
            Debug.Log("false");
            thongbao.GetComponent<Text>().text = "Password không khớp";
        }
    }
    public void destroyPopup()
    {
        Destroy(changePopup);
    }
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
