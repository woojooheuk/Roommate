using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Firebase.Auth;
public class Singin : MonoBehaviour
{
    public TMPro.TMP_InputField emailInputField, passwordInputField;
    string buttonTag;
    FirebaseAuth auth;

    private void Start()
    {
        auth = FirebaseAuth.DefaultInstance;
        buttonTag = gameObject.tag;
    }

    public void ChangeScene()
    {
        if (buttonTag == "Main")
        {
            string email = emailInputField.text;
            string password = passwordInputField.text;

            auth.SignInWithEmailAndPasswordAsync(email, password).ContinueWith(task =>
            {
                if (task.IsCanceled)
                {
                    Debug.LogError("로그인 취소됨");
                    return;
                }

                if (task.IsFaulted)
                {
                    Debug.LogError("오류 발생:" + task.Exception);
                    return;
                }

                FirebaseUser user = auth.CurrentUser;
                Debug.Log("로그인 성공");
            });
        }
        SceneManager.LoadScene(buttonTag);
    }
}