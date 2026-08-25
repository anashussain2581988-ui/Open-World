using UnityEngine;

public class VehicleShowroom : MonoBehaviour
{
    [Header("Vehicles")]
    public VehicleData[] vehicles;

    [Header("Showroom")]
    public Transform displayPoint;

    private GameObject currentVehicle;

    public void ShowVehicle(int index)
    {
        if (index < 0 || index >= vehicles.Length)
        {
            Debug.LogWarning("Invalid vehicle index.");
            return;
        }

        if (currentVehicle != null)
            Destroy(currentVehicle);

        VehicleData vehicle = vehicles[index];

        if (vehicle.vehiclePrefab == null)
        {
            Debug.LogWarning(
                "Vehicle prefab is missing for " +
                vehicle.vehicleName
            );
            return;
        }

        currentVehicle = Instantiate(
            vehicle.vehiclePrefab,
            displayPoint.position,
            displayPoint.rotation
        );
    }

    public bool BuyVehicle(
        int index,
        PlayerWallet wallet
    )
    {
        if (index < 0 || index >= vehicles.Length)
            return false;

        if (wallet == null)
        {
            Debug.LogWarning("PlayerWallet is missing.");
            return false;
        }

        VehicleData vehicle = vehicles[index];

        if (!wallet.CanAfford(vehicle.price))
        {
            Debug.Log("Not enough money.");
            return false;
        }

        if (!wallet.SpendMoney(vehicle.price))
            return false;

        Debug.Log(
            "Vehicle purchased: " +
            vehicle.vehicleName
        );

        return true;
    }
}
