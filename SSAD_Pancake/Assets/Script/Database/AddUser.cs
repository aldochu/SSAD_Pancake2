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
        // writeNewUser();

        //updateUserWorld("world1", "chap1", "111");
        //getUser("abcdefghi");
        updateAvatar("2", "1", "1");
    }



    public void writeNewUser()
    {
        User user = new User("user1", "abc@email.com");
        string json = JsonUtility.ToJson(user);

        Avatar avatar = new Avatar("1", "2", "1");
        string json2 = JsonUtility.ToJson(avatar);

        world world = new world("000", "000", "000", "000");
        string json3 = JsonUtility.ToJson(world);

        mDatabaseRef.Child("users").Child("abcdefghi").SetRawJsonValueAsync(json);
        mDatabaseRef.Child("users").Child("abcdefghi").Child("avatar").SetRawJsonValueAsync(json2);
        mDatabaseRef.Child("users").Child("abcdefghi").Child("universe").Child("world1").SetRawJsonValueAsync(json3);
        mDatabaseRef.Child("users").Child("abcdefghi").Child("universe").Child("world2").SetRawJsonValueAsync(json3);
        mDatabaseRef.Child("users").Child("abcdefghi").Child("universe").Child("world3").SetRawJsonValueAsync(json3);
        mDatabaseRef.Child("users").Child("abcdefghi").Child("universe").Child("world4").SetRawJsonValueAsync(json3);

    }

    public void updateUser()
    {
        mDatabaseRef.Child("users").Child("abcdefghi").Child("email").SetValueAsync("abc@email.com");

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

    public void getUser(string userid)
    {
        FirebaseDatabase.DefaultInstance
      .GetReference("users").Child(userid)
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

              Debug.Log("userid is: " + StaticVariable.UserProfile.userid + "  , email is: " + StaticVariable.UserProfile.email + "  , My avatar: " + StaticVariable.UserProfile.avatar.headgear);
              Debug.Log("world1: chap1: " + StaticVariable.UserProfile.universe.world1.chap1);
          }
      });

    }

    public void updateUserWorld(string world, string chap, string value)
    {
        mDatabaseRef.Child("users").Child("abcdefghi").Child("universe").Child(world).Child(chap).SetValueAsync(value);
    }

    public void updateAvatar(string headgear, string head, string body)
    {
        Avatar avatar = new Avatar(headgear, head, body);
        string json2 = JsonUtility.ToJson(avatar);

        mDatabaseRef.Child("users").Child("abcdefghi").Child("avatar").SetRawJsonValueAsync(json2);
    }
}
