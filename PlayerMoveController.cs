using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoveController : MonoBehaviour {


    //Public
    public bool isMoveToEdgePosition;
    public bool isCanMovetoEdgePosition;
    public Vector3 edgePosVector3;
    public Score score;
    public BG_Instant bG_Instant;
    public AudioSource footStepsAudioSource;
    public Sounds sounds;
    

    //Private
    private Animator animator;
    private GameObject FirstEdgePositionGO;
    private CreatePlatformsController createPlatformsController;
    private CameraMove cameraMove;
    private PogruzhikMoveController pogruzhikMoveController;
    private GoldenCubeInstant goldenCubeInstant; 

    //Tags Variables
    private string edgePos = "FirstEdgePosition";

    private void Start()
    {        
        Time.timeScale = 1;
        animator = GetComponent<Animator>();
        FirstEdgePositionGO = GameObject.FindGameObjectWithTag(edgePos);
        createPlatformsController = FindObjectOfType<CreatePlatformsController>();
        cameraMove = FindObjectOfType<CameraMove>();
        pogruzhikMoveController = FindObjectOfType<PogruzhikMoveController>();
        goldenCubeInstant = FindObjectOfType<GoldenCubeInstant>();
    }

    private void Update()
    {
        //Player Start Moving
        if (isMoveToEdgePosition)
        {            
            animator.SetBool("isMove", true);
            transform.position = Vector3.MoveTowards(transform.position, new Vector3(FirstEdgePositionGO.transform.position.x, transform.position.y, transform.position.z), Time.deltaTime);
            if (transform.position.x == FirstEdgePositionGO.transform.position.x)
            {              
                animator.SetBool("isMove", false);
                createPlatformsController.InstPlat();
                cameraMove.isCanMoveCamera = false;
                isMoveToEdgePosition = false;
            }       
        }

        //Player Moving
        if(isCanMovetoEdgePosition)
        {
            transform.Translate(Vector3.right * Time.deltaTime * 2);
            animator.SetBool("isMove", true);
            sounds.FootstepsAudioPlay();
            
            if (transform.position.x >= edgePosVector3.x)
            {
                sounds.PlatformCompleteAudioPlay();
                animator.SetBool("isMove", false);
                createPlatformsController.InstPlat();
                pogruzhikMoveController.isMoveToPosRight = true;
                cameraMove.isCanMoveCamera = true;
                pogruzhikMoveController.isCanMovePogruzhicktoCameraCenter = true;
                cameraMove.isResetAllVar = true;
                goldenCubeInstant.InstantGoldenCube();
                score.AddScore();
                bG_Instant.isInstant = true;
                isCanMovetoEdgePosition = false;               
            }
        }    
    }
}
