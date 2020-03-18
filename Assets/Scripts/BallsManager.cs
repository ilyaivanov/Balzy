using System;
using System.Linq;
using UnityEngine;
using Random = UnityEngine.Random;

public class BallsManager : MonoBehaviour
{
    public GameObject[] spheres;
    public bool trigger;

    public Mesh cubeMesh;
    public Mesh sphereMesh;
    public Mesh cylinderMesh;


    private string[] baseColorScheme = {"#512b58", "#fe346e", "#d2fafb"};
    private Color[] colors;

    private bool lastValue;

    void Start()
    {
        colors = baseColorScheme.Select(ParseColor).ToArray();
    }

    void Update()
    {
        if (trigger != lastValue)
        {
            lastValue = trigger;
            for (var i = 0; i < spheres.Length; i++)
            {
                setBallAttributes(i, Random.Range(0, 3), Random.Range(0, 3), Random.Range(0, 3));
            }
        }
    }

    void setBallAttributes(int ballNumber, int feature1, int feature2, int feature3)
    {
        var ball = spheres[ballNumber];
        assignFeature1(ball, feature1);
        assignFeature2(ball, feature2);
        assignFeature3(ball, feature3);
    }


    void assignFeature1(GameObject sphere, int feature)
    {
        sphere.GetComponent<Selectable>().AssignBallColor(colors[feature]);
    }

    void assignFeature2(GameObject sphere, int feature)
    {
        sphere.GetComponent<Selectable>().AssignSateliteColor(colors[feature]);
    }

    void assignFeature3(GameObject sphere, int feature)
    {
        var shapes = new[] {cubeMesh, sphereMesh, cylinderMesh};
        var scales = new[] {Vector3.one * 0.2f, Vector3.one * 0.3f, new Vector3(0.2f, 0.15f, 0.2f)};
        sphere.GetComponent<Selectable>().AssignSateliteShape(shapes[feature], scales[feature]);
    }

    Color ParseColor(string hex)
    {
        Color c;
        ColorUtility.TryParseHtmlString(hex, out c);
        return c;
    }
}