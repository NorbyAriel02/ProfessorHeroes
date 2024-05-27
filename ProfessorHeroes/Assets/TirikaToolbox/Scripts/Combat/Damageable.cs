using System.Collections;
using System.Collections.Generic;
using TIRIKA;
using Unity.VisualScripting;
using UnityEngine;

public class Damageable : MonoBehaviour
{
    Health m_Health;

    void Start()
    {
        m_Health = GetComponent<Health>();        

        // Subscribe to damage & death actions
        m_Health.OnDie += OnDie;
        m_Health.OnDamaged += OnDamaged;
    }

    void OnDamaged(float damage, GameObject damageSource)
    {
        // TODO: damage reaction
    }

    void OnDie()
    {
        //TODO: this will call the OnDestroy function
        
    }
}
