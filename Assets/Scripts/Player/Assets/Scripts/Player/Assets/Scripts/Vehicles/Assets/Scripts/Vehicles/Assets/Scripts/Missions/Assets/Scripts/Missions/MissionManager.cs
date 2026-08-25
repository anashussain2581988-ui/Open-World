using UnityEngine;

public class MissionManager : MonoBehaviour
{
    [Header("Player")]
    public PlayerWallet playerWallet;

    private MissionData currentMission;
    private int completedObjectives;

    public void StartMission(MissionData mission)
    {
        if (mission == null)
        {
            Debug.LogWarning("Mission is missing.");
            return;
        }

        currentMission = mission;
        completedObjectives = 0;

        Debug.Log(
            "Mission Started: " +
            currentMission.missionName
        );
    }

    public void CompleteObjective()
    {
        if (currentMission == null)
            return;

        completedObjectives++;

        Debug.Log(
            "Objective: " +
            completedObjectives +
            "/" +
            currentMission.requiredObjectives
        );

        if (completedObjectives >=
            currentMission.requiredObjectives)
        {
            CompleteMission();
        }
    }

    private void CompleteMission()
    {
        if (playerWallet != null)
        {
            playerWallet.AddMoney(
                currentMission.reward
            );
        }

        Debug.Log(
            "Mission Complete! Reward: $" +
            currentMission.reward
        );

        currentMission = null;
        completedObjectives = 0;
    }

    public bool HasActiveMission()
    {
        return currentMission != null;
    }
}
