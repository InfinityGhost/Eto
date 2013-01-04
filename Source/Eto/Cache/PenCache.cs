using System.Collections.Generic;
using Eto.Drawing;

namespace Eto.Cache
{
    struct PenKey
    {
        public Generator Generator { get; set; }
        public float Width { get; set; }
        public Color Color { get; set; }
        public PenAlignment PenAlignment { get; set; }
        public DashStyle DashStyle { get; set; }
    }

    /// <summary>
    /// A singleton app wide cache of pens
    /// </summary>
    public static class PenCache
    {
        private static Dictionary<PenKey, Pen> pens =
            new Dictionary<PenKey, Pen>();

        public static Pen GetPen(
            Generator g, 
            Color color)
        {
            return GetPen(
                g,
                color,
                1f,
                PenAlignment.Center,
                DashStyle.Solid);
        }

        public static Pen GetPen(
            Generator g, 
            Color color,
            float width)
        {
            return GetPen(
                g,
                color,
                width,
                PenAlignment.Center,
                DashStyle.Solid);
        }

        public static Pen GetPen(
            Generator g,
            Color color,
            float width,
            PenAlignment alignment,
            DashStyle dashStyle)
        {
            Pen result = null;

            var generator =
                g ?? Generator.Current;

            var key = new PenKey()
            {
                Generator = generator,
                Color = color,
                Width = width,
                DashStyle = dashStyle,
                PenAlignment = alignment
            };

            if (pens != null &&
                !pens.TryGetValue(key, out result))
            {
                result = new 
                    Pen(generator, color, width, alignment, dashStyle);

                pens[key] = result;
            }

            return result;
        }
    }
}
