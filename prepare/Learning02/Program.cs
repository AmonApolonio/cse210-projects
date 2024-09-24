using System;

class Program
{
    static void Main(string[] args)
    {
        Job job1 = new Job();
        job1._jobTitle = "Fullstack Web Developer";
        job1._company = "Google";
        job1._startYear = 2014;
        job1._endYear = 2016;

        Job job2 = new Job();
        job2._jobTitle = "Tech Lead";
        job2._company = "Facebook";
        job2._startYear = 2016;
        job2._endYear = 2024;

        Resume myResume = new Resume();
        myResume._name = "Patrick Shyu";

        myResume._jobs.Add(job1);
        myResume._jobs.Add(job2);

        myResume.Display();
    }
}