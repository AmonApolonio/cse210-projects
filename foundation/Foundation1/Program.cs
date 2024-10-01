using System;

class Program
{
    static void Main(string[] args)
    {
        List<Video> videos = new List<Video>();
        Video video1 = new Video("Lex Fridman", 5249, "MIT 6.S094: Deep Reinforcement Learning for Motion Planning");
        Video video2 = new Video("Lex Fridman", 124, "Donut-shaped C code that generates a 3D spinning donut");
        Video video3 = new Video("Lex Fridman", 4084, "Deep Learning Basics: Introduction and Overview");
        Video video4 = new Video("Lex Fridman", 723, "Mark Zuckerberg vs Lex Fridman in Jiu Jitsu");

        
        video1.AddComment(new Comment("chuyhable", "The concept of being able to virtually attend the class as it happens in MIT is awesome. Thank you Lex for taking the time to share the videos!"));
        video1.AddComment(new Comment("jacobrafati4200", "You are the best machine learning teacher I have ever seen. Thanks for generosity in teaching your knowledge :)"));
        video1.AddComment(new Comment("BhargavBardipurkar42", "thank you for the lecture."));
        videos.Add(video1);

        video2.AddComment(new Comment("sparkling_kat", "I love how we can just make any random thing and it can always be interesting."));
        video2.AddComment(new Comment("joefuentes2977", "This is the nerdiest flex I've seen in a while and is very impressive!"));
        video2.AddComment(new Comment("michaelfischer841", "the best programs are those which generate programs"));
        videos.Add(video2);

        video3.AddComment(new Comment("abrar4466", "I slept listening to you this morning and saw my mom reading deep learning books in my dream."));
        video3.AddComment(new Comment("franktfrisby", "I really admire the work that Lex is doing both at MIT and his podcast!"));
        video3.AddComment(new Comment("benlewis5312", "This robot seems more human everyday, but he still hasn't learned what to do with his hands"));
        videos.Add(video3);

        video4.AddComment(new Comment("tanishpanjwani3117", "Great training data. Can’t wait to see how the model does in production."));
        video4.AddComment(new Comment("arwildo", "It's impressive what the AI can do these days"));
        video4.AddComment(new Comment("shaneroberts2492", "More of these videos please. Be good to see some competitive rolls!!!"));
        videos.Add(video4);

        foreach (Video video in videos)
        {
            video.DisplayDetails();
        }
    }
}