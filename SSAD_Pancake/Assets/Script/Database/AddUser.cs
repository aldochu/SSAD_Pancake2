using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Firebase;
using Firebase.Unity.Editor;
using Firebase.Database;


public class AddUser : MonoBehaviour
{
    private DatabaseReference mDatabaseRef;
    // Start is called before the first frame update
    void Start()
    {
        // Set this before calling into the realtime database.
        FirebaseApp.DefaultInstance.SetEditorDatabaseUrl("https://ssadpancake.firebaseio.com/");
        // Get the root reference location of the database.
         mDatabaseRef = FirebaseDatabase.DefaultInstance.RootReference;

        getUser();
    }


    public void writeNewUser()
    {
        User user = new User("user1", "abc@email.com");
        string json = JsonUtility.ToJson(user);

        Avatar avatar = new Avatar("1", "2", "1", "2");
        string json2 = JsonUtility.ToJson(avatar);



        mDatabaseRef.Child("users").Child("abcdefghi").SetRawJsonValueAsync(json);
        mDatabaseRef.Child("users").Child("abcdefghi").Child("avatar").SetRawJsonValueAsync(json2);
    }

    public void updateUser()
    {
        mDatabaseRef.Child("users").Child("abcdefghi").Child("email").SetValueAsync("changeEmail");

    }

    public void getUserAvatar()
    {
        FirebaseDatabase.DefaultInstance
      .GetReference("users").Child("abcdefghi").Child("avatar")
      .GetValueAsync().ContinueWith(task => {
          if (task.IsFaulted)
          {
              // Handle the error...
          }
          else if (task.IsCompleted)
          {
              DataSnapshot snapshot = task.Result;
              string[] avatar = new string[4];
              avatar = snapshot.GetRawJsonValue().Split(',');

              for(int i = 0; i <4; i++)
              Debug.Log(avatar[i]);
              // Do something with snapshot...
          }
      });

    }

    public void getUser()
    {
        FirebaseDatabase.DefaultInstance
      .GetReference("users").Child("abcdefghi")
      .GetValueAsync().ContinueWith(task => {
          if (task.IsFaulted)
          {
              Debug.Log("Failed to connect");
              // Handle the error...
          }
          else if (task.IsCompleted)
          {
              DataSnapshot snapshot = task.Result;

              StaticVariable.UserProfile = JsonUtility.FromJson<User>(snapshot.GetRawJsonValue());

              Debug.Log("userid is: " + StaticVariable.UserProfile.userid + "  , email is: " + StaticVariable.UserProfile.email + "  , My avatar: " + StaticVariable.UserProfile.avatar.face);
          }
      });

    }

}
