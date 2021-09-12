using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class variabile_globale : MonoBehaviour
{
    public static int hp_modifier;
    public static int damage_modifier;

    public static int primul_load=0;

    save S;
    void Start()
    {
        S = GameObject.FindObjectOfType<save>();
    }

    public void add_damage_modifier(int k)
    {
        damage_modifier += k;
    }
    public void add_hp_modifier(int k)
    {
        hp_modifier += k;
    }

    public void increase_damage(int k)
    {
        damage_modifier += k;
    }
    public void increase_hp(int k)
    {
        hp_modifier += k;
    }
    public void show_damage_modifier(ref int k)
    {
        k = damage_modifier;
    }
    public void show_hp_modifier(ref int k)
    {
        k = hp_modifier;
    }
    public void show_primul_load(ref int k)
    {
        k = primul_load;
    }
    public void load_damage_modifier(int k)
    {
        damage_modifier = k;
    }
    public void load_hp_modifier(int k)
    {
        hp_modifier = k;
    }
    public void load_primul_load(int k)
    {
        primul_load = k;
    }

    public void reset_stats()
    {
        hp_modifier = 0;
        damage_modifier = 0;
        S.SaveFile();
    }

}
