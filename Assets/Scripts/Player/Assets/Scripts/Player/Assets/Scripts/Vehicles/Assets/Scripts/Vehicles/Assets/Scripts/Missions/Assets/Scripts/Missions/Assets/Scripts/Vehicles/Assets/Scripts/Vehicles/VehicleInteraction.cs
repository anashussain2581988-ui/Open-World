using UnityEngine;

public class VehicleInteraction : MonoBehaviour
{
    [Header("References")]
    public Transform driverSeat;
    public Transform exitPoint;
    public CarController carController;

    private GameObject player;
    private bool playerInside;

    private void Start()
    {
        if (carController == null)
            carController = GetComponent<CarController>();
    }

    public void EnterVehicle(GameObject playerObject)
    {
        if (playerInside || playerObject == null)
            return;

        player = playerObject;
        playerInside = true;

        CharacterController controller =
            player.GetComponent<CharacterController>();

        if (controller != null)
            controller.enabled = false;

        if (driverSeat != null)
        {
            player.transform.SetParent(driverSeat);
            player.transform.localPosition = Vector3.zero;
            player.transform.localRotation = Quaternion.identity;
        }

        player.SetActive(false);

        if (carController != null)
            carController.SetDriving(true);

        Debug.Log("Player entered vehicle.");
    }

    public void ExitVehicle()
    {
        if (!playerInside || player == null)
            return;

        if (carController != null)
            carController.SetDriving(false);

        player.SetActive(true);

        player.transform.SetParent(null);

        if (exitPoint != null)
        {
            player.transform.position =
                exitPoint.position;

            player.transform.rotation =
                exitPoint.rotation;
        }

        CharacterController controller =
            player.GetComponent<CharacterController>();

        if (controller != null)
            controller.enabled = true;

        playerInside = false;

        Debug.Log("Player exited vehicle.");

        player = null;
    }

    public bool IsPlayerInside()
    {
        return playerInside;
    }
}
