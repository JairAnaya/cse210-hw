using System;

class Program
{
    static void Main(string[] args)
    {
        List<Video> _videos = new List<Video>();

        Video video1 = new Video();
        _videos.Add(video1);
        video1._author = "Bitcraze";
        video1._title = "Crazyflie 2.0 in research";
        video1._length = 66;
        
        Comment Comment1 = new Comment();
        Comment1._name = "maxetjulie45";
        Comment1._text = "it remember me Big Hero 6 movie, the nano robots that doing task together!";
        video1._comments.Add(Comment1);

        Comment Comment2 = new Comment();
        Comment2._name = "zhounana7236";
        Comment2._text = "Coooooool~";
        video1._comments.Add(Comment2);

        Comment Comment3 = new Comment();
        Comment3._name = "pariawe";
        Comment3._text = "is it weirdo to ask about the name of the song in such a video? If it is not, the name pls? :)";
        video1._comments.Add(Comment3);
        
        Video video2 = new Video();
        _videos.Add(video2);
        video2._author = "Quanser";
        video2._title = "Leader Follower with the Autonomous Vehicle Research Studio";
        video2._length = 70;
        
        Comment Comment11 = new Comment();
        Comment11._name = "mohitinamdar1385";
        Comment11._text = "Hey can u please make a video of how u made this";
        video2._comments.Add(Comment11);

        Video video3 = new Video();
        _videos.Add(video3);
        video3._author = "Parrot";
        video3._title = "Parrot MiniDrone Jumping Sumo official video";
        video3._length = 44;
        
        Comment Comment111 = new Comment();
        Comment111._name = "silverdragon_goldenraichu_1227";
        Comment111._text = "Mission is a go, find and extract the hostage";
        video3._comments.Add(Comment111);

        Comment Comment222 = new Comment();
        Comment222._name = "Guruvey";
        Comment222._text = "I love the way the people at PARROT think. Keep em coming...great stuff!";
        video3._comments.Add(Comment222);

        Comment Comment333 = new Comment();
        Comment333._name = "explodingcucumber4231";
        Comment333._text = "My uncle has one of these. It's the best thing in the world! Most fun I've played with! Though, the camera could have better definition, but, hey! Who cares! It jumps, spin jumps, spins, does 180s, 360s and all kinds of fun stuff!";
        video3._comments.Add(Comment333);

        Comment Comment444 = new Comment();
        Comment444._name = "crunchyloops5203";
        Comment444._text = "used to own one of these. sad they discontinued this";
        video3._comments.Add(Comment444);

        foreach(Video v in _videos)
        {
            Console.WriteLine($"{v.DisplayList()}");
            Console.WriteLine(v.NumberOfComments());
            v.PrintComments();
        }
    }
}