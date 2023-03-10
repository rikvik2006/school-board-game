using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterManager : MonoBehaviour
{

    public CharactersDatabase characterDB;
    public Text nameText;
    public Transform[] playersPositions;
    public Material[] playerMaterials;
    public GameObject[] players;
    public MeshRenderer[] backPackMeshRenderers;
    public GameObject startButton;
    public Text startButtonText;

    private int selectOption = 0;
    private int selectForPlayer = 0;


    // Start is called before the first frame update
    private void Start()
    {
        foreach (GameObject player in players)
        {
            player.SetActive(false);
        }
        startButton.SetActive(false);

    }

    private void Update()
    {
        List<bool> allActive = new List<bool>();
        foreach (GameObject player in players)
        {
            if (player.activeSelf)
            {
                allActive.Add(true);
            }
            else
            {
                allActive.Add(false);
            }

        }

        if (allActive.Find((value) => value == false))
        {
            return;
        }
        else
        {
            Debug.Log("Setting active start button");
            startButton.SetActive(true);
        }
    }

    public void FristPlayerChoice()
    {
        selectForPlayer = 0;
    }
    public void SecondPlayerChoice()
    {
        selectForPlayer = 1;
    }
    public void ThirdPlayerChoice()
    {
        selectForPlayer = 2;
    }
    public void ForthPlayerChoice()
    {
        selectForPlayer = 3;
    }

    public void RedPlayerChoice()
    {
        selectOption = 0;
        RenderCharachter(selectOption);
    }
    public void GreenPlayerChoice()
    {
        selectOption = 1;
        RenderCharachter(selectOption);
    }
    public void BluePlayerChoice()
    {
        selectOption = 2;
        RenderCharachter(selectOption);
    }
    public void PurplePlayerChoice()
    {
        selectOption = 3;
        RenderCharachter(selectOption);
    }

    private void RenderCharachter(int selectedColor)
    {
        // Character character = characterDB.GetCharacter(selectedOption);
        GameObject player = players[selectForPlayer];
        MeshRenderer meshRenderer = player.GetComponent<MeshRenderer>();
        meshRenderer.material = playerMaterials[selectedColor];
        backPackMeshRenderers[selectForPlayer].material = playerMaterials[selectedColor];
        player.SetActive(true);
        // character.characterGameObject.inst
    }
}
