using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

namespace ExciteOMeter
{
    public class ReactInletUIRR : MonoBehaviour
    {
        [Header("Incoming data type")]
        public DataType dataType = DataType.NONE;

        [Header("UI setup")]
        public TextMeshProUGUI labelTextRR;
        public Image connectionStatusImageRR;
        public TextMeshProUGUI valueTextRR;

        public Color connectedColorRR = new Color(0,1,0);
        public Color disconnectedColorRR = new Color(1,0,0);

        [Header("Line")]
        public OnlineLineGraph onlineLineRR;
        public Color lineColorRR = new Color(1,0,0);
        public Color notRecordingColorRR = new Color(0.95f,0.95f,0.95f);

        [Header("Cube")]
        public CubeHeart cubeheartRR;


        public float getHeartRR; 
        
        private bool currentlyConnected = false;

        private void Start()
        {
            // Setup UI children
            if(labelTextRR == null) labelTextRR = transform.GetComponentInChildren<TextMeshProUGUI>();
            if(connectionStatusImageRR ==null) connectionStatusImageRR = transform.GetComponentInChildren<Image>();
            if(labelTextRR != null) labelTextRR.text = dataType.ToString();

            // Setup connection indication
            currentlyConnected = false;
            SetConnectedStatus(currentlyConnected);
        }

        void OnEnable()
        {
            EoM_Events.OnStreamConnected += StreamConnection;
            EoM_Events.OnStreamDisconnected += StreamDisconnection;
            EoM_Events.OnDataReceived += DataReceived;
            EoM_Events.OnLoggingStateChanged += SetRecordingStatus;
        }

        void OnDisable()
        {
            EoM_Events.OnStreamConnected -= StreamConnection;
            EoM_Events.OnStreamDisconnected -= StreamDisconnection;
            EoM_Events.OnDataReceived -= DataReceived;
            EoM_Events.OnLoggingStateChanged -= SetRecordingStatus;
        }
        
        void OnValidate()
        {
            onlineLineRR.UpdateLineColor(lineColorRR);
        }

        private void StreamConnection(DataType type)
        {
            // If type of data from new LSL connection is equal to this flag's type
            if (type == dataType)
            {
                currentlyConnected = true;
                SetConnectedStatus(currentlyConnected);
            }
        }

        private void StreamDisconnection(DataType type)
        {
            // If type of data from new LSL connection is equal to this flag's type
            if (type == dataType)
            {
                currentlyConnected = false;
                SetConnectedStatus(currentlyConnected);
            }

            ExciteOMeterOnlineUI.instance.ShowDisconnectedSignal();
        }

        // Sets the color of the image as connected or disconnected
        private void SetConnectedStatus(bool status)
        {
            connectionStatusImageRR.color = status? connectedColorRR : disconnectedColorRR;
        }

        
        public void DataReceived(DataType type, float timestamp, float value)
        {
            if(type == dataType && valueTextRR != null)
            {
              //  Debug.Log(value);
                getHeartRR = value;
                valueTextRR.text = value.ToString("F0");

                if (onlineLineRR != null)
                {
                    onlineLineRR.PlotNewSample(value);
                    //Debug.Log("Test second if" + getHeart);
                }

            }
        }

        public void SetRecordingStatus(bool status)
        {
            if(status)
            {
                // Log started
                onlineLineRR.RestartPlot();
                onlineLineRR.UpdateLineColor(lineColorRR);
            }
            else
            {
                // Not recording, show the lines in different color
                onlineLineRR.UpdateLineColor(notRecordingColorRR);
            }
        }
    }
}
