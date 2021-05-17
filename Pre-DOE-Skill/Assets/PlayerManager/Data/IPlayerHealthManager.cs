using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public interface IPlayerHealthManager
{
    public void TakeDamage(float damage,EnemyDamageTypes type);
    public void CheckHealth();

    public void SwitchWeapon(InputAction.CallbackContext context);
    

    public void AddStatus(StatusTypes status);

}
