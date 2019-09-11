[System.Serializable]
public class GetQuestion 
{
    public string UniqueKey;
    public UploadQuestion question = new UploadQuestion();

    public GetQuestion()
    {
    }
}
