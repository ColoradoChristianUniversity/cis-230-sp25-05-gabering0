using SkiaSharp;

namespace Client.Library;

public class Image
{
    private readonly string _directory;

    public Image(DirectoryInfo directory)
    {
        ArgumentNullException.ThrowIfNull(directory, nameof(directory));
        if (!directory.Exists)
        {
            throw new DirectoryNotFoundException($"Directory '{directory.FullName}' does not exist.");
        }

        _directory = directory.FullName;
    }

    public class Options
    {
        public int Width { get; set; } = 100;
        public int Height { get; set; } = 50;
        public int TextSize { get; set; } = 12;
        public int BorderWidth { get; set; } = 5;
        public int ImageQuality { get; set; } = 100;
        public SKEncodedImageFormat ImageFormat { get; set; } = SKEncodedImageFormat.Png;
        public SKColor BackgroundColor { get; set; } = SKColors.White;
        public SKColor BorderColor { get; set; } = SKColors.Red;
        public SKColor TextColor { get; set; } = SKColors.Black;
    }

    public bool TryCreateImage(string name, string text, Options options, out string path)
    {
        try
        {
            using var bitmap = new SKBitmap(options.Width, options.Height);
            using var canvas = new SKCanvas(bitmap);

            FillBackground(canvas);

            DrawBorder(canvas);

            DrawCenteredText(canvas);

            SaveImage(bitmap, name, out path);

            return true;
        }
        catch (Exception ex)
        {
            path = ex.Message;

            return false;
        }

        void FillBackground(SKCanvas canvas)
        {
            canvas.Clear(options.BackgroundColor);
        }

        void DrawBorder(SKCanvas canvas)
        {
            using var paint = new SKPaint
            {
                Color = options.BorderColor,
                StrokeWidth = options.BorderWidth,
                IsStroke = true
            };

            var rect = new SKRect(0, 0, options.Width, options.Height);
            canvas.DrawRect(rect, paint);
        }

        void DrawCenteredText(SKCanvas canvas)
        {
            using var paint = new SKPaint
            {
                Color = options.TextColor,
                IsAntialias = true
            };
            using var font = new SKFont(SKTypeface.Default, options.TextSize);

            font.MeasureText(text, out var rect, paint);
            var (x, y) = CalculateCenter(options.Width, options.Height, rect);

            var textBlob = SKTextBlob.Create(text, font)
                ?? throw new Exception("Failed to create text blob.");
            canvas.DrawText(textBlob, x, y, paint);

            static (float, float) CalculateCenter(int width, int height, SKRect rect)
            {
                var x = (width - rect.Width) / 2;
                var y = (height - rect.Height) / 2 - rect.Top;
                return (x, y);
            }
        }

        void SaveImage(SKBitmap bitmap, string name, out string path)
        {
            using var image = SKImage.FromBitmap(bitmap);
            using var data = image.Encode(options.ImageFormat, options.ImageQuality);

            path = BuildSaveFilePath(name);
            using var stream = File.OpenWrite(path);
            data.SaveTo(stream);

            string BuildSaveFilePath(string name)
            {
                Path.GetInvalidPathChars()
                    .ToList()
                    .ForEach(c => name = name.Replace(c.ToString(), "_"));
                return Path.Combine(_directory, name);
            }
        }
    }
}
