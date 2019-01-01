using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SocketIO;

public class SKIO : MonoBehaviour {

    public static SocketIOComponent socket;



    public delegate void Event_Login(string _id,string password,string per);
    public static Event_Login Evt_Login;
    public delegate void Event_SetTime(string _time,string _id);
    public static Event_SetTime Evt_SetTime;
    public delegate void Event_IdInputChange(string _value);
    public static Event_IdInputChange Evt_IdInputChange;
    public delegate void Event_PassInputChange(string _value);
    public static Event_PassInputChange Evt_PassInputChange;
    public delegate void Event_ChangePassword(string _id,string _pass);
    public static Event_ChangePassword Evt_ChangePassword;
	// Use this for initialization
	void Start () {
        


        Evt_Login += Handler_Login;
        Evt_SetTime += Handler_SetTime;
        Evt_IdInputChange += Handler_IdInputChange;
        Evt_PassInputChange += Handler_PassInputChange;
        Evt_ChangePassword += Handler_ChangePassword;
	}
    void Awake()
    {
        socket = this.gameObject.GetComponent<SocketIOComponent>();
        DontDestroyOnLoad(socket);
    }
	// Update is called once per frame
	void Update () {
		
	}
    
    //---------------------------socket.emit
    IEnumerator Coro_Login(string _id, string _password, string _idFeature)
    {
        yield return new WaitForSeconds(0.1f);
        Dictionary<string, string> data = new Dictionary<string, string>();
        data["id"] = _id;
        data["password"] = _password;
        data["idFeature"] = _idFeature;
        if (SKIO.socket != null)
        {
            SKIO.socket.Emit("App-Login", new JSONObject(data));
        }
    }
    public void Handler_Login(string _id, string _password, string _idFeature)
    {
        if (_id != null && _password != null && _idFeature != null)
        {
            StartCoroutine(Coro_Login(_id, _password, _idFeature));

        }

    }
    IEnumerator Coro_SetTime(string _time, string _id)
    {
        yield return new WaitForSeconds(0.1f);
        Dictionary<string, string> data = new Dictionary<string, string>();
        data["time"] = _time;
        data["id"] = _id;
        if (SKIO.socket != null)
        {
            SKIO.socket.Emit("App-SetTime", new JSONObject(data));
        }
    }
    public void Handler_SetTime(string _time, string _id)
    {
        if (_time != null && _id != null)
        {
            StartCoroutine(Coro_SetTime(_time, _id));
        }

    }
    IEnumerator Coro_IdInputChange(string _value)
    {
        yield return new WaitForSeconds(0.1f);
        Dictionary<string, string> data = new Dictionary<string, string>();
        data["value"] = _value;

        if (SKIO.socket != null)
        {
            SKIO.socket.Emit("App-IdInputChange", new JSONObject(data));
        }
    }
    public void Handler_IdInputChange(string _value)
    {
        if (_value != null)
        {
            StartCoroutine(Coro_IdInputChange(_value));
        }
    }
    IEnumerator Coro_PassInputChange(string _value)
    {
        yield return new WaitForSeconds(0.1f);
        Dictionary<string, string> data = new Dictionary<string, string>();
        data["value"] = _value;

        if (SKIO.socket != null)
        {
            SKIO.socket.Emit("App-PassInputChange", new JSONObject(data));
        }
    }
    public void Handler_PassInputChange(string _value)
    {
        if (_value != null)
        {
            StartCoroutine(Coro_PassInputChange(_value));
        }
    }
    IEnumerator Coro_ChangePassword(string _id, string _pass)
    {
        yield return new WaitForSeconds(0.1f);
        Dictionary<string, string> data = new Dictionary<string, string>();
        data["id"] = _id;
        data["pass"] = _pass;
        if (SKIO.socket != null)
        {
            SKIO.socket.Emit("App-ChangePassword", new JSONObject(data));
        }
    }
    public void Handler_ChangePassword(string _id, string _pass)
    {
        if (_id != null && _pass != null)
        {
            StartCoroutine(Coro_ChangePassword(_id, _pass));
        }
    }
    //--------------------------------------------------------------------------
}
