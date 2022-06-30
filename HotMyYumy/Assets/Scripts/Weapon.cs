using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    // Общие переменные
    public int damage; // Урон
    public double frequency; // Скорострельность

    // Холодное оружие
    public bool is_cold_weapon; // Является ли холодным оружием
    public int length; // Дальность атаки

    // Оружие дальнего боя
    public Sprite bullet_spr; // Спрайт снаряда

    public int bul_speed; // Скорость полета снаряда
    public int max_magazine; // Размер магазина
    public int magazine; // Количество снарядов в магазине
    public int bullet_quantity; // Всего снарядов
    public double recharge_time; // Время перезарядки оружия

    public bool explosion; // Будет ли взрыв после столкновения у снаряда
    public Sprite explosionSpr; // Спрайт взрыва
    public int expl_damage; // Урон от взрыва
    public int expl_radius; // Радиус взрыва

    // Вспомогательные переменные
    public GameObject bullet;
    private Vector3 pos;

    void Start()
    {
        
    }

    void Update()
    {
        // Поворот оружия
        pos = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        transform.eulerAngles = new Vector3(0, 0, Mathf.Rad2Deg * Mathf.Atan2(pos.y, pos.x) - 90);
        pos = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.GetChild(0).position;
        transform.GetChild(0).eulerAngles = new Vector3(0, 0, Mathf.Rad2Deg * Mathf.Atan2(pos.y, pos.x) - 90);
    }

}
