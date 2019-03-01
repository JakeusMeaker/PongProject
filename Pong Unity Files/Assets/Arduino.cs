using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO.Ports;
using System;

public class Arduino : MonoBehaviour {

    [SerializeField]
    private GameObject playerOne;
    [SerializeField]
    private GameObject playerTwo;
    [SerializeField]
    private int commPort = 0;
    
    private SerialPort serial;

	void Start () {
        //set the serial port of the arduino and opens communication
        serial = new SerialPort("\\\\.\\COM" + commPort, 9600);
        serial.ReadTimeout = 50;
        serial.Open();
        Restart();
	}
	
	// Update is called once per frame
	void Update () {
        //instructs the arduino to send information of the potentiometers to unity
        WriteToArduino("P");
        string values = ReadFromArduino();

        if(values != null) //takes the values received by the arduino and seperates the values into player 1 and player 2
        {
            string[] splitValues = values.Split('-');

            if(splitValues.Length == 2)
            {
                positionPlayers(splitValues);
            }
        }      
	}

    void positionPlayers(string[] values)
    {
        if(playerOne != null)
        {   
            //takes the input from the arduino and changes it to a value between 0 and 10
            float p1TempValues = float.Parse(values[0]);

            p1TempValues -= 10;

            p1TempValues /= 3;

            p1TempValues = 10 - p1TempValues;

            //the player paddle is then moved by increments of this value
            playerOne.transform.position = new Vector3(playerOne.transform.position.x, p1TempValues, playerOne.transform.position.z);
        }

        if (playerTwo != null)
        {
            //takes the input from the arduino and changes it to a value between 0 and 10
            float p1TempValues = float.Parse(values[1]);

            p1TempValues -= 10;

            p1TempValues /= 3;

            p1TempValues = 10 - p1TempValues;

            //the player paddle is then moved by increments of this value
            playerTwo.transform.position = new Vector3(playerTwo.transform.position.x, p1TempValues, playerTwo.transform.position.z);
        }
    }

    //when this function is run it receives a string and sends it to the arduino
    public void WriteToArduino(string msg)
    {
        serial.WriteLine(msg);
        serial.BaseStream.Flush();
    }

    //reads the information being set from the arduino and if it stops receiving information after a certain amount will stop
    string ReadFromArduino()
    {
        serial.ReadTimeout = 50;
        try
        {
            return serial.ReadLine();
        }
        catch (TimeoutException e)
        {
            return null;
        }
    }

    //closes communications with the arduino
    public void OnDestroy()
    {
        serial.Close();
    }
    
    //instructs the arduino to reset it's LED's
    public void Restart()
    {
        WriteToArduino("r");
    }
    
}

