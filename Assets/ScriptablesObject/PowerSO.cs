using Unity.VisualScripting;
using UnityEngine;

[CreateAssetMenu(fileName = "PowerUp", menuName = "PowerUpSO")]
public class PowerSO : ScriptableObject
{
    [SerializeField] private string powerUpType;
    [SerializeField] private float valueChange;
    [SerializeField] private float powerUpDuration;


    public string GetPowerUpType => powerUpType;
    public float GetValueChange => valueChange;
    public float GetPowerUpDuration => powerUpDuration;

}
