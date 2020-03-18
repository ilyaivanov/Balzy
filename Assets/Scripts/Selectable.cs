using UnityEngine;

[ExecuteInEditMode]
public class Selectable : MonoBehaviour
{
    private bool isSelected;
    private Animator animator;
    public GameObject satelite;

    private void Start()
    {
        animator = GetComponent<Animator>();
        animator.Play(0, -1, Random.value);
    }

    void OnMouseDown()
    {
        isSelected = !isSelected;
        animator.SetBool("isSelected", isSelected);
        animator.SetTrigger("OnPress");
    }

    public void AssignBallColor(Color color)
    {
        GetComponent<Renderer>().material.SetColor("_Color", color);
    }

    public void AssignSateliteColor(Color color)
    {
        satelite.GetComponent<Renderer>().material.SetColor("_Color", color);
    }

    public void AssignSateliteShape(Mesh mesh, Vector3 scale)
    {
        satelite.GetComponent<MeshFilter>().mesh = mesh;
        Debug.LogWarning("Setting local scale " + scale);
        satelite.transform.localScale = scale;
    }
}