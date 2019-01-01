using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class A0 : MonoBehaviour {
    // Inital
    public GameObject popup;
    public GameObject time;
    public static int countSettime;//dùng để kt tech có settime lần nào chưa
	// Use this for initialization
	void Start () {
        mustChangePass();
        techChangeSet();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    public void setTimePressed()
    {
        string time1 = time.GetComponent<InputField>().text;
        Debug.Log("setTimePressed");
        SKIO.Evt_SetTime(time1,User.id);
    }
    public void mustChangePass()//ép buộc thay đổi pass khi đăng nhập lần đầu tiên
    {
        if (User.countChange == 0)
        {
            Debug.Log("Thay đổi password");
            Instantiate(popup); 

        }
    }
    public void techChangeSet()//ép buộc thay đổi pass khi đăng nhập lần đầu tiên
    {
        if (User.countSettime > 0 && User.id=="technical")
        {
            Debug.Log("Không thể set time nữa ");
        }
    }
}
