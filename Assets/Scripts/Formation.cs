using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// TODO: improve shit code
public class Formation : MonoBehaviour
{
    public float distance = 20f;
    public int size = 4;
    public float distanceBetweenMembers = 4f;

    Dictionary<Transform, Transform> memberToFormationTarget;
    Dictionary<Transform, bool> targetOccupied;

    Transform player;


    public void AddMember(Transform member)
    {
        if (!memberToFormationTarget.ContainsKey(member))
            memberToFormationTarget[member] = null;
    }


    public void DeleteMember(Transform member)
    {
        if (memberToFormationTarget.ContainsKey(member))
        {
            var target = memberToFormationTarget[member];
            memberToFormationTarget.Remove(member);
            if (target != null) targetOccupied[target] = false;
        }
    }


    public Transform GetTargetPosition(Transform member)
    {
        return memberToFormationTarget[member];
    }


    void Start()
    {
        memberToFormationTarget = new Dictionary<Transform, Transform>();
        targetOccupied = new Dictionary<Transform, bool>();

        player = GameObject.Find("PlayerShip").transform;

        CreateFormationTransforms();
    }


    void Update()
    {
        if (player == null) return;
        transform.position = new Vector3(0, 0, player.position.z + distance);

        List<Transform> members = new List<Transform>();
        foreach (var member in memberToFormationTarget.Keys)
            members.Add(member);

        foreach (var member in members)
        {
            UpdateMemberTarget(member);
        }
    }


    private void UpdateMemberTarget(Transform member)
    {
        var currentTarget = memberToFormationTarget.ContainsKey(member) ? memberToFormationTarget[member] : null;

        Transform bestTarget = currentTarget;
        float bestDistanceToCenter = (bestTarget == null) ? float.MaxValue : Vector3.Distance(bestTarget.position, transform.position);

        foreach (var valueKey in targetOccupied)
        {
            Transform target = valueKey.Key;
            bool occupied = valueKey.Value;

            float distance = Vector3.Distance(target.position, transform.position);
            if (distance < bestDistanceToCenter && !occupied)
            {
                bestTarget = target;
            }
        }
        memberToFormationTarget[member] = bestTarget;
        if (currentTarget != null) targetOccupied[currentTarget] = false; //free formation target
        if (bestTarget != null) targetOccupied[bestTarget] = true; //occupy formation target
    }


    private void CreateFormationTransforms()
    {
        Transform childTransformInit = new GameObject().transform;
        childTransformInit.parent = transform;
        childTransformInit.localPosition = new Vector3(0, 0, 0);
        targetOccupied.Add(childTransformInit, false);

        for (int i = 1; i <= size; i++)
        {
            for (int x = -1; x <= 1; x++)
            {
                for (int y = -1; y <= 1; y++)
                {
                    if ((x != 0 || y != 0))
                    {
                        Transform childTransform = new GameObject().transform;
                        childTransform.parent = transform;
                        childTransform.localPosition = new Vector3(x * distanceBetweenMembers * i, y * distanceBetweenMembers * i, 0);
                        targetOccupied.Add(childTransform, false);
                    }
                }
            }
        }

    }
}
