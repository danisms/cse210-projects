using System;

class Program
{
    static void Main(string[] args)
    {
        Console.Clear();
        // change console color
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine("\t\t\tYOUTUBE VIDEOS");
        // Create Video List
        List<Video> youTubeVideos = new List<Video>();
        // CREATE VIDEO and COMMENTS OBJECTS
        // Video 1
        Video video1 = new Video("Baby Virtuoso Shocked at the Audition to World Music Academy", "AKSTAR", 1689);
        // create video comments and add it to video
        Comment comment11 = new Comment("Jess-737", "I wish everyone could be as POLITE and patient as the first interviewer.");
        video1.AddComment(comment11);
        Comment comment12 = new Comment("KhorenMusic77", "AKSTAR make more English videos");
        video1.AddComment(comment12);
        Comment comment13 = new Comment("Vasilistsoulis8968", "It was awesome! Playing a guitar with a sushi stick? Amazing!");
        video1.AddComment(comment13);
        Comment comment14 = new Comment("Marcosmarcou4630", "Your English has really improved! Your music is always impressive and the way you have fun with it is awesome.");
        video1.AddComment(comment14);
        Comment comment15 = new Comment("Mytriumph650pre-unit", "The last performance there was a glitch you went in and out of being a youngster to a older teen and she didn't catch it. Funny");
        video1.AddComment(comment15);
        // add video to youTubeVideos List
        youTubeVideos.Add(video1);


        // Video 2
        List<Comment> video2Comments;
        // create video comments
        video2Comments = [
            new Comment("JuniorFan7a", "You still need a reasonable amount of coding knowledge to even work alongside AI in the first place, so no, learning coding will never be worthless."),
            new Comment("Azmalawasaf4212", "This is the most sensible answer to this burning question I have seen yet. Thanks for this amazing explanation. Couldn't agree more!"),
            new Comment("Robertj.3682", "You are a life saver, mosh. Thank You!"),
            new Comment("Productiveworks-ki8ub", "THANK YOU SO MUCHHHH for making this video!!!!!!"),
            new Comment("Rajas_word_20", "THANK YOU SO MUCHHH for making this video!!!!!!! Watched the tech lead video a couple of weeks ago and I was so depressed and wanted to give up my childhood dream of becoming a software engineer"),
            new Comment("Six3sin", "Thanks, Mosh, you're an uplifter-- not that I was going to stop learning or anything haha.")];
        Video video2 = new Video("Is Coding Still Worth Learning in 2024", "Programming with Mosh", 559, video2Comments);
        // add video to youTubeVideos List
        youTubeVideos.Add(video2);

        // Video 3
        Video video3 = new Video("I Built a 3D Developer Portfolio Website // Three.js + React + Tailwind", "ForestKnight", 496);
        Comment comment31 = new Comment("TannerBarcelos", "new style goes hard");
        video3.AddComment(comment31);
        Comment comment32 = new Comment("Ypathan420", "love the new style");
        video3.AddComment(comment32);
        Comment comment33 = new Comment("Chrisjones8829", "This is amazing. You are amazing. Very inspiring and motivating, as well.");
        video3.AddComment(comment33);
        // add video to youTubeVideos List
        youTubeVideos.Add(video3);

        // Display videos and their info
        int count = 1;
        foreach (Video video in youTubeVideos)
        {
            Console.WriteLine("\n------------------------------------------------------------------------");
            Console.WriteLine($"\t\t\t  VIDEO ({count})");
            Console.WriteLine("------------------------------------------------------------------------");
            // display video info
            video.DisplayInfo();
            // increase count
            count++;
        }
    }
}