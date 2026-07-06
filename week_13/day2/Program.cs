using System;
using static System.Net.Mime.MediaTypeNames;

namespace day_1
{

    public class ImageValidator
    {
        public bool IsValid(ImageMetadataManager image)
        {
            if (image.CloudCover >= 0 && image.CloudCover <= 100)
            {
                return true;
            }
            return false;
        }
    }
    public class CalcScore
    {
        public int Score(ImageMetadataManager image)
        {

            return image.GetPriority() - (int)image.CloudCover;
        }
    }
    public class ImageFormatter
    {
        public string Format(ImageMetadataManager image, int score)
        {
            return $"Image {image.Id}: {image.CloudCover}% cloud {image.GetSensorName()}, Score: {score}";
        }

    }
    public class FileImageStore
    {
        public void SaveToFile(string path, string text)
        {
            File.AppendAllText(path, text);
            FileInfo file = new FileInfo(path);
            file.IsReadOnly = false;
        }
    }
    public interface IImageOps
    {
        int Score();

        void Retask();

        void CalibrateThermal();
    }
    public abstract class ImageMetadataManager
    {
        public int Id
        {
            get;
            set;
        }
        public double CloudCover
        {
            get;
            set;
        }
        public ImageMetadataManager(int id, double cloudCover)
        {
            if (cloudCover < 0 || cloudCover > 100)
            {
                throw new ArgumentOutOfRangeException("Cloud cover must be between 0 and 100.");
            }
            Id = id;
            CloudCover = cloudCover;
        }
        public abstract int GetPriority();
        public abstract string GetSensorName();
    }

    public class SarImage : ImageMetadataManager, IImageOps
    {
        public SarImage(int id, double cloudCover) : base(id, cloudCover)
        {
        }
        public override int GetPriority()
        {
            return 100;
        }
        public override string GetSensorName()
        {
            return "SAR";
        }
        public int Score()
        {
            return GetPriority() - (int)CloudCover;
        }

        public void Retask()
        {
            throw new NotImplementedException(
                "SAR images cannot be retasked."
            );
        }

        public void CalibrateThermal()
        {
            throw new NotImplementedException(
                "SAR images do not have a thermal band."
            );
        }
    }
    public class EoImage : ImageMetadataManager
    {
        public EoImage(int id, double cloudCover) : base(id, cloudCover)
        {
        }
        public override int GetPriority()
        {
            return 60;
        }
        public override string GetSensorName()
        {
            return "EO";
        }
    }
    public class IrImage : ImageMetadataManager
    {
        public IrImage(int id, double cloudCover) : base(id, cloudCover)
        {
        }
        public override int GetPriority()
        {
            return 40;
        }
        public override string GetSensorName()
        {
            return "IR";
        }


    }
    public class QuickLookImage : ImageMetadataManager
    {
        public QuickLookImage(int id, double cloudCover)
            : base(id, cloudCover)
        {
        }

        public override int GetPriority()
        {
            throw new InvalidOperationException(
                "Quick-look images are not scored."
            );
        }

        public override string GetSensorName()
        {
            return "Quick Look";
        }
    }
    public class Repository<T> where T : ImageMetadataManager
    {
        private readonly List<T> _items;

        public Repository()
        {
            _items = new List<T>();
        }

        public void Add(T item)
        {
            _items.Add(item);
        }

        public IReadOnlyList<T> GetAll()
        {
            return _items;
        }

        public int Count()
        {
            return _items.Count;
        }
    }
    public class Program
    {
        public static void Main()
        {
            Repository<ImageMetadataManager> repository =
                new Repository<ImageMetadataManager>();

            repository.Add(new SarImage(1, 20));
            repository.Add(new EoImage(2, 30));
            repository.Add(new IrImage(3, 40));
            repository.Add(new SarImage(4, 50));
            repository.Add(new EoImage(5, 60));
            repository.Add(new IrImage(6, 70));
            repository.Add(new SarImage(7, 80));
            repository.Add(new EoImage(8, 85));
            repository.Add(new IrImage(9, 43));


            repository.Add(new QuickLookImage(10, 10));

            CalcScore scoreCalculator = new CalcScore();
            ImageFormatter formatter = new ImageFormatter();

            try
            {
                int totalScore = 0;

                foreach (ImageMetadataManager item in repository.GetAll())
                {
                    int score = scoreCalculator.Score(item);

                    Console.WriteLine(formatter.Format(item, score));

                    totalScore += score;
                }

                Console.WriteLine($"Total score: {totalScore}");
            }
            catch (InvalidOperationException ex)
            {
                Console.WriteLine($"The scoring loop crashed: {ex.Message}");
            }

            Console.WriteLine();

            SarImage sarImage = new SarImage(11, 25);

            try
            {
                sarImage.Retask();
            }
            catch (NotImplementedException ex)
            {
                Console.WriteLine(ex.Message);
            }

            try
            {
                sarImage.CalibrateThermal();
            }
            catch (NotImplementedException ex)
            {
                Console.WriteLine(ex.Message);
            }

            Console.WriteLine();

            try
            {
                repository.Add(new SarImage(12, 150));
            }
            catch (Exception ex)
            {
                Console.WriteLine($"bug{ex}");
            }

            Console.WriteLine($"Images stored: {repository.Count()}");

            try
            {
                int totalScore = 0;

                foreach (ImageMetadataManager item in repository.GetAll())
                {
                    int score = scoreCalculator.Score(item);

                    Console.WriteLine(formatter.Format(item, score));

                    totalScore += score;
                }

                Console.WriteLine($"Total score: {totalScore}");
            }
            catch (InvalidOperationException ex)
            {
                Console.WriteLine($"The scoring loop crashed: {ex.Message}");
            }
        }
    }
}




