using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class login : MonoBehaviour
{
    Firebase.Auth.FirebaseAuth auth;



    public InputField Cemail, Cpassword, email, password;

    public Text errMsg, loginErr;

    public GameObject CAccCanvas;

    public string err,err2;
    // Start is called before the first frame update
    void Start()
    {
        auth = Firebase.Auth.FirebaseAuth.DefaultInstance; 
    }

    void Update()
    {

        errMsg.text = err;
        loginErr.text = err2;
    }


    public void createAcc()
    {
        auth.CreateUserWithEmailAndPasswordAsync(Cemail.text, Cpassword.text).ContinueWith(task => {
            if (task.IsCanceled)
            {
                Debug.LogError("CreateUserWithEmailAndPasswordAsync was canceled.");
                err = "Invalid email or password";
                return;
            }
            if (task.IsFaulted)
            {
                //Debug.LogError("CreateUserWithEmailAndPasswordAsync encountered an error: " + task.Exception);
                err = task.Exception.InnerExceptions[0].InnerException.Message.ToString();
                return;
            }

            // Firebase user has been created.
            Firebase.Auth.FirebaseUser newUser = task.Result;
            Debug.LogFormat("Firebase user created successfully: {0} ({1})",
                newUser.DisplayName, newUser.UserId);

            //store userid
            StaticVariable.UserID = newUser.UserId;

            SceneManager.LoadScene("CreateAvatar");

        });
    }

    public void loginAcc()
    {
        auth.SignInWithEmailAndPasswordAsync(email.text, password.text).ContinueWith(task => {
            if (task.IsCanceled)
            {
                //Debug.LogError("SignInWithEmailAndPasswordAsync was canceled.");
                return;
            }
            if (task.IsFaulted)
            {
                //Debug.LogError("SignInWithEmailAndPasswordAsync encountered an error: " + task.Exception);
                err2 = task.Exception.InnerExceptions[0].InnerException.Message.ToString();
                return;
            }

            Firebase.Auth.FirebaseUser newUser = task.Result;
            Debug.LogFormat("User signed in successfully: {0} ({1})",
                newUser.DisplayName, newUser.UserId);

            //store userid
            StaticVariable.UserID = newUser.UserId;
        });
    }

    public void OpenCreateAccWindow()
    {
        CAccCanvas.GetComponent<Canvas>().enabled = true;
    }

    public void CloseCreateAccWindow()
    {
        CAccCanvas.GetComponent<Canvas>().enabled = false;
    }




}
