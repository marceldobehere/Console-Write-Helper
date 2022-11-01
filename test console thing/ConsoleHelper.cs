using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleStuff
{
    public class TempTextWriter : IDisposable
    {
        private TextWriter oldWriter;
        private ConsoleHelper.WriteTypeEnum oldType;
        private TextWriter currentWriter;

        public TempTextWriter(TextWriter writer, ConsoleHelper.WriteTypeEnum newType = ConsoleHelper.WriteTypeEnum.Other)
        {
            oldWriter = ConsoleHelper.OtherWriter;
            oldType = ConsoleHelper.WriteType;
            currentWriter = writer;

            ConsoleHelper.OtherWriter = writer;
            ConsoleHelper.WriteType = newType;
        }

        public TempTextWriter(string path, ConsoleHelper.WriteTypeEnum newType = ConsoleHelper.WriteTypeEnum.Other)
        {
            var writer = new StreamWriter(path);
            oldWriter = ConsoleHelper.OtherWriter;
            oldType = ConsoleHelper.WriteType;
            currentWriter = writer;

            ConsoleHelper.OtherWriter = writer;
            ConsoleHelper.WriteType = newType;
        }


        public void Dispose()
        {
            ConsoleHelper.OtherWriter = oldWriter;
            ConsoleHelper.WriteType = oldType;
            currentWriter.Close();
            currentWriter.Dispose();
        }

    }

    public static class ConsoleHelper
    {
        public enum WriteTypeEnum
        {
            Console,
            Other,
            Both
        }

        private static ConsoleWriter _staticConsoleWriter = new ConsoleWriter(null, Console.Out, WriteTypeEnum.Console);
        public static ConsoleWriter StaticConsoleWriter
        { get => _staticConsoleWriter; }
        public static TextWriter OtherWriter
        {
            get => _staticConsoleWriter.OtherTextWriter;
            set => _staticConsoleWriter.OtherTextWriter = value;
        }
        public static WriteTypeEnum WriteType
        {
            get => _staticConsoleWriter.WriteType;
            set => _staticConsoleWriter.WriteType = value;
        }

        public class ConsoleWriter : TextWriter
        {
            public TextWriter ConsoleTextWriter;
            public TextWriter OtherTextWriter;
            public WriteTypeEnum WriteType;
            public List<TextWriter> Writers
            {
                get
                {
                    if ((WriteType == WriteTypeEnum.Console || WriteType == WriteTypeEnum.Both) &&
                        ConsoleTextWriter == null)
                        throw new NullReferenceException($"Console writer is NULL!");
                    if ((WriteType == WriteTypeEnum.Other || WriteType == WriteTypeEnum.Both) &&
                        OtherTextWriter == null)
                        throw new NullReferenceException($"Other writer is NULL!");

                    List<TextWriter> writers = new List<TextWriter>();
                    if (WriteType == WriteTypeEnum.Console)
                        writers.Add(ConsoleTextWriter);
                    else if (WriteType == WriteTypeEnum.Other)
                        writers.Add(OtherTextWriter);
                    else if (WriteType == WriteTypeEnum.Both)
                    {
                        writers.Add(ConsoleTextWriter);
                        writers.Add(OtherTextWriter);
                    }

                    return writers;
                }
            }

            public ConsoleWriter(TextWriter secondary, TextWriter primary, WriteTypeEnum writeType)
            {
                ConsoleTextWriter = primary;
                OtherTextWriter = secondary;
                WriteType = writeType;
                Console.SetOut(this);
            }

            #region Implemented
            public override void WriteLine()
            {
                foreach (var writer in Writers)
                    writer.WriteLine();
            }
            public override void WriteLine(object? value)
            {
                foreach (var writer in Writers)
                    writer.WriteLine(value);
            }
            public override void WriteLine(bool value)
            {
                foreach (var writer in Writers)
                    writer.WriteLine(value);
            }
            public override void WriteLine(char value)
            {
                foreach (var writer in Writers)
                    writer.WriteLine(value);
            }
            public override void WriteLine(char[] buffer, int index, int count)
            {
                foreach (var writer in Writers)
                    writer.WriteLine(buffer, index, count);
            }
            public override void WriteLine(char[]? buffer)
            {
                foreach (var writer in Writers)
                    writer.WriteLine(buffer);
            }
            public override void WriteLine(decimal value)
            {
                foreach (var writer in Writers)
                    writer.WriteLine(value);
            }
            public override void WriteLine(double value)
            {
                foreach (var writer in Writers)
                    writer.WriteLine(value);
            }
            public override void WriteLine(float value)
            {
                foreach (var writer in Writers)
                    writer.WriteLine(value);
            }
            public override void WriteLine(int value)
            {
                foreach (var writer in Writers)
                    writer.WriteLine(value);
            }
            public override void WriteLine(long value)
            {
                foreach (var writer in Writers)
                    writer.WriteLine(value);
            }
            public override void WriteLine(ReadOnlySpan<char> buffer)
            {
                foreach (var writer in Writers)
                    writer.WriteLine(buffer);
            }
            public override void WriteLine(string format, object? arg0)
            {
                foreach (var writer in Writers)
                    writer.WriteLine(format, arg0);
            }
            public override void WriteLine(string format, object? arg0, object? arg1)
            {
                foreach (var writer in Writers)
                    writer.WriteLine(format, arg0, arg1);
            }
            public override void WriteLine(string format, object? arg0, object? arg1, object? arg2)
            {
                foreach (var writer in Writers)
                    writer.WriteLine(format, arg0, arg1, arg2);
            }
            public override void WriteLine(string format, params object?[] arg)
            {
                foreach (var writer in Writers)
                    writer.WriteLine(format, arg);
            }
            public override void WriteLine(string? value)
            {
                foreach (var writer in Writers)
                    writer.WriteLine(value);
            }
            public override void WriteLine(StringBuilder? value)
            {
                foreach (var writer in Writers)
                    writer.WriteLine(value);
            }
            public override void WriteLine(uint value)
            {
                foreach (var writer in Writers)
                    writer.WriteLine(value);
            }
            public override void WriteLine(ulong value)
            {
                foreach (var writer in Writers)
                    writer.WriteLine(value);
            }

            public override void Write(object? value)
            {
                foreach (var writer in Writers)
                    writer.Write(value);
            }
            public override void Write(bool value)
            {
                foreach (var writer in Writers)
                    writer.Write(value);
            }
            public override void Write(char value)
            {
                foreach (var writer in Writers)
                    writer.Write(value);
            }
            public override void Write(char[] buffer, int index, int count)
            {
                foreach (var writer in Writers)
                    writer.Write(buffer, index, count);
            }
            public override void Write(char[]? buffer)
            {
                foreach (var writer in Writers)
                    writer.Write(buffer);
            }
            public override void Write(decimal value)
            {
                foreach (var writer in Writers)
                    writer.Write(value);
            }
            public override void Write(double value)
            {
                foreach (var writer in Writers)
                    writer.Write(value);
            }
            public override void Write(float value)
            {
                foreach (var writer in Writers)
                    writer.Write(value);
            }
            public override void Write(int value)
            {
                foreach (var writer in Writers)
                    writer.Write(value);
            }
            public override void Write(long value)
            {
                foreach (var writer in Writers)
                    writer.Write(value);
            }
            public override void Write(ReadOnlySpan<char> buffer)
            {
                foreach (var writer in Writers)
                    writer.Write(buffer);
            }
            public override void Write(string format, object? arg0)
            {
                foreach (var writer in Writers)
                    writer.Write(format, arg0);
            }
            public override void Write(string format, object? arg0, object? arg1)
            {
                foreach (var writer in Writers)
                    writer.Write(format, arg0, arg1);
            }
            public override void Write(string format, object? arg0, object? arg1, object? arg2)
            {
                foreach (var writer in Writers)
                    writer.Write(format, arg0, arg1, arg2);
            }
            public override void Write(string format, params object?[] arg)
            {
                foreach (var writer in Writers)
                    writer.Write(format, arg);
            }
            public override void Write(string? value)
            {
                foreach (var writer in Writers)
                    writer.Write(value);
            }
            public override void Write(StringBuilder? value)
            {
                foreach (var writer in Writers)
                    writer.Write(value);
            }
            public override void Write(uint value)
            {
                foreach (var writer in Writers)
                    writer.Write(value);
            }
            public override void Write(ulong value)
            {
                foreach (var writer in Writers)
                    writer.Write(value);
            }

            public override void Close()
            {
                foreach (var writer in Writers)
                    writer.Close();
            }
            public override string ToString()
            {
                return base.ToString();
            }

            public override IFormatProvider FormatProvider => ConsoleTextWriter.FormatProvider;
            public override Encoding Encoding => ConsoleTextWriter.Encoding;
            public override string NewLine { get => ConsoleTextWriter.NewLine; set => ConsoleTextWriter.NewLine = value; }
            #endregion

            #region Not Implemented
            public override ValueTask DisposeAsync()
            {
                throw new NotImplementedException();
            }
            public override bool Equals(object? obj)
            {
                throw new NotImplementedException();
            }
            public override void Flush()
            {
                throw new NotImplementedException();
            }
            public override Task FlushAsync()
            {
                throw new NotImplementedException();
            }
            public override int GetHashCode()
            {
                throw new NotImplementedException();
            }
            public override object InitializeLifetimeService()
            {
                throw new NotImplementedException();
            }

            public override Task WriteAsync(char value)
            {
                throw new NotImplementedException();
            }
            public override Task WriteAsync(char[] buffer, int index, int count)
            {
                throw new NotImplementedException();
            }
            public override Task WriteAsync(ReadOnlyMemory<char> buffer, CancellationToken cancellationToken = default)
            {
                throw new NotImplementedException();
            }
            public override Task WriteAsync(string? value)
            {
                throw new NotImplementedException();
            }
            public override Task WriteAsync(StringBuilder? value, CancellationToken cancellationToken = default)
            {
                throw new NotImplementedException();
            }
            public override Task WriteLineAsync()
            {
                throw new NotImplementedException();
            }
            public override Task WriteLineAsync(char value)
            {
                throw new NotImplementedException();
            }
            public override Task WriteLineAsync(char[] buffer, int index, int count)
            {
                throw new NotImplementedException();
            }
            public override Task WriteLineAsync(ReadOnlyMemory<char> buffer, CancellationToken cancellationToken = default)
            {
                throw new NotImplementedException();
            }
            public override Task WriteLineAsync(string? value)
            {
                throw new NotImplementedException();
            }
            public override Task WriteLineAsync(StringBuilder? value, CancellationToken cancellationToken = default)
            {
                throw new NotImplementedException();
            }
            #endregion
        }
    }
}
