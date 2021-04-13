using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


namespace ExciteOMeter {

    public class PrintHeartRate : MonoBehaviour
    {
        public GameObject CubeTest;
        public GameObject reactGO;
        public ReactInletUI reactScript;
        public float reactVariable;




        private void Awake()
        {
            PrintHeartRate printheartrate = CubeTest.AddComponent<PrintHeartRate>();
            {

               
              /**  printheartrate.reactVariable = reactScript.BetHeart; **/


                // Debug.Log(reactVariable);
                //printheartrate.reactVariable = reactScript.getHeart;

            }

        }


        //  //public ExciteOMeter.ReactInletUI HrVariable;
        //  // public ExciteOMeter.ReactInletUI getHeart;

        //// // Start is called before the first frame update
        public void Start()
        {
            reactScript = reactGO.AddComponent<ReactInletUI>();
            //Debug.Log(reactScript.BetHeart);

            PrintHeartRate printheartrate = CubeTest.GetComponent<PrintHeartRate>();
            printheartrate.GetComponent<ExciteOMeter.ReactInletUI>(); 
            
           // // go = new GameObject("HrVariable");

           // // reactVariable = new ExciteOMeter.ReactInletUI();

        }
    

        

        // Update is called once per frame
        public void Update()
    {
            // //PrintHeartRate printheartrate = CubeTest.GetComponent<PrintHeartRate>();
            Debug.Log(reactScript.BetHeart);
            PrintHeartRate printheartrate = CubeTest.AddComponent<PrintHeartRate>();
            {

               /**printheartrate.reactVariable = reactScript.BetHeart; **/
               // Debug.Log(reactVariable);
               //printheartrate.reactVariable = reactScript.getHeart;

            }

          //  Debug.Log(reactVariable);
       // Debug.Log(HrVariable);
       

    }
}
}