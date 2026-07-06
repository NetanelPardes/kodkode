using System;

namespace day_2
{
    public class ImageMetadataManager
    {
        private int id;
        private double CloudCover;
        private string Sensor;

        public ImageMetadataManager(int ID, double cloudCover, string sensor)
        {
            id = ID;
            CloudCover = cloudCover;
            Sensor = sensor;
        }
        public bool IsValid()
        {
            if (CloudCover >= 0 && CloudCover <= 100)
            {
                return true;
            }
            return false;
        }
        public string Format()
        {
            return $"Image {id}: {CloudCover}% cloud {Sensor} ";
        }
        public void SaveToFile(string path)
        {
            File.WriteAllText(path, Format());
        }
        public int Score()
        {
            int priority;
            switch (Sensor)
            {
                case "SAR":
                    priority = 100;
                    break;
                case "EO":
                    priority = 60;
                    break;
                case "IR":
                    priority = 40;
                    break;
                default:
                    priority = 0;
                    break;
            }
            return priority - (int)CloudCover;
        }
        public static void Main()
        {
            ImageMetadataManager im1 = new ImageMetadataManager(1, 20, "SAR");
            ImageMetadataManager im2 = new ImageMetadataManager(2, 30, "EO");
            ImageMetadataManager im3 = new ImageMetadataManager(3, 10, "IR");

            Console.WriteLine(im1.IsValid());
            Console.WriteLine(im2.IsValid());
            Console.WriteLine(im3.IsValid());

            Console.WriteLine(im1.Format());
            Console.WriteLine(im2.Format());
            Console.WriteLine(im3.Format());

            Console.WriteLine(im1.Score());
            Console.WriteLine(im2.Score());
            Console.WriteLine(im3.Score());
        }
    }
}
