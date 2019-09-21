using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
public enum WeaponType { AR, Shotgun, Machinegun, Sniper }
public class SelectableWeapon : SelectableItem
{
    public WeaponType Type;
    public int Damage;
    public int SprayAngle;
    public int NumberOfBullets;
    public float FireRate;
}
