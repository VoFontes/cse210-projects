using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        // Create videos
        Video video1 = new Video(
            "Learning C#",
            "Victor Fontes",
            300
        );

        Video video2 = new Video(
            "Introduction to Programming",
            "Code Academy",
            450
        );

        Video video3 = new Video(
            "How to Build a Website",
            "Web Developer",
            600
        );

        Video video4 = new Video(
            "C# Classes and Objects",
            "Programming World",
            500
        );

        // Create comments for video 1
        video1.AddComment(new Comment("John", "Great video!"));
        video1.AddComment(new Comment("Maria", "I learned a lot."));
        video1.AddComment(new Comment("David", "Very helpful explanation."));
        video1.AddComment(new Comment("Sarah", "Thank you for sharing."));

        // Create comments for video 2
        video2.AddComment(new Comment("Mike", "This was easy to understand."));
        video2.AddComment(new Comment("Lisa", "Great introduction!"));
        video2.AddComment(new Comment("James", "I enjoyed this video."));
        video2.AddComment(new Comment("Emily", "Very useful information."));

        // Create comments for video 3
        video3.AddComment(new Comment("Daniel", "I want to learn web development."));
        video3.AddComment(new Comment("Anna", "This helped me understand HTML."));
        video3.AddComment(new Comment("Chris", "Great tutorial!"));
        video3.AddComment(new Comment("Laura", "Looking forward to the next video."));

        // Create comments for video 4
        video4.AddComment(new Comment("Robert", "Classes are much clearer now."));
        video4.AddComment(new Comment("Jessica", "Good explanation."));
        video4.AddComment(new Comment("Mark", "I finally understand objects."));
        video4.AddComment(new Comment("Sophia", "Thanks for the lesson."));

        // Put all videos in a list
        List<Video> videos = new List<Video>();

        videos.Add(video1);
        videos.Add(video2);
        videos.Add(video3);
        videos.Add(video4);

        // Display all videos and their comments
        foreach (Video video in videos)
        {
            Console.WriteLine("----------------------------------------");
            Console.WriteLine($"Title: {video.GetTitle()}");
            Console.WriteLine($"Author: {video.GetAuthor()}");
            Console.WriteLine($"Length: {video.GetLength()} seconds");
            Console.WriteLine($"Number of comments: {video.GetNumberOfComments()}");
            Console.WriteLine();

            Console.WriteLine("Comments:");

            foreach (Comment comment in video.GetComments())
            {
                Console.WriteLine($"{comment.GetName()}: {comment.GetText()}");
            }

            Console.WriteLine();
        }
    }
}