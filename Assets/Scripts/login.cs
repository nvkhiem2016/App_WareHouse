using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using SocketIO;
using UnityEngine.SceneManagement;
public class login : MonoBehaviour {

    
    public GameObject idUser, passUser;
    public GameObject thongbao;
    public string id;
    public string password;
    public static string count;
    
	// Use this for initialization
	void Start () {
        SKIO.socket.On("Server-Game-Send-Result-Login", ResultLogin);//bắt sự kiện trả về result login
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    //---------------------------socket.On
    public void ResultLogin(SocketIOEvent e)//kết quả của quá trình login
    {
        Debug.Log("ResultLogin");
        
        int result = int.Parse(e.data["result"].ToString().Replace("\"",""));//lấy result:"0"
        string[] user = e.data["user"].ToString().Split('-');
        Debug.Log(result);
        if (result == -2)//thông báo khi đăng nhập thất bại
        {
            thongbao.GetComponent<Text>().text = "Invail User";
        }
        if (result == -1)// không có quyền
        {
            thongbao.GetComponent<Text>().text = "No per";
        }
        if(result>-1) {
            //luwu thong tin user session
            User.id = user[0].Trim('\"');
            User.countChange = int.Parse(user[2].Trim('\"'));
            User.countSettime = int.Parse(user[3].Trim('\"'));
            

            Load(Menu.idFeature);//load menu
        }      
    }

    //--------------------------------------------------------------------
    public void LoginPressed()
    {
        id = idUser.GetComponent<InputField>().text;
        password = passUser.GetComponent<InputField>().text;
        
        SKIO.Evt_Login(id, password, Menu.idFeature);
    }
    public void idChange()//bắt sự kiện
    {
  
        id = idUser.GetComponent<InputField>().text;
        SKIO.Evt_IdInputChange(id);
        
    }
    public void passChange()
    {
   
        password = passUser.GetComponent<InputField>().text;
        SKIO.Evt_PassInputChange(password);
    }

    public void Load(string scenename)
    {
        Debug.Log("sceneName to load: " + scenename);
        SceneManager.LoadScene(scenename);
    }
}
