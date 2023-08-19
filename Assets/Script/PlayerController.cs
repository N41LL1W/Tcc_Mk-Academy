using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float rotationSpeed = 500f;
    public float jumpForce = 8f;
    public float gravity = 20f;
    public float runMultiplier = 2f;
    public KeyCode runKey = KeyCode.LeftShift;
    public KeyCode jumpKey = KeyCode.Space;

    private Animator animator;
    private CharacterController characterController;
    private Vector3 moveDirection;
    private bool isJumping = false;

    private void Start()
    {
        animator = GetComponent<Animator>();
        characterController = GetComponent<CharacterController>();
    }

    private void Update()
    {
        // Movimentação pelo teclado
        float inputX = Input.GetAxis("Horizontal");
        float inputY = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(inputX, 0f, inputY) * moveSpeed * Time.deltaTime;

        // Verificar se está correndo e aplicar o multiplicador de velocidade
        if (Input.GetKey(runKey))
        {
            movement *= runMultiplier;
        }

        // Verificar se está pulando
        if (characterController.isGrounded)
        {
            isJumping = false;
            // Pulo
            if (Input.GetKeyDown(jumpKey))
            {
                moveDirection.y = jumpForce;
                isJumping = true;
            }
        }

        moveDirection.y -= gravity * Time.deltaTime;

        // Movimento com gravidade
        characterController.Move(moveDirection * Time.deltaTime);

        // Movimento sem gravidade
        transform.Translate(movement, Space.Self);

        // Rotação pelo movimento do mouse
        float mouseX = Input.GetAxis("Mouse X");
        Vector3 rotation = new Vector3(0f, mouseX, 0f) * rotationSpeed * Time.deltaTime;
        transform.Rotate(rotation);

        // Definir parâmetros para a Blend Tree de corrida
        animator.SetFloat("inputX", inputX);
        animator.SetFloat("inputY", inputY);

        // Verificar se o personagem está em movimento
        bool isMoving = Mathf.Abs(inputX) > 0.1f || Mathf.Abs(inputY) > 0.1f;
        animator.SetBool("isMoving", isMoving);

        // Verificar se está correndo
        bool isRunning = Input.GetKey(runKey) && isMoving;
        animator.SetBool("isRunning", isRunning);

        // Definir parâmetro para o pulo
        animator.SetBool("isJumping", isJumping);
    }
}
