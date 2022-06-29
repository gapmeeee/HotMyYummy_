using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // Основные переменные
    public int hp; // Здоровье
    public int speed; // Скорость перемещения
    public GameObject active_weapon; // Активное оружие
    public GameObject[] weapons; // Инвентарь с оружием  (ебаный массив, как же он заебал, как сука сделать так, чтобы он не ссылался на объекты, а их копировал?)

    // Вспомогательные переменные
    private Vector3 pos;
    private GameObject bullet;
    private double time;
    private Weapon weapon;
    private Bullet bul;
    private byte active;

    void Start()
    {
        time = 0;
        active = 0;
        active_weapon = Instantiate(weapons[0], transform.position, Quaternion.Euler(0,0,0));
        weapon = active_weapon.GetComponent<Weapon>();
    }

    void Update()
    {
        // Следование камеры за персонажем
        GameObject.Find("Main Camera").transform.position = new Vector3(transform.position.x,transform.position.y,-10);

        // Смерть
        if (hp <= 0)
        {
            // умереть х_х
        }

        // Перемещение персонажа
        if (Input.GetKey(KeyCode.W))
        {transform.Translate(Vector2.up*speed*Time.deltaTime);}
        if (Input.GetKey(KeyCode.S))
        {transform.Translate(Vector2.down*speed*Time.deltaTime);}
        if (Input.GetKey(KeyCode.A))
        {transform.Translate(Vector2.left*speed*Time.deltaTime);}
        if (Input.GetKey(KeyCode.D))
        {transform.Translate(Vector2.right*speed*Time.deltaTime);}

        // Поворот персонажа по направлению к мыши
        pos = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        transform.GetChild(0).eulerAngles = new Vector3(0, 0, Mathf.Rad2Deg * Mathf.Atan2(pos.y, pos.x) - 90);

        // Смена оружия (Не доделано)
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {if (active != 0) {if (active < weapons.Length) weapons[active] = active_weapon; Destroy(active_weapon); if (weapons.Length > 0)
        {active_weapon = Instantiate(weapons[0], transform.position, Quaternion.Euler(0,0,0)); weapon = active_weapon.GetComponent<Weapon>();}} active = 0;}
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {if (active != 1) {if (active < weapons.Length) weapons[active] = active_weapon; Destroy(active_weapon); if (weapons.Length > 1)
        {active_weapon = Instantiate(weapons[1], transform.position, Quaternion.Euler(0,0,0)); weapon = active_weapon.GetComponent<Weapon>();}} active = 1;}
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {if (active != 2) {if (active < weapons.Length) weapons[active] = active_weapon; Destroy(active_weapon); if (weapons.Length > 2)
        {active_weapon = Instantiate(weapons[2], transform.position, Quaternion.Euler(0,0,0)); weapon = active_weapon.GetComponent<Weapon>();}} active = 2;}
        if (Input.GetKeyDown(KeyCode.Alpha4))
        {if (active != 3) {if (active < weapons.Length) weapons[active] = active_weapon; Destroy(active_weapon); if (weapons.Length > 3)
        {active_weapon = Instantiate(weapons[3], transform.position, Quaternion.Euler(0,0,0)); weapon = active_weapon.GetComponent<Weapon>();}} active = 3;}
        if (Input.GetKeyDown(KeyCode.Alpha5))
        {if (active != 4) {if (active < weapons.Length) weapons[active] = active_weapon; Destroy(active_weapon); if (weapons.Length > 4)
        {active_weapon = Instantiate(weapons[4], transform.position, Quaternion.Euler(0,0,0)); weapon = active_weapon.GetComponent<Weapon>();}} active = 4;}
        if (Input.GetKeyDown(KeyCode.Alpha6))
        {if (active != 5) {if (active < weapons.Length) weapons[active] = active_weapon; Destroy(active_weapon); if (weapons.Length > 5)
        {active_weapon = Instantiate(weapons[5], transform.position, Quaternion.Euler(0,0,0)); weapon = active_weapon.GetComponent<Weapon>();}} active = 5;}
        if (Input.GetKeyDown(KeyCode.Alpha7))
        {if (active != 6) {if (active < weapons.Length) weapons[active] = active_weapon; Destroy(active_weapon); if (weapons.Length > 6)
        {active_weapon = Instantiate(weapons[6], transform.position, Quaternion.Euler(0,0,0)); weapon = active_weapon.GetComponent<Weapon>();}} active = 6;}
        if (Input.GetKeyDown(KeyCode.Alpha8))
        {if (active != 7) {if (active < weapons.Length) weapons[active] = active_weapon; Destroy(active_weapon); if (weapons.Length > 7)
        {active_weapon = Instantiate(weapons[7], transform.position, Quaternion.Euler(0,0,0)); weapon = active_weapon.GetComponent<Weapon>();}} active = 7;}
        if (Input.GetKeyDown(KeyCode.Alpha9))
        {if (active != 8) {if (active < weapons.Length) weapons[active] = active_weapon; Destroy(active_weapon); if (weapons.Length > 8)
        {active_weapon = Instantiate(weapons[8], transform.position, Quaternion.Euler(0,0,0)); weapon = active_weapon.GetComponent<Weapon>();}} active = 8;}
        if (Input.GetKeyDown(KeyCode.Alpha0))
        {if (active != 9) {if (active < weapons.Length) weapons[active] = active_weapon; Destroy(active_weapon); if (weapons.Length > 9)
        {active_weapon = Instantiate(weapons[9], transform.position, Quaternion.Euler(0,0,0)); weapon = active_weapon.GetComponent<Weapon>();}} active = 9;}

        // Ношение оружия
        if (active_weapon != null)
        {
            active_weapon.transform.position = transform.position;
        }

        // Перезарядка оружия
        if (Input.GetKey(KeyCode.R))
        {
            if (active_weapon != null)
            {
                if (weapon.bullet_quantity >=
                weapon.max_magazine - weapon.magazine)
                {
                    weapon.bullet_quantity -=
                    weapon.max_magazine - weapon.magazine;

                    weapon.magazine = weapon.max_magazine;
                }
                else
                {
                    weapon.magazine += weapon.bullet_quantity;
                    weapon.bullet_quantity = 0;
                }
                if (weapon.bullet_quantity != 0)
                {
                    time = weapon.recharge_time;
                    // Можно сюда вставить звук перезарядки (у каждого оружия свой звук)
                }
            }
        }

        // Надо
        if (time > 0)
        {time -= Time.deltaTime;}
    }

    // Атака (Активация будет где-то внутри Canvas)
    public void Attack()
    {
        if (active_weapon != null)
        {
            if (time <= 0)
            {
                if (weapon.is_cold_weapon)
                {
                    // Атака холодным оружием
                }
                else
                {
                    if (weapon.magazine == 0)
                    {
                        // Можно сюда вставить звук осечки (пустого выстрела)
                    }
                    else
                    {
                        weapon.magazine -= 1;
                        bullet = Instantiate(weapon.bullet, active_weapon.transform.GetChild(0).position, Quaternion.Euler(active_weapon.transform.GetChild(0).eulerAngles));
                        bullet.GetComponent<SpriteRenderer>().sprite = weapon.bullet_spr;
                        bul = bullet.GetComponent<Bullet>();
                        bul.damage = weapon.damage;
                        bul.speed = weapon.bul_speed;
                        bul.explosion = weapon.explosion;
                        bul.expl_damage = weapon.expl_damage;
                        bul.expl_radius = weapon.expl_radius;
                        bul.explosionSpr = weapon.explosionSpr;
                        // Можно сюда вставить звук выстрела (у каждого оружия свой звук)
                    }
                }

                time = weapon.frequency;
            }
        }
    }
}
