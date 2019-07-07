﻿using Newtonsoft.Json;
using TAS.Common;
using TAS.Common.Interfaces.MediaDirectory;

namespace TAS.Remoting.Model.Media
{
    public class ServerDirectory : WatcherDirectory, IServerDirectory
    {
#pragma warning disable CS0649
        [JsonProperty(nameof(IServerDirectory.IsRecursive))]
        private bool _isRecursive;

        [JsonProperty(nameof(IServerDirectory.IsPrimary))]
        private readonly bool _isPrimary;
        [JsonProperty(nameof(IServerDirectory.MovieContainerFormat))]
        private readonly TMovieContainerFormat _movieContainerFormat;



#pragma warning restore

        public TMovieContainerFormat MovieContainerFormat => _movieContainerFormat;

        public bool IsPrimary => _isPrimary;

        public bool IsRecursive => _isRecursive;
    }
}
