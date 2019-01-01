using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class A1 : MonoBehaviour {

    public GameObject popup;
	// Use this for initialization
	void Start () {
        mustChangePass();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    public void mustChangePass()//ép buộc thay đổi pass khi đăng nhập lần đầu tiên
    {
        if (User.countChange == 0)
        {
            Debug.Log("Thay đổi password");
            GameObject changePassPopup = Instantiate(popup, transform.position, transform.rotation); 
        }
    }

}
