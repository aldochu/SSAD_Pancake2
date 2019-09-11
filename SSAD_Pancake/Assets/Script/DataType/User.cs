[System.Serializable]
public class User
{

    public string userid;
    public string email;
    public Avatar avatar = new Avatar();

    public User()
    {
    }

    public User(string username, string email)
    {
        this.userid = username;
        this.email = email;

    }
}
