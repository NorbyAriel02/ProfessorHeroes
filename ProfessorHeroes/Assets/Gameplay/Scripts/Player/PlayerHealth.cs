using System.Collections;
using System.Collections.Generic;
using TIRIKA;
using UnityEngine;

public class PlayerHealth : Health
{
    // Start is called before the first frame update
    void Start()
    {
        MaxHealth = MathHelper.GetY(PlayerStats.Instance.Health);        
    }

}
