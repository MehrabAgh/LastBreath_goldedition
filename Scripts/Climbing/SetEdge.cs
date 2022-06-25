using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetEdge : MonoBehaviour
{
    [SerializeField] private Transform edgeLeft, edgeRight;
    [SerializeField] private Climbing GetClimbing;

    public Vector3 posLeft, posRight;

    private void SetParentHitOBj(CheckClimb parent)
    {
        edgeLeft.SetParent(parent.HitObject);
        edgeRight.SetParent(parent.HitObject);
    }

    private void Update()
    {
        Vector3 offset = transform.right * (-transform.localScale.y / 2f) * -1f;
        if (GetClimbing._climbing)
        {
            var res = PlayerConstructor.instance.GetComponent<Climbing>().res;
            print(res);
            if ( res == 2)
            {
                print("2::2");
                SetParentHitOBj(PlayerConstructor.instance.climbChecker.checks[0]);
            }
            if (res == 1)
            {
                print("1::1");
                SetParentHitOBj(PlayerConstructor.instance.climbChecker.checks[1]);
            }
            PlayerConstructor.instance.IK.solver.leftHandEffector.target = edgeRight;
            PlayerConstructor.instance.IK.solver.rightHandEffector.target = edgeLeft;
            edgeLeft.localPosition = offset + posLeft;
            edgeRight.localPosition = offset + posRight;
            GetClimbing._climbing = false;
        }
    }
}
