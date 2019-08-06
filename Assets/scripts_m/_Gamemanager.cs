using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class _Gamemanager : MonoBehaviour
{
    private diamanager dm;
    [SerializeField] Dialogue.DialogueGraph[] nextdialog=null;
    int i = 0;
    public Text daytext;
    private ScreenManager sm;

    void Start() {
        dm = FindObjectOfType<diamanager>();
        sm = FindObjectOfType<ScreenManager>();
        daytext.text = "Day " + Dialogue.dbNode.day;
        dm.setgm(); //게임매니저 불러오기
        dm.changegra(nextdialog[0]);
        i = 0;
//        Dialogue.ChangeValue.floating = FindObjectOfType<FloatingText>();
        StartCoroutine(fadeout2());
    }

    IEnumerator fadeout2()
    {
        ScreenManager.isfinished = false;
        StartCoroutine(sm.Fadein());
        yield return new WaitUntil(() => ScreenManager.isfinished);
        yield return new WaitForSeconds(0.5f);
        showdialog();
    }

    public void showdialog()
    {
        nextdialog[0].Restart();
        dm.ShowDialogue();
    }

    public void changedia() //다음 대화로
    {        
        i++;
        if (i < nextdialog.Length)
        {
            StartCoroutine(ScreenCoroutine());

            nextdialog[i].Restart();
            dm.changegra(nextdialog[i]);
        }
        else            //모든 대화 끝
        {
            StartCoroutine(Fadetolevel());
        }
    }

    IEnumerator Fadetolevel()
    {
        ScreenManager.isfinished = false;
        StartCoroutine(sm.Fadeout());
        yield return new WaitUntil(() => ScreenManager.isfinished);
        oncomplete();
    }

    public void oncomplete()
    {
        //날짜에 따라
        Dialogue.dbNode.day++;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    IEnumerator ScreenCoroutine()
    {
        ScreenManager.isfinished = false;
        StartCoroutine(sm.Fadeout());
        yield return new WaitUntil(() => ScreenManager.isfinished);

        ScreenManager.isfinished = false;
        StartCoroutine(sm.Fadein());
        yield return new WaitUntil(() => ScreenManager.isfinished);

        dm.ShowDialogue();
    }
}
