using UnityEngine;

[CreateAssetMenu(
    fileName = "Vehicle",
    menuName = "Open World/Vehicle"
)]
public class VehicleData : ScriptableObject
{
    [Header("Vehicle Information")]
    public string vehicleName = "New Vehicle";

    public int price = 10000;

    [Header("Vehicle Prefab")]
    public GameObject vehiclePrefab;

    [Header("Performance")]
    public float maxSpeed = 100f;

    public float acceleration = 10f;
}
