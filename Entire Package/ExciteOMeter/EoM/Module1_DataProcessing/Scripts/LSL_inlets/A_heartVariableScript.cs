using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Globalization;
using UnityEngine.UI;
using TMPro;
using Assets.LSL4Unity.Scripts;
using Assets.LSL4Unity.Scripts.Examples;

namespace ExciteOMeter
{
    public class A_heartVariableScript : InletShortSamples
    { 
        // Where to import the Geometry
        public GameObject heartBox;

        // Start Time
        float timeCounter = 0;

        // Assign the x,y,z values manually for now

        public float xValue;
        public float yValue;
        public float zValue;

       
        /** The variables for orbits - FUTURE
        public float speed;
        public float width;
        public float height;
        public float depth;
        **/

        void Awake()
        {
            Debug.Log("Awake Bitch");
           
        }

   

        public float[] heartUnity;
        protected override void Process(short[] newSample, double timeStamp)
        {
            Debug.Log(newSample[0]);
            Debug.Log("Hello Bitch");
            // Collect Heart Monitor Data and Convert to Float
            short[] vIn = newSample;
            float vOut = Convert.ToSingle(vIn);
            float heartUnity = vOut;

            Debug.Log(heartUnity);
            /** Operations for Orbit - FUTURE
            timeCounter += Time.deltaTime;
            float x = xValue + Mathf.Sin(timeCounter) * width;
            float y = yValue + Mathf.Cos(timeCounter) * height;
            // float z = zValue + Mathf.Cos(timeCounter) * depth;
            float heartValue1 = float.Parse(heartValue);
            float z = 0 + heartValue1;
            **/
            float divideHeartUnit = 9;

            //Define new X,Y,Z Variables
            float x = xValue;
            float y = yValue + (heartUnity / divideHeartUnit);
            float z = zValue;

            heartBox.transform.position = new Vector3(x, y, z);
        }
         
    }
   

    }


    


