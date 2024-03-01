using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using Photon.Pun.Demo.PunBasics;
using UnityEngine;

public class NetworkClass : MonoBehaviour
{
    [Header("Online")]
    public bool isOffline;
    public bool isMine;
    public bool isMaster;

    public void SetUp(bool isMineV, bool isOfflineV, bool isMasterV)
    {
        this.isMine = isMineV;
        this.isOffline = isOfflineV;
        this.isMaster = isMasterV;
    }
}

public class NetworkPlayer : MonoBehaviour
{
    public bool isOffline;
    public bool isMaster;
    public PhotonView photonView;
    public NetworkClass[] networkClasses;
    public GameObject camObject;
    public Movement movement;
    public LayerMask myLayer;
    public LayerMask othersLayers;
    
    public void Awake()
    {
        networkClasses = GetComponentsInChildren<NetworkClass>();
        photonView = GetComponent<PhotonView>();
        isMaster = PhotonNetwork.IsMasterClient;
        if (photonView.IsMine)
        {
            camObject.SetActive(true);
            /*if (GameManager.instance)
            {
                GameManager.instance.SetLocalPlayer(this);
            }*/
            
            foreach (Transform child in transform)
            {
                child.gameObject.layer = LayerMask.NameToLayer("Stickman");
            }
        }
        else
        {
            camObject.SetActive(false);
            foreach (Transform child in transform)
            {
                child.gameObject.layer = othersLayers.value;
            }
        }
        foreach (var cClass in networkClasses)
        {
            cClass.SetUp(photonView.IsMine, isOffline, isMaster);
        }

    }
}
