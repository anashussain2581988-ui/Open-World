using UnityEngine;

[CreateAssetMenu(
    fileName = "Mission",
    menuName = "Open World/Mission"
)]
public class MissionData : ScriptableObject
{
    [Header("Mission Information")]
    public string missionName = "New Mission";

    [TextArea(3, 6)]
    public string description = "Complete the mission.";

    [Header("Reward")]
    public int reward = 500;

    [Header("Objectives")]
    public int requiredObjectives = 1;
}
