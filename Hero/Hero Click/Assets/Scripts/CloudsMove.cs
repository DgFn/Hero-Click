using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudsMove : MonoBehaviour
{
    float speed = 1.2f;
    //Сообщает от какой до какой точки нужно двигаться
    private void FixedUpdate()
    {
        transform.position = Vector2.MoveTowards(transform.position, new Vector2(300, 3), speed*Time.deltaTime);
    }
    //Запуск уничтожения объекта
    public void MoveCloud()
    {
        StartCoroutine(DestroyCloud());
    }
    // Уничтожения облачков через 9 сек
    IEnumerator DestroyCloud()
    {
        yield return new WaitForSeconds(9);
        Destroy(gameObject);
    }

}
