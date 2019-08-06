using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Dialogue {
    [CreateAssetMenu(menuName = "Dialogue/player")]
    public class dbplayer : ScriptableObject
    {
        [SerializeField] int[] stat;
        public int[] Stat { get => stat; set => stat = value; }     
        [SerializeField] int day_p; //진행날짜
        [SerializeField] bool[] jok_p;
        [SerializeField] bool[] status_p=null;
        [SerializeField] bool[] ending_p;

        [SerializeField] float[] senior_p;  //호감도
        public float[] Senior_p { get => senior_p; set => senior_p = value; }

        [SerializeField] int[] con_p;  //호감도
        public int[] Con_ { get => con_p; set => con_p = value; }

        public void initializ()
        {
            stat[0] =0;
            stat[1] =0;
            stat[2] =0;
            stat[3] =0;
            stat[4] =0;

            senior_p.Initialize();
        }

        public bool Greater(int ind, int val)
        {
            if (stat[ind] > val) return true;
            else return false;
        }

        public bool statuschecking(int ind)
        {
            if (!status_p[ind]) return true;
            else return false;
        }

        public void statuspop(int ind)
        {
            dbmanager db = FindObjectOfType<dbmanager>();
            db.popstatus(ind);
            status_p[ind] = true;
        }
    }
}
