using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Dialogue
{
    [CreateAssetMenu(menuName = "Dialogue/dbmanager")]
    public class dbNode : ScriptableObject
    {
        [System.Serializable]
        public class Choicelist  { public bool[] ch; }

        public static int day=0;

        [SerializeField] Choicelist [] c;
        [SerializeField] int[] mycon= new int [1];

        public bool Greater(int ind, int val)
        {
            if (mycon[ind] > val) return true;
            else return false;
        }

    }
}
