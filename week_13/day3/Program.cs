using System;
using System.Runtime.Serialization;
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
    public interface IScoreable
    {
        int Score();
    }
    public interface IRetaskable
    {
        void Retask();
    }
    public interface ICalibrateThermal
    {

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
        public int score
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

    public class SarImage : ImageMetadataManager, IScoreable
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
            return 0;
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
    public class ImagePipeline
    {
        private readonly Istore _store;
        public ImagePipeline(Istore store)
        {
            _store = store;
        }
        public void ProcessImages(List<ImageMetadataManager> images)
        {
            foreach (var item in images)
            {
                _store.save(item);
            }
        }
    }
    public interface Istore
    {
        public void save(ImageMetadataManager image);
    }
    public class MemoryStore : Istore
    {
        List<ImageMetadataManager> Imm = new List<ImageMetadataManager>();
        public void save(ImageMetadataManager image)
        {
            Imm.Add(image);
        }
    }
    public class Program
    {
        public static void Main()
        {
            CalcScore scoreCalculator = new CalcScore();
            ImageFormatter formatter = new ImageFormatter();

            MemoryStore memoryStore = new MemoryStore();

            ImagePipeline pipeline = new ImagePipeline(memoryStore);

            List<ImageMetadataManager> images = new List<ImageMetadataManager>();

            images.Add(new SarImage(1, 20));
            images.Add(new EoImage(2, 30));
            images.Add(new IrImage(3, 40));
            images.Add(new SarImage(4, 50));
            images.Add(new EoImage(5, 60));
            images.Add(new IrImage(6, 70));
            images.Add(new SarImage(7, 80));
            images.Add(new EoImage(8, 85));
            images.Add(new IrImage(9, 43));

            pipeline.ProcessImages(images);

            foreach (ImageMetadataManager item in images)
            {
                int score = scoreCalculator.Score(item);
                Console.WriteLine(formatter.Format(item, score));
            }
        }
    }
}




