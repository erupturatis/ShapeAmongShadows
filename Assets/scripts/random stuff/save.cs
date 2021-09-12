using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
[System.Serializable]
public class save : MonoBehaviour
{

    int damage_mod=0;
    int hp_mod=0;

    static int veri = 1;
    static int primulload = 0;
    variabile_globale V;
    void Start()
    {
        V = GameObject.FindObjectOfType<variabile_globale>();
        if (veri == 1)
        {
            LoadFile();
            veri = 0;
        }
        //V.show_primul_load(ref primulload);

        if (primulload == 0)
        {
            //print("loaduit");
            //load initial stuff
            primulload = 1;
        }


        Cursor.lockState = CursorLockMode.None;

        SaveFile();
    }


    public void SaveFile()
    {   //print("saved");
        V.show_damage_modifier(ref damage_mod);
        V.show_hp_modifier(ref hp_mod);
        //print(hp_mod);
        string destination = Application.persistentDataPath + "/save.dat";
        FileStream file;

        if (File.Exists(destination)) file = File.OpenWrite(destination);
        else file = File.Create(destination);

        Game_data data = new Game_data(1, hp_mod, damage_mod);
        BinaryFormatter bf = new BinaryFormatter();
        bf.Serialize(file, data);
        file.Close();
    }



    public void LoadFile()
    {
        //print("Loaded");
        string destination = Application.persistentDataPath + "/save.dat";
        FileStream file;

        if (File.Exists(destination)) file = File.OpenRead(destination);
        else
        {
            Debug.LogError("File not found");
            return;
        }

        BinaryFormatter bf = new BinaryFormatter();
        Game_data data = (Game_data)bf.Deserialize(file);
        file.Close();



        V.load_hp_modifier(data.hp_modifier);
        //print(data.hp_modifier);
        V.load_damage_modifier(data.damage_modifier);
        V.load_primul_load(data.primul_load);



    }

}