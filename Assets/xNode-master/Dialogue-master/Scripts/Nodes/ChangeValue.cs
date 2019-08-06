using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XNode;

namespace Dialogue
{
    [NodeTint("#FFFFFF")]
    public class ChangeValue : DialogueBaseNode
    {
        public dbplayer player;
        public GameObject floatingtext;
 //       public static FloatingText floating;
        public Val[] vals;
        [System.Serializable]   public class Val
        {
            public int ind;
            public int val;
        }
        Color textcolor;
        int i = 0;
        int index = 0;

        //플로팅 텍스트 변경
        public string ChangeText(int ind)
        {
            switch (ind)
            {
                case 0:
                    textcolor = Color.red;
                    return "지능";
                case 1:
                    textcolor = Color.black;
                    return "인맥";
                case 2:
                    textcolor = Color.green;
                    return "돈";
                case 3:
                    textcolor = Color.blue;
                    return "스트레스";
                case 4:
                    textcolor = Color.magenta;
                    return "체력";
                default:
                    Debug.Log("default");
                    textcolor = Color.clear;
                    return "";
            }
        }

        //플로팅텍스트
        void Floating_Text(int ind, int val)
        {  
           //사운드 재생
           /*use instantiate  */
            Canvas p = FindObjectOfType<Canvas>();
 //           FloatingText floating = FindObjectOfType<FloatingText>();
            string text = ChangeText(ind);
            var clone = Instantiate(floatingtext, Vector3.back, Quaternion.identity, p.transform); 
            if(val>0)   clone.GetComponent<TextMesh>().text = text + " +" + val;
            else clone.GetComponent<TextMesh>().text = text + " " + val;
            clone.GetComponent<TextMesh>().color = textcolor;
        }

        

        public override void Trigger()
        {
            int[] stat = player.Stat;
            float[] senior = player.Senior_p;
            int[] pcon = player.Con_;

            for (i=0; i < vals.Length ; i++)
            {
                index = vals[i].ind;

                if (index < 5) //스탯일 경우
                {
                    stat[index] += vals[i].val;
                    if (stat[index] < 0)    stat[index] = 0;
                    if (stat[index] > 100)      stat[index] = 100;

                    if (floatingtext != null)  {   Floating_Text(index, vals[i].val);  }
    //                floating.f(index, vals[i].val);
                }

                else
                {
                    pcon[index] += vals[i].val;
                }
            }

            NodePort port;
            port = GetOutputPort("output");
            if (!port.IsConnected) { Debug.Log("!port.isconnected"); }
            if (port == null) return;

            for (int i = 0; i < port.ConnectionCount; i++)
            {
                NodePort connection = port.GetConnection(i);
                (connection.node as DialogueBaseNode).Trigger();
            }
        }
    }
}
