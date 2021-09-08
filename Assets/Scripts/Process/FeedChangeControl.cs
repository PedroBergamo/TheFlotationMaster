using UnityEngine;

public class FeedChangeControl : MonoBehaviour {
    public float CuGrade;
    public float AsGrade;
    public bool FeedChangeTest;
	
	void Update () {
        if (FeedChangeTest) {
            FlotationCalculation.Controller.FeedCuGrade = CuGrade;
            FlotationCalculation.Controller.FeedAsGrade = AsGrade;
        }
    }
}
