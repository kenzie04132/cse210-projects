using System;

class Program
{
    static void Main(string[] args)
    {
        Job job1 = new Job();
        job1._jobTitle = "Software Engineer";
        job1._company = "Google";
        job1._startYear = 1998;
        job1._endYear = 2008;

        Job job2 = new Job();
        job2._jobTitle = "Front End Web Developer";
        job2._company = "Microsoft";
        job2._startYear = 2009;
        job2._endYear = 2017;

        Resume newResume = new Resume();
        newResume._name = "Mackenzie Ash";

        newResume._jobs.Add(job1);
        newResume._jobs.Add(job2);

        newResume.Display();
    }
}