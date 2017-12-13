using UnityEngine;

public class CubeInteraction : MonoBehaviour {

    public float RotationSpeed = 100f;
    private Material material;
    private Color activated = Color.green;
    private Color selected = Color.blue;
    private Color idle = Color.gray;

    private bool IsActive { get; set; }

	// Use this for initialization
	void Start () {
        material = GetComponent<Renderer>().material;
        IsActive = false;
        ChangeColor(idle);
	}
	
	// Update is called once per frame
	void Update () {
        if (IsActive)
        {
            float yRotation = Time.deltaTime * RotationSpeed;
            transform.Rotate(new Vector3(0f, yRotation, 0f));
        }
	}

    public void OnActivated()
    {
        IsActive = !IsActive;
        ChangeColor(IsActive ? activated : selected);
    }

    public void OnSelected(bool isSelected)
    {
        if (!IsActive)
        {
            ChangeColor(isSelected ? selected : idle);
        }
    }

    private void ChangeColor(Color color)
    {
        material.color = color;
    }
}
