﻿using RayVE.Extensions;
using System;
using System.Collections.Generic;
using static RayVE.Constants;
using static System.Math;

namespace RayVE
{
    public struct Color : IEquatable<Color>
    {
        public readonly double R { get; }
        public readonly double G { get; }
        public readonly double B { get; }

        public Color(double red, double green, double blue)
        {
            R = red;
            G = green;
            B = blue;
        }

        public Color(Color color)
            : this(color.R, color.G, color.B)
        { }

        public IEnumerable<string> ToPPM(int maxValue)
            => new List<string>()
            {
                $"{GetPPMValue(R, maxValue)}",
                $"{GetPPMValue(G, maxValue)}",
                $"{GetPPMValue(B, maxValue)}"
            };

        private static int GetPPMValue(double rawValue, int maxValue)
            => Convert.ToInt32((rawValue * maxValue).Clamp(0.0d, maxValue));

        public override string ToString()
            => $"R:{R} G:{G} B:{B}";

        #region Operators

        public static Color operator +(Color left, Color right)
            => new Color(left.R + right.R,
                         left.G + right.G,
                         left.B + right.B);

        public static Color operator -(Color left, Color right)
            => new Color(left.R - right.R,
                         left.G - right.G,
                         left.B - right.B);

        public static Color operator *(Color color, double scalar)
            => new Color(color.R * scalar, color.G * scalar, color.B * scalar);

        public static Color operator *(Color color, UDouble scalar)
            => color * scalar.AsDouble();

        public static Color operator *(Color left, Color right)
            => new Color(left.R * right.R, left.G * right.G, left.B * right.B);

        public static bool operator ==(Color left, Color right)
        {
            if (ReferenceEquals(left, right))
                return true;

            // no null check because Color is a struct

            if (left.R == right.R
                && left.G == right.G
                && left.B == right.B)
                return true;

            if (Abs(left.R - right.R) < Epsilon
                && Abs(left.G - right.G) < Epsilon
                && Abs(left.B - right.B) < Epsilon)
                return true;

            return false;
        }

        public static bool operator !=(Color left, Color right)
            => !(left == right);

        #endregion Operators

        #region Equality

        public override bool Equals(object? obj)
        {
            if (obj is Color color)
                return Equals(color);

            return false;
        }

        public bool Equals(Color other)
            => this == other;

        public override int GetHashCode()
            => R.GetHashCode()
             + G.GetHashCode()
             + B.GetHashCode();

        #endregion Equality

        #region FixedColors

        public static Color Black => new Color(0, 0, 0);
        public static Color White => new Color(1, 1, 1);
        public static Color Red => new Color(1, 0, 0);
        public static Color Green => new Color(0, 1, 0);
        public static Color Blue => new Color(0, 0, 1);
        public static Color Cyan => new Color(0, 1, 1);
        public static Color Magenta => new Color(1, 0, 1);
        public static Color Yellow => new Color(1, 1, 0);

        #endregion FixedColors
    }
}