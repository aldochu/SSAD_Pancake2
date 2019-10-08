
[System.Serializable]
public class Avatar
{
    public string headgear;
    public string head;
    public string body;

    public Avatar()
    {
    }

    public Avatar(string headgear, string head, string body)
    {
        this.headgear = headgear;
        this.head = head;
        this.body = body;
    }
}
