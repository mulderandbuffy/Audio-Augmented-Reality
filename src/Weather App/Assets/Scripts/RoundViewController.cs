using System;
using System.Collections;
using UnityEngine;

namespace DefaultNamespace
{
    public class RoundViewController : MonoBehaviour
    {
        public int circleSize;
        public int noPoints;

        public GameObject origin;
        public JSONReader dataLoader;

        private ArrayList points = new ArrayList();
        public void OnEnable()
        {
            CreatePoints();
        }

        public void CreatePoints()
        {
            var tmp = new ArrayList();
            for (int i = 0; i < noPoints; i++)
            {
                CreatePoint(i, tmp);
            }

            points = SortPoints(tmp);
            
        }

        public ArrayList SortPoints(ArrayList list)
        {
            var output = new ArrayList();
            var slice = noPoints / 4; //1

            output.Add(list[slice]); //1

            for (int i = slice-1; i >= 0; i--) //0
            {
                output.Add(list[i]);
            }

            for (int i = noPoints-1; i > slice; i--) //3 //2
            {
                output.Add(list[i]);
            }

            return output;

        }

        public void CreatePoint(int current, ArrayList list)
        {
            var theta = (Math.PI * 2) / noPoints;
            var angle = theta * current;

            list.Add(new Vector3((float)(circleSize * Math.Cos(angle)), 0,
                (float)(circleSize * Math.Sin(angle))));
        }

    }
}