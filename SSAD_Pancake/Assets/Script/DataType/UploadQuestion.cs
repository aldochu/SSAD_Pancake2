[System.Serializable]
public class UploadQuestion
{
    public string question;
    public string ans1;
    public string ans2;
    public string ans3;
    public string ans4;
    public string correctAns;

    public UploadQuestion()
    {
    }

    public UploadQuestion(string question, string ans1, string ans2, string ans3, string ans4, string correctAns)
    {
        this.question = question;
        this.ans1 = ans1;
        this.ans2 = ans2;
        this.ans3 = ans3;
        this.ans4 = ans4;
        this.correctAns = correctAns;
    }
}
