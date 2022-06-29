using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public int damage;
    public int speed;
    public bool explosion;
    public Sprite explosionSpr;
    public int expl_damage;
    public int expl_radius;
    public GameObject expl;

    void Start()
    {

    }

    void Update()
    {
        transform.Translate(new Vector3(0, speed * Time.deltaTime, 0));
    }

    // Столкновение снаряда с чем-либо
    void OnCollisionEnter(Collision col)
    {
        /*

        if (col.gameObject.GetComponent<Enemy>() != null) // При столкновении снаряда с врагом
        {
            
        }
        else if (false) // Тут надо заместо false определить столкновение с окружением
        {

        }

        */
    }
}
