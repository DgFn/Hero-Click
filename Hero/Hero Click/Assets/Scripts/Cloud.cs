using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cloud : MonoBehaviour
{
    // Массив, который хранит облачка
    public List<GameObject> Clouds = new List<GameObject>();
  
    //Запуск облачков
    public void Start()
    {
        StartCloud();
    }


    // Создание облачков и передача информации для уничтожения
    public void StartCloud()
    {

        foreach (GameObject cloud in Clouds)
        {
            Instantiate(cloud, new Vector2(Random.Range((float)-5,-3),Random.Range((float)0,5)), Quaternion.identity);
            FindObjectOfType<CloudsMove>().MoveCloud();
        }
        StartCoroutine(WaitCloud());
    }
    // Запуск новых облачков через 10 сек
    IEnumerator WaitCloud()
    {
        yield return new WaitForSeconds(10);
        StartCloud();
    }
}
