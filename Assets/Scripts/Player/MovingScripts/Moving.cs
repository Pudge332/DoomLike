using UnityEngine.SceneManagement;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
//using YG.Example;

public class Moving : MonoBehaviour
{
    //[SerializeField] Canvas PauseCanvas;
    //[SerializeField] Slider sensSlider;
    //[SerializeField] Slider volumeSlider;
    public bool stopInput = false;
    [SerializeField] float deshPower;
    [SerializeField] float deshCd;
    [SerializeField] float deshTimer;
    [SerializeField] float yDel;
    [SerializeField] float angleOnWall;
    [SerializeField] Transform calculator;
    private Rigidbody _rb;
    [SerializeField] float speed;
    [SerializeField] float onWallSpeed;
    [SerializeField] float sens;
    [SerializeField] Camera mainCam;
    private float verticalAxis = 0;
    private float horizontalAxis = 0;
    private bool deshActive = true;
    private float timerD = 0;
    private float todeshverticalAxis = 0;
    private float todeshhorizontalAxis = 0;
    private Vector3 deshVectorForce;
    [SerializeField] private bool onWall = false;
    [SerializeField] private bool onIce = false;
    [SerializeField] private int countDesh = 2;
    [SerializeField] Image desh1;
    [SerializeField] Image desh2;
    [SerializeField] GunManager gunManager;
    private Transform currentWall = null;
    private float currentSpeed = 0;
    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        //PauseCanvas.enabled = false;
        _rb = GetComponent<Rigidbody>();
        currentSpeed = speed;
        //sensSlider.SetValueWithoutNotify(Proggres.Instance.sens / 20);
        //sensSlider.onValueChanged.AddListener((s) =>
        //{
        //    Proggres.Instance.sens = s * 20;
        //});
        //volumeSlider.SetValueWithoutNotify(Proggres.Instance.volume);
        //volumeSlider.onValueChanged.AddListener((v) =>
        //{
        //    AudioListener.volume = v;
        //    Proggres.Instance.volume = v;
        //});
    }
    // Update is called once per frame
    void FixedUpdate()
    {


        CameraControll();

        if (timerD > 0)
        {
            timerD -= Time.deltaTime;


            _rb.AddForce(deshVectorForce);
            //_rb.AddRelativeForce(mainCam.transform.forward * deshPower);
        }
        else
        {
            if (!stopInput)
            {
                MoveControll();
            }
        }
    }


private void Update()
    {
        //if ((Input.GetKeyDown(KeyCode.Tab)) || (Input.GetKeyDown(KeyCode.P)))
        //{
        //    if (PauseCanvas.enabled)
        //    {
        //        PauseCanvas.enabled = false;
        //        Cursor.lockState = CursorLockMode.Locked;
        //        Time.timeScale = 1f;
        //        //SaverTest.Save();
        //    }
        //    else
        //    {
        //        PauseCanvas.enabled = true;
        //        Cursor.lockState = CursorLockMode.None;
        //        Time.timeScale = 0f;
        //    }
        //}

        if ((Input.GetKeyDown(KeyCode.Space)) && (deshActive) && (!stopInput) && (countDesh > 0))
        {
            print("DESH");
            deshActive = false;
            todeshhorizontalAxis = horizontalAxis;
            todeshverticalAxis = verticalAxis;
            Invoke("ActivateDesh", deshCd);
            timerD = deshTimer;
            _rb.drag = 15f;
            deshVectorForce = DeshCalcualteNew();
            //countDesh--;
            UIToDesh();
        }

    }

    public void RestartPlayer()
    {
        currentWall = null;
        onWall = false;
        onIce = false;
        mainCam.transform.Rotate(new Vector3(0, 0, -mainCam.transform.eulerAngles.z));
        currentSpeed = speed;
        stopInput = false;
        //mainCam.GetComponent<Hook>().RestartPlayer();
    }

    private void UIToDesh()
    {
        switch (countDesh)
        {
            case 0:
                desh1.enabled = false;
                desh2.enabled = false;
                break;
            case 1:
                desh1.enabled = true;
                desh2.enabled = false;
                break;
            case 2:
                desh1.enabled = true;
                desh2.enabled = true;
                break;

        }
    }
    private Vector3 DeshCalcualteNew()
    {
        Vector3 direction = new Vector3();
        if ((todeshverticalAxis > 0) || ((todeshverticalAxis == 0)) && (todeshhorizontalAxis == 0))
        {
            direction = new Vector3(mainCam.transform.rotation.x, transform.rotation.y, 0);
            calculator.eulerAngles = direction;
            direction = calculator.transform.TransformVector(mainCam.transform.forward);
            Debug.Log(direction);
        }
        else
        {
            direction = transform.right * todeshhorizontalAxis;
        }
        return direction * deshPower;
    }
    private void ActivateDesh()
    {
        deshActive = true;
    }
    private void CameraControll()
    {
        float x = Input.GetAxis("Mouse X");
        float y = Input.GetAxis("Mouse Y");
        //float newSens = Proggres.Instance.sens * Time.deltaTime;
        float newSens = sens * Time.deltaTime;
        if (currentWall == null)
        {
            transform.eulerAngles += new Vector3(0, x * newSens, 0);
        }
        if (transform.eulerAngles.x != 0)
        {
            transform.eulerAngles = new Vector3(0, transform.eulerAngles.y, 0);
        }


        if (mainCam.transform.eulerAngles.x < 80f)
        {
            if (mainCam.transform.eulerAngles.x - y * newSens < 80f)
            {
                mainCam.transform.eulerAngles += new Vector3(-y * newSens, 0, 0);
            }
        }
        else
        {
            if (mainCam.transform.eulerAngles.x - y * newSens > 270)
            {
                mainCam.transform.eulerAngles += new Vector3(-y * newSens, 0, 0);
            }
        }
    }
    private void MoveControll()
    {
        verticalAxis = 0;
        horizontalAxis = 0;

        verticalAxis = Input.GetAxisRaw("Vertical");
        horizontalAxis = Input.GetAxisRaw("Horizontal");


        if ((verticalAxis == 0) && (horizontalAxis == 0))
        {
            if (!onIce)
            {
                _rb.drag = 0.2f;
            }
            else
            {
                _rb.drag = 0f;
            }
            gunManager.ChangeMovingSost(false);
        }
        else
        {
            gunManager.ChangeMovingSost(true);
            //OldMovingMethod();
            NewMovingMethod();
        }
    }

    private void OldMovingMethod()
    {
        _rb.drag = 0f;
        Vector3 velocity = new Vector3(horizontalAxis, 0, verticalAxis) * currentSpeed;
        if (!onWall)
        {
            velocity.y = _rb.velocity.y;
        }
        else
        {
            velocity.y = 2;
        }

        Vector3 worldVelocity = transform.TransformVector(velocity);


        _rb.velocity = worldVelocity;
    }


    private void NewMovingMethod()
    {
        _rb.drag = 1f;
        float upForce = 0f;
        if (onWall)
        {
            upForce = -_rb.velocity.y;
        }
        //_rb.AddRelativeForce(new Vector3(horizontalAxis, upForce, verticalAxis) * _rb.mass * 1.5f *  currentSpeed);
        _rb.AddRelativeForce(new Vector3(horizontalAxis, upForce, verticalAxis) * _rb.mass * 1.5f * Mathf.Lerp(currentSpeed, currentSpeed * 2f, currentSpeed / 15f));
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.TryGetComponent<Wall>(out Wall component))
        {
            onWall = true;

            currentWall = other.transform;
            //Блокировка угла обзора на стенах
            Debug.Log(transform.eulerAngles.y);
            if ((transform.eulerAngles.y < 91f) && (transform.eulerAngles.y > 270f))
            {
                transform.eulerAngles = new Vector3(transform.eulerAngles.x, currentWall.eulerAngles.y, 0);
                if (transform.position.x < currentWall.transform.position.x)
                {
                    mainCam.transform.Rotate(new Vector3(0, 0, angleOnWall));
                }
                else
                {
                    mainCam.transform.Rotate(new Vector3(0, 0, -angleOnWall));
                }
            }
            else
            {
                transform.eulerAngles = new Vector3(transform.eulerAngles.x, currentWall.eulerAngles.y + 180f, 0);
                if (transform.position.x < currentWall.transform.position.x)
                {
                    mainCam.transform.Rotate(new Vector3(0, 0, -angleOnWall));
                }
                else
                {
                    mainCam.transform.Rotate(new Vector3(0, 0, angleOnWall));
                }
            }
            currentSpeed = onWallSpeed;
            if (countDesh < 1)
            {
                countDesh = 1;
                UIToDesh();
            }
        }
        else
        {
            if (other.gameObject.TryGetComponent<IceFloor>(out IceFloor floor))
            {
                onIce = true;

                countDesh = 2;
                UIToDesh();

                currentSpeed = onWallSpeed;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.TryGetComponent<Wall>(out Wall component))
        {
            currentWall = null;
            transform.eulerAngles = new Vector3(0, transform.eulerAngles.y, 0);
            mainCam.transform.Rotate(new Vector3(0, 0, -mainCam.transform.eulerAngles.z));
            onWall = false;
            currentSpeed = speed;
        }
        else
        {
            if (other.gameObject.TryGetComponent<IceFloor>(out IceFloor floor))
            {
                onIce = false;
                currentSpeed = speed;
            }
        }
    }

    public void RestartLVL()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void GoMenu()
    {
        SceneManager.LoadScene(1);
    }
}