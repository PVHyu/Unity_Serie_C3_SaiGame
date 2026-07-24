using System.Collections.Generic;
using UnityEngine;

public abstract class SpawnPoints : SaiMonoBehaviour
{
    [SerializeField] protected List<Transform> points = new();

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadPoints();
    }

    protected void LoadPoints()
    {
        if (this.points.Count > 0) return;

        this.points.Clear();
        foreach (Transform point in transform)
        {
            this.points.Add(point);
        }
    }

    public virtual Transform GetRandom()
    {
        if (this.points == null || this.points.Count == 0)
        {
            return null;
        }

        int rand = Random.Range(0, this.points.Count);
        return this.points[rand];
    }
}