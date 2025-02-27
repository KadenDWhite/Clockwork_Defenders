using UnityEngine;
using System.Collections;

public class Node : MonoBehaviour
{
    public Color hoverColor;
    public Vector3 positionOffset;

    private GameObject turret;

    private Renderer r;
    private Color startColor;

    void Start()
    {
        r = GetComponent<Renderer>();
        startColor = r.material.color;
    }

    void OnMouseDown()
    {
        if (turret != null)
        {
            Debug.Log("You can't build here! - TODO: Display on screen.");
            return;
        }

        GameObject turretToBuild = BuildManager.instance.GetTurretToBuild();
        turret = (GameObject)Instantiate(turretToBuild, transform.position + positionOffset, transform.rotation);
    }

    void OnMouseEnter()
    {
        r.material.color = hoverColor;
    }

    void OnMouseExit()
    {
        r.material.color = startColor;
    }
}
