// Copyright (c) Microsoft.  All Rights Reserved.  Licensed under the Apache License, Version 2.0.  See License.txt in the project root for license information.

using System;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.Text;
using Roslyn.Utilities;

namespace OmniSharp.Intellisense
{
    internal static class TextLineExtensions
    {
        /// <summary>
        /// Returns the first non-whitespace position on the given line, or null if
        /// the line is empty or contains only whitespace.
        /// </summary>
        public static int? GetFirstNonWhitespacePosition(this TextLine line)
        {
            var firstNonWhitespaceOffset = line.GetFirstNonWhitespaceOffset();

            return firstNonWhitespaceOffset.HasValue
                ? firstNonWhitespaceOffset + line.Start
                    : null;
        }

        /// <summary>
        /// Returns the first non-whitespace position on the given line as an offset
        /// from the start of the line, or null if the line is empty or contains only
        /// whitespace.
        /// </summary>
        public static int? GetFirstNonWhitespaceOffset(this TextLine line)
        {
            return line.ToString().GetFirstNonWhitespaceOffset();
        }

        public static string GetLeadingWhitespace(this TextLine line)
        {
            return line.ToString().GetLeadingWhitespace();
        }

        /// <summary>
        /// Determines whether the specified line is empty or contains whitespace only.
        /// </summary>
        public static bool IsEmptyOrWhitespace(this TextLine line)
        {
            return string.IsNullOrWhiteSpace(line.ToString());
        }

        public static int GetColumnOfFirstNonWhitespaceCharacterOrEndOfLine(this TextLine line, int tabSize)
        {
            return line.ToString().GetColumnOfFirstNonWhitespaceCharacterOrEndOfLine(tabSize);
        }

        public static int GetColumnFromLineOffset(this TextLine line, int lineOffset, int tabSize)
        {
            return line.ToString().GetColumnFromLineOffset(lineOffset, tabSize);
        }

        public static int GetLineOffsetFromColumn(this TextLine line, int column, int tabSize)
        {
            return line.ToString().GetLineOffsetFromColumn(column, tabSize);
        }
    }
}