using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MemoryCard : MonoBehaviour
{
    [SerializeField] private Sprite image;
    [SerializeField] private GameObject cardBack;
    [SerializeField] private SceneController controller;

    private int _id;

    public int ID
    {
        get // Добавление функции чтения (идиома, распространенная в таких языках, как C# и Java).
        {
            return _id;
        } 
    }

    public void SetCard(int id, Sprite image) //Открытый метод для передачи указанному объекту новых спрайтов.
    {
        _id = id;
        GetComponent<SpriteRenderer>().sprite = image; //Сопоставляем этот спрайт компоненту SpriteRenderer.
    }

    public void OnMouseDown() //Эта функция вызывается после щелчка на объекте.
    {
        if (cardBack.activeSelf)
        {
            cardBack.SetActive(false); //Делаем объект неактивным / невидимым.
        }
    }

    // Use this for initialization
    void Start ()
    {

    }
	
	// Update is called once per frame
	void Update ()
    {
		
	}
}
