using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Networking;
using UnityEngine.Networking.NetworkSystem;
using UnityEngine.UI;

public class myNetworkManager : NetworkManager
{

    public Button botonJhonda;
    public Button botonNico;
    public Button botonMono;

    public int index;

    public Canvas SelectionCanvas;
    // Use this for initialization
    void Start ()
    {
        botonJhonda.onClick.AddListener(delegate { EscogerPeleador(botonJhonda.name); });
        botonNico.onClick.AddListener(delegate { EscogerPeleador(botonNico.name); });
        botonMono.onClick.AddListener(delegate { EscogerPeleador(botonMono.name); });
    }

    private void EscogerPeleador(string name)
    {
        switch (name)
        {
            case "Jhonda":
                index = 0;
                break;

            case "Mono":
                index = 1;
                break;

            case "Nico":
                index = 2;
                break;

        }

        playerPrefab = spawnPrefabs[index];
    }


    //Estos dos metodos son tomados directamente de la documentacion del bitbucket de unity/networking.
    public override void OnClientConnect(NetworkConnection conn)
    {

        SelectionCanvas.enabled = false;
        //Este metodo integerMessage es para enviar un numero
        //No se envia directamente pq los metodos de network no lo recibirian.
        IntegerMessage msg = new IntegerMessage(index);

        if (!clientLoadedScene)
        {
            //Para verificar que se dio la coneccion 
            ClientScene.Ready(conn);
            if (autoCreatePlayer)
            {
                //Este metodo se cambia, antes llamaba otro AddPlayer, pero sin la sobrecarga del mensaje.
                ClientScene.AddPlayer(conn, 0, msg);
            }
        }

    }

    public override void OnServerAddPlayer(NetworkConnection conn, short playerControllerId, NetworkReader extraMessageReader)
    {

        int id = 0;

        //Para poder recibir el mensaje del otro metodo.
        if (extraMessageReader != null)
        {
            //Se asigna el valor a otra varaible local.
            IntegerMessage i = extraMessageReader.ReadMessage<IntegerMessage>();
            id = i.value;
        }

        // Con el numero que llego del mensaje, se le dice cual prefab pa seleccionar en el servidor.
        GameObject playerPrefab = spawnPrefabs[id];

        GameObject player;
        Transform startPos = GetStartPosition();
        if (startPos != null)
        {
            player = (GameObject)Instantiate(playerPrefab, startPos.position, startPos.rotation);
        }
        else
        {
            player = (GameObject)Instantiate(playerPrefab, Vector3.zero, Quaternion.identity);
        }

        NetworkServer.AddPlayerForConnection(conn, player, playerControllerId);
    }
}
