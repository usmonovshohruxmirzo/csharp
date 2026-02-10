using System.Reflection;

namespace TableOfRecords
{
    public static class TableOfRecordsCreator
    {
        public static void WriteTable<T>(ICollection<T>? collection, TextWriter? writer)
        {
            ArgumentNullException.ThrowIfNull(collection);
            ArgumentNullException.ThrowIfNull(writer);

            if (collection.Count == 0)
                throw new ArgumentException("Collection cannot be empty.", nameof(collection));

            PropertyInfo[] properties =
                typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);

            if (properties.Length == 0)
                throw new ArgumentException("Type must have at least one public property.");

            var headers = properties.Select(p => p.Name).ToArray();

            var rows = collection
                .Select(item =>
                    properties.Select(p =>
                        p.GetValue(item)?.ToString() ?? string.Empty).ToArray())
                .ToList();

            int[] widths = new int[properties.Length];

            for (int i = 0; i < properties.Length; i++)
            {
                widths[i] = Math.Max(
                    headers[i].Length,
                    rows.Max(r => r[i].Length));
            }

            void WriteSeparator()
            {
                writer.Write('+');
                for (int i = 0; i < widths.Length; i++)
                {
                    writer.Write(new string('-', widths[i] + 2));
                    writer.Write('+');
                }
                writer.WriteLine();
            }

            void WriteRow(string[] values, bool header = false)
            {
                writer.Write('|');

                for (int i = 0; i < values.Length; i++)
                {
                    bool rightAlign =
                        !header && IsRightAlignedType(properties[i].PropertyType);

                    string cell = rightAlign
                        ? values[i].PadLeft(widths[i])
                        : values[i].PadRight(widths[i]);

                    writer.Write($" {cell} |");
                }

                writer.WriteLine();
            }

            WriteSeparator();
            WriteRow(headers, header: true);
            WriteSeparator();

            foreach (var row in rows)
            {
                WriteRow(row);
                WriteSeparator();
            }
        }

        private static bool IsRightAlignedType(Type type)
        {
            type = Nullable.GetUnderlyingType(type) ?? type;

            return (type.IsPrimitive && type != typeof(char))
                   || type == typeof(decimal)
                   || type == typeof(DateTime);
        }
    }
}
