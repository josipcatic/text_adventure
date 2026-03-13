using UnityEngine;

public class Player : MonoBehaviour
{
    private bool hasAxe;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        hasAxe = false;
    }

    public bool GetAxe()
    {
        return hasAxe;
    }

    public void SetAxe()
    {
        hasAxe=true;
    }
}
