using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSwap : MonoBehaviour
{
    [SerializeField] private Transform Obj1_Player;
    [SerializeField] private Transform Obj2_Box;

    public bool isSwapping = false;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.X) && !isSwapping)
        {
            StartCoroutine(SwapObjects());
        }
    }

    IEnumerator SwapObjects()
    {
        isSwapping = true;

        Vector3 tempPosition = Obj1_Player.position;
        Obj1_Player.position = Obj2_Box.position;
        Obj2_Box.position = tempPosition;

        yield return new WaitForSeconds(0.5f); // Adjust this time to your preference
        isSwapping = false;
    }
}
