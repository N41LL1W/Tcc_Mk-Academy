using UnityEngine;

public class CharacterController : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float rotationSpeed = 500f;

    private Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        // Movimentação pelo teclado
        float inputX = Input.GetAxis("Horizontal");
        float inputY = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(inputX, 0f, inputY) * moveSpeed * Time.deltaTime;
        transform.Translate(movement, Space.Self);

        // Rotação pelo movimento do mouse
        float mouseX = Input.GetAxis("Mouse X");
        Vector3 rotation = new Vector3(0f, mouseX, 0f) * rotationSpeed * Time.deltaTime;
        transform.Rotate(rotation);

        // Definir parâmetros para a Blend Tree
        animator.SetFloat("inputX", inputX);
        animator.SetFloat("inputY", inputY);

        // Verificar se o personagem está em movimento
        bool isMoving = Mathf.Abs(inputX) > 0.1f || Mathf.Abs(inputY) > 0.1f;
        animator.SetBool("isMoving", isMoving);
    }
}