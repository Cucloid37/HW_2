using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyEnemy : MonoBehaviour
{

    [SerializeField] private int _health;
    [SerializeField] private GameObject _pointEnd;
    private bool ItIsBomb;
    private Transform _pointE;

    private void Start()
    {
        _pointE = _pointEnd.GetComponent<Transform>();            
        Debug.Log($"Точка, в которую мы хотим придти {_pointE.position}");
    }

    private void Update()
    {
        #region ItIsBomb???
        if (ItIsBomb)
        {
            BigBadaBum f = new BigBadaBum(); // создаем экземпляр класса бомбы
            f.Bum(gameObject); // и передаем в функцию объект врага
            Debug.Log($"Бомба сработала? {ItIsBomb}! Осталось {_health} здоровья!");
        }
        #endregion

        
    }

    private void FixedUpdate()
    {
        transform.position = Vector3.MoveTowards(transform.position, _pointE.position, 0.2f * Time.deltaTime);
        Debug.Log(transform.position);
    }

    // При столкновение с бомбой активируем логическую переменную ItIsBomb
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Bomb")
        {
            ItIsBomb = true;
        }
    }

    public void Hurt(int damage)
    {
        print("Ouch: " + damage);
        Debug.Log($"Бомба сработала? {ItIsBomb}! Осталось {_health} здоровья!");

        _health -= damage;

        if (_health <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        Destroy(gameObject);
    }
}
