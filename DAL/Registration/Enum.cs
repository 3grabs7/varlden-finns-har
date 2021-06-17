namespace DAL.Registration
{
    public enum SchoolForm
    {
        Grundskola, Gymnasium, Sfi, AnnanVuxenutbildning, Övrig
    }

    public enum SfiSubject // can only be one
    {
        B, C, D
    }

    public enum ElmentarySubjects // can be many
    {

    }

    public enum GymnasieSubjects // can be many
    {

    }

    public enum OtherEducationSubjectOptions
    {

    }

    // Split grades based on schoolform
    public enum Grade // 1-3 Grade, 4-6 Grade, 7-9, Grade, 1-3 Grade
    {
        First, Ninth, 
    }

    public enum SfiStudieväg
    {
        Ett, Två, Tre
    }



    public enum MeetingType
    {
        Digitalt, Fysiskt
    }

    public enum OccassionCount
    {
        One, TwoToThree, ThreePlus
    }

    public enum Weekday
    {
        Måndag, Tisdag, Onsdag, Torsdag, Fredag, Lördag, Söndag
    }
}
