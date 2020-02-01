using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PathCreator : MonoBehaviour
{
    [SerializeField] private List<Transform> checkpoints;
    private LineRenderer _lineRenderer;

    [SerializeField] private bool loadManually;
    
    // Start is called before the first frame update
    void Start()
    {
        if (!loadManually)
        {
            loadPoints();
        }
        drawLines();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void loadPoints()
    {
        checkpoints = transform.GetComponentsInChildren<Transform>().ToList();
        checkpoints.RemoveAt(0);
    }
    
    private void drawLines()
    {
        GameObject line = new GameObject();

        _lineRenderer = line.AddComponent<LineRenderer>();
        _lineRenderer.startWidth = 0.1f;
        _lineRenderer.endWidth = 0.1f;
        _lineRenderer.positionCount = this.checkpoints.Count;

        Vector3[] checkpoints = new Vector3[this.checkpoints.Count];

        for (int i = 0; i < this.checkpoints.Count; i++)
        {
            checkpoints[i] = new Vector3(this.checkpoints[i].position.x, this.checkpoints[i].position.y, 0f);
        }
        
        _lineRenderer.SetPositions(checkpoints);
    }
}
