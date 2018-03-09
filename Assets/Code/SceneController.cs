using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneController : MonoBehaviour
{
    [SerializeField] private MemoryCard originalCard; //Ссылка для карты в сцене.
    [SerializeField] private Sprite[] images; //Массив для ссылок на ресурсы-спрайты.

    public int gridRows = 2; //Значения, указывающие количество ячеек сетки и их расстояние друг от друга.
    public int gridCols = 4;
    public float offsetX = 6f;
    public float offsetY = 6f;

    // Use this for initialization
    void Start ()
    {
        Vector3 startPos = originalCard.transform.position; //Положение первой карты; положение остальных карт отсчитывается от этой точки.

        int[] numbers = { 0, 0, 1, 1, 2, 2, 3, 3 }; //Объявляем целочисленный массив с парами идентификато- ров для всех четырех спрайтов с изображениями карт.

        numbers = ShuffleArray(numbers); //Вызов функции, перемешивающей элементы массива.
        
        for (int i = 0; i < gridCols; i++)
        {
            for (int j = 0; j < gridRows; j++)
            {
                MemoryCard card; //Ссылка на контейнер для исходной карты или ее копий.

                if (i == 0 && j == 0)
                {
                    card = originalCard;
                }
                else
                {
                    card = Instantiate(originalCard) as MemoryCard;
                }

                int index = j * gridCols + i;
                int id = numbers[index]; //Получаем идентификаторы из перемешанного списка, а не из случайных чисел.
                card.SetCard(id, images[id]);

                float posX = (offsetX * i) + startPos.x;
                float posY = -(offsetY * j) + startPos.y;
                card.transform.position = new Vector3(posX, posY, startPos.z); //В двухмерной графике нам нужно только смещение по осям X и Y; значение Z не меняется.
            }
        }
    }

    private int[] ShuffleArray(int[] numbers) //Реализация алгоритма тасования Кнута.
    {
        int[] newArray = numbers.Clone() as int[];
        for (int i = 0; i < newArray.Length; i++)
        {
            int tmp = newArray[i];
            int r = Random.Range(i, newArray.Length);
            newArray[i] = newArray[r];
            newArray[r] = tmp;
        }
        return newArray;
    }

    // Update is called once per frame
    void Update ()
    {
		
	}
}
