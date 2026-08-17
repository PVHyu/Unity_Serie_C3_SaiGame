using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class SlideHP : BaseSlider
{
    [Header("HP")]
    [SerializeField] protected float maxHP = 100;
    [SerializeField] protected float currentHP = 70;

    protected override void FixedUpdate()
    {
        base.FixedUpdate();
        this.HPShowing();
    }

    protected virtual void HPShowing()
    {
        float hpPrecent = this.currentHP / this.maxHP;
        this.slider.value = hpPrecent;
    }

    protected override void OnChanged(float newValue)
    {
        Debug.Log("newValue: " + newValue);
    }

    public virtual void SetMaxHp(float maxHP)
    {
        this.maxHP = maxHP;
    }

    public virtual void SetCurrentHp(float currentHP)
    {
        this.currentHP = maxHP;
    }
}