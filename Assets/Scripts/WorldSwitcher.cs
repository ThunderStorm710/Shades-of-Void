using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Collections.Generic;

public class WorldSwitcher : MonoBehaviour
{
    public GameObject[] worlds;
    public Vector3[] initialSpawnPoints; // Posições iniciais para cada mundo
    private Dictionary<int, Vector3> savedPositions = new Dictionary<int, Vector3>();
    private int currentWorld = 0;

    private void Start()
    {
        // Inicializa com a posição de spawn inicial para cada mundo
        for (int i = 0; i < worlds.Length; i++)
        {
            savedPositions[i] = initialSpawnPoints[i];
        }

        // Certifica-se de que apenas o mundo inicial está ativo
        foreach (var world in worlds)
        {
            world.SetActive(false);
        }
        worlds[currentWorld].SetActive(true);
        MovePlayerToSavedPosition();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            SwitchWorld();
        }
    }

    void SwitchWorld()
    {
        // Salva a posição atual do personagem antes de mudar
        SaveCurrentPosition();

        // Desativa o mundo atual
        worlds[currentWorld].SetActive(false);

        // Calcula o próximo mundo
        currentWorld = (currentWorld + 1) % worlds.Length;

        // Ativa o próximo mundo
        worlds[currentWorld].SetActive(true);

        // Move o personagem para a posição salva do novo mundo
        MovePlayerToSavedPosition();
    }

    void SaveCurrentPosition()
    {
        Transform playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
        savedPositions[currentWorld] = playerTransform.position;
    }

    void MovePlayerToSavedPosition()
    {
        Transform playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
        playerTransform.position = savedPositions[currentWorld];
    }
}
