using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class dbmanager : MonoBehaviour
{
    [SerializeField] string[] status=null;
    [SerializeField] Text text=null;
    [SerializeField] Text poptext=null;
    [SerializeField] GameObject poppanel=null;
    int index = 0;

    void Start()
    {
        text.text = "";
        poptext.text = "";
        poppanel.SetActive(false);
    }

    public void popstatus (int ind)
    {
        index = ind;
        poptext.text = "\"" + status[ind] + "\" 칭호를 획득하셨습니다.";
        poppanel.SetActive(true);
    }

    public void okbutton()
    {
        poppanel.SetActive(false);
        text.text = status[index].ToString();
    }
}