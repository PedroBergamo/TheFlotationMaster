using UnityEngine;
using TMPro;
using UnityEngine.UI;
using Assets.Scripts.Controllers;

public class WindowGraph : MonoBehaviour {

    [SerializeField] private Sprite CircleSprite;
    private RectTransform GraphContainer;
    private ChartLine Variable;
    public TextMeshProUGUI TMPro;
    public float xInterval;
    public float MaximumValue;
    public float R = 1;
    public float G = 1;
    public float B = 1;
    
    private void Start() {
        GraphContainer = transform.GetChild(0).GetComponent<RectTransform>();        
        Variable = new ChartLine(GraphContainer.rect.height);
        Variable.LineColor = new Color(R,G,B);
        Variable.MaximumValue = MaximumValue;
       
    }

    void Update() {
        Variable.xInterval = xInterval;
        if (TimeManager.SecondPassed)
        {
            AddPoint();
        }
    }

    private void AddPoint()
    {
        Variable.Value = float.Parse(TMPro.text);
        GameObject Circle = Variable.CreateGraphPoint();
        Circle.GetComponent<Image>().sprite = CircleSprite;
        Circle.transform.SetParent(GraphContainer, false);
        Circle.transform.localScale = new Vector2(10,10);
     } 
}
