[System.Serializable]
public class User
{

    public string userid;
    public string email;
    public Avatar avatar = new Avatar();
    public Universe universe = new Universe();

    public User()
    {
    }

    public User(string username, string email)
    {
        this.userid = username;
        this.email = email;

    }
}
