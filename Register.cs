using System.Security.Cryptography.X509Certificates;

namespace BD90;

public class Register
{
    public List<Register> person = new();
    public int BorrowId { get; set; }
    public string PersonName { get; set; }
    public string SocialSecurityNr { get; set; }
    public DateTime DateBorrowed { get; set; }
    public DateTime ReturnDate { get; set; }
    public DateTime TimeWhenReturned { get; set; }
    public bool IsLate { get; set; }
    public TimeSpan TimeLate { get; set; }
    public int BorrowNr { get; set; }
    private int nextBorrowNr = 1000;

    public Register()
    {
        BorrowNr = GetNextBorrowNr();
        DateBorrowed = DateTime.Now;
        ReturnDate = DateBorrowed.AddSeconds(5);
        TimeWhenReturned = DateTime.Now;
        IsLate = FindOutIfMediaIsLate();
        TimeLate = CalculateTimeSpan();
    }
    public int GetNextBorrowNr()
    {
        return nextBorrowNr++;
    }
    //              FIXME: FindOutIfMediaIsLate FUNKAR EJ 
    public bool FindOutIfMediaIsLate()
    {
        if (TimeWhenReturned > ReturnDate)
        {
            IsLate = true;
        }
        else
        {
            IsLate = false;
        }
        return IsLate;
    }
    public TimeSpan CalculateTimeSpan()
    {
        TimeLate = TimeWhenReturned - ReturnDate;
        return TimeLate;
    }
}
