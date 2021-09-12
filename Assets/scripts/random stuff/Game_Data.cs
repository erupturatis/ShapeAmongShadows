[System.Serializable]

public class Game_data
{
    public int hp_modifier = 0;
    public int damage_modifier = 0;
    public int primul_load = 0;

    public Game_data(int primul_loadf, int hp_modifierf, int damage_modifierf)
    {
        hp_modifier = hp_modifierf;
        damage_modifier = damage_modifierf;
        primul_load = primul_loadf;
    }
}
