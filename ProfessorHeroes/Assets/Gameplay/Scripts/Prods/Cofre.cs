using System.Collections;
using System.Collections.Generic;
using TIRIKA;
using UnityEditor.Localization.Plugins.Google.Columns;
using UnityEngine;


public class Cofre : MonoBehaviour
{
    [Header("Particles")]
    public ParticleSystem particle;

    [Header("Oscillation Settings")]
    public ParameterOsillate osillate;

    [Header("SFX")]
    public AudioClip sfx;

    Health m_Health;
    void Start()
    {
        m_Health = GetComponent<Health>();

        // Subscribe to damage & death actions
        m_Health.OnDie += OnDie;
        m_Health.OnDamaged += OnDamaged;

        osillate.initialPosition = transform.position;
        osillate.transform = transform;
    }

    void OnDamaged(float damage, GameObject damageSource)
    {
        // TODO: damage reaction
        particle.Play();
        MoveGameObject.TakeOscillate(this, osillate);        
        AudioManager.Instance.PlayOnShot(sfx);
    }

    void OnDie()
    {
        //TODO: this will call the OnDestroy function
        Destroy(gameObject);
    }    
}
