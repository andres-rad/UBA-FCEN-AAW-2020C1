using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    public class FilePath
    {
        public int Id { get; internal set; }
        public string Path { get; internal set; }
        public int TurneroId { get; internal set; }

        public FilePath(int turneroId, string path)
        {
            TurneroId = turneroId;
            Path = path;
        }
    }
}
