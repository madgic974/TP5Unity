using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class PlanetManager : MonoBehaviour
{
    public static PlanetManager current;
    public event Action<UDateTime> OnTimeChange;

    public event Action<Transform> OnTargetChange;
    private void Awake()
    {
        if (current == null)
        {
            current = this;
        }
        else
        {
            Destroy(obj: this);
        }
    }

    public void TimeChanged(DateTime newTime)
    {
        OnTimeChange?.Invoke(newTime);
    }
    [SerializeField]
    private UDateTime date;
    public UDateTime Date
    {
        get => date;
        set
        {
            date = value;
            TimeChanged(value.dateTime); //Fire the event
        }
    }
    public void TargetChanged(Transform newTarget)
    {
        OnTargetChange?.Invoke(newTarget);
    }
    [SerializeField]
    private Transform target;
    public Transform Target
    {
        get => target;
        set
        {
            target = value;
            TargetChanged(value); //Fire the event
        }
    }
}
