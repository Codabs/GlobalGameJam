using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EffectType
{
    CLICK_DAMAGE,
    CLICK_RESOURCES,
    AUTO_FREQUENCE,
    AUTO_DAMAGE,
    AUTO_RESOURCES,
    NB_ROOT_ATTACK,
    NB_ROOT_GENERATED,
    CRITICAL_PERCENT,
    CRITICAL_DAMAGE_MULTIPLICATOR,
    COST_UPGRADE,
    O2,
    DROP_FRUIT,
    FRUIT_BUFF,
}

public class FruitData
{
    public int level;
    public string seedShader;
    public string buff1, buff2, buff3, buff4, buff5;
    public int level_buff1, level_buff2, level_buff3, level_buff4, level_buff5;

    public FruitData()
    {
        this.level = level;
        this.seedShader = seedShader;
        this.buff1 = buff1;
        this.buff2 = buff2;
        this.buff3 = buff3;
        this.buff4 = buff4;
        this.buff5 = buff5;
        this.level_buff1 = level_buff1;
        this.level_buff2 = level_buff2;
        this.level_buff3 = level_buff3;
        this.level_buff4 = level_buff4;
        this.level_buff5 = level_buff5;
    }
}
