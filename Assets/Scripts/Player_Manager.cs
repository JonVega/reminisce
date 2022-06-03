using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player_Manager : MonoBehaviour
{
    [SerializeField]
    private List<PlayerInput> players = new List<PlayerInput>();
    [SerializeField]
    private List<Transform> startingPoints;
    [SerializeField]
    private List<LayerMask> playerLayers;

    private PlayerInputManager pInputManager;

    public void AddPlayer(PlayerInput player) {
        players.Add(player);
        Transform playerParent = player.transform.parent;
        playerParent.position = startingPoints[players.Count - 1].position;
    }

    private void Awake() {
        pInputManager = FindObjectOfType<PlayerInputManager>();
    }

    private void OnEnable() {
        pInputManager.onPlayerJoined += AddPlayer;
    }

    private void OnDisable() {
        pInputManager.onPlayerJoined -= AddPlayer;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
