using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CharacterSelection : MonoBehaviour
{

    public GameObject[] characterList;
    private int index;
    public GameObject Selection;
	// Use this for initialization
	void Start ()
    {
        if (this.gameObject.name == "CharacterPlayer1")
        index = PlayerPrefs.GetInt("CharacterPlayer1");

        else if (this.gameObject.name == "CharacterPlayer2")
           index = PlayerPrefs.GetInt("CharacterPlayer2");


        characterList = new GameObject[transform.childCount];

        for (int i = 0; i < transform.childCount; i++)
        {
            characterList[i] = transform.GetChild(i).gameObject;
        }

        foreach (GameObject go in characterList)
        {
            go.SetActive(false);
        }

        if (characterList[index] != null)
        {
            characterList[index].SetActive(true);
            Debug.Log(characterList[index].name);

        }
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    public void CambiarAnterior()
    {
        characterList[index].SetActive(false);


        index--;
        if (index < 0)
        {
            index = characterList.Length - 1;
        }

        characterList[index].SetActive(true);
    }
    public void CambiarSiguiente()
    {

        characterList[index].SetActive(false);
        index++;
        if (index == characterList.Length)
        {
            index = 0;
        }

        characterList[index].SetActive(true);
    }

    public void SeleccionarPlayer1()
    {
        PlayerPrefs.SetInt("CharacterPlayer1", index);
        Debug.Log("Character Selected: " + index);
    }
    public void SeleccionarPlayer2()
    {
        PlayerPrefs.SetInt("CharacterPlayer2", index);
    }

    public void Continuar(string name)
    {
        SceneManager.LoadScene(name);
    }
}
